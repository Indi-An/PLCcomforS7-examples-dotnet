using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

/// <summary>
/// Provides thread-safe extension methods for modifying and querying ListView items.
/// These methods ensure that all operations on the ListView are executed on the UI thread,
/// preventing cross-thread exceptions in Windows Forms applications and forcing a repaint after changes.
/// </summary>
public static class ListViewThreadSafeExtensions
{
    /// <summary>
    /// Executes the specified action on the control's UI thread if required.
    /// Ensures that any modifications or queries are performed safely from any thread.
    /// </summary>
    /// <param name="control">The control to invoke on.</param>
    /// <param name="action">The action to execute.</param>
    private static void InvokeIfRequired(this Control control, Action action)
    {
        if (control.InvokeRequired)
            control.Invoke(action); // Marshall to UI thread if necessary
        else
            action();
    }

    /// <summary>
    /// Thread-safe add of a ListViewItem to the ListView and triggers a refresh.
    /// </summary>
    /// <param name="listView">The ListView to modify.</param>
    /// <param name="item">The item to add.</param>
    public static void AddItemSafe(this ListView listView, ListViewItem item)
    {
        listView.InvokeIfRequired(() =>
        {
            listView.BeginUpdate();   // Prevent UI flicker during changes
            listView.Items.Add(item);
            listView.EndUpdate();
            listView.Refresh();       // Force repaint so the UI is updated immediately
        });
    }

    /// <summary>
    /// Thread-safe removal of the first ListViewItem that matches the specified predicate, with refresh.
    /// </summary>
    /// <param name="listView">The ListView to modify.</param>
    /// <param name="match">Predicate to find the item to remove.</param>
    /// <returns>True if an item was removed, false otherwise.</returns>
    public static bool RemoveItemSafe(this ListView listView, Predicate<ListViewItem> match)
    {
        bool removed = false;
        listView.InvokeIfRequired(() =>
        {
            listView.BeginUpdate();
            // Find the first item that matches the predicate
            var toRemove = listView.Items.Cast<ListViewItem>().FirstOrDefault(i => match(i));
            if (toRemove != null)
            {
                listView.Items.Remove(toRemove);
                removed = true;
            }
            listView.EndUpdate();
            listView.Refresh();
        });
        return removed;
    }

    /// <summary>
    /// Thread-safe search for all ListViewItems that match the specified predicate.
    /// </summary>
    /// <param name="listView">The ListView to search.</param>
    /// <param name="match">Predicate to match items.</param>
    /// <returns>List of all matching ListViewItems.</returns>
    public static List<ListViewItem> FindItemsSafe(this ListView listView, Predicate<ListViewItem> match)
    {
        List<ListViewItem> results = new List<ListViewItem>();
        listView.InvokeIfRequired(() =>
        {
            // Enumerate and filter all matching items
            results = listView.Items
                                 .Cast<ListViewItem>()
                                 .Where(i => match(i))
                                 .ToList();
        });
        return results;
    }

    /// <summary>
    /// Thread-safe in-place update of the first ListViewItem that matches the specified predicate, with refresh.
    /// </summary>
    /// <param name="listView">The ListView to modify.</param>
    /// <param name="match">Predicate to find the item to update.</param>
    /// <param name="updateAction">An action to apply to the found item in-place.</param>
    /// <returns>True if an item was updated, false otherwise.</returns>
    public static bool UpdateItemSafe(this ListView listView,
                                      Predicate<ListViewItem> match,
                                      Action<ListViewItem> updateAction)
    {
        bool updated = false;
        listView.InvokeIfRequired(() =>
        {
            listView.BeginUpdate();
            // Find the first matching item
            var toUpdate = listView.Items.Cast<ListViewItem>().FirstOrDefault(i => match(i));
            if (toUpdate != null)
            {
                updateAction(toUpdate); // Update the item in-place
                updated = true;
            }
            listView.EndUpdate();
            listView.Refresh();
        });
        return updated;
    }

    /// <summary>
    /// Thread-safe replacement of the first ListViewItem that matches the specified predicate
    /// with a new item created by the provided factory function, then refresh.
    /// </summary>
    /// <param name="listView">The ListView to modify.</param>
    /// <param name="match">Predicate to find the item to replace.</param>
    /// <param name="replacementFactory">Function to generate a new item based on the old one.</param>
    /// <returns>True if an item was replaced, false otherwise.</returns>
    public static bool UpdateItemSafe(this ListView listView,
                                      Predicate<ListViewItem> match,
                                      Func<ListViewItem, ListViewItem> replacementFactory)
    {
        bool replaced = false;
        listView.InvokeIfRequired(() =>
        {
            listView.BeginUpdate();
            // Find the first matching item
            var oldItem = listView.Items
                                  .Cast<ListViewItem>()
                                  .FirstOrDefault(i => match(i));
            if (oldItem != null)
            {
                int idx = listView.Items.IndexOf(oldItem);
                var newItem = replacementFactory(oldItem);
                listView.Items.RemoveAt(idx);   // Remove old item
                listView.Items.Insert(idx, newItem); // Insert new item at same index
                replaced = true;
            }
            listView.EndUpdate();
            listView.Refresh();
        });
        return replaced;
    }
}
