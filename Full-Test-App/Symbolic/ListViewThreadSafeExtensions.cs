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
    /// </summary>
    /// <param name="control">The control to invoke on.</param>
    /// <param name="action">The action to execute.</param>
    private static void InvokeIfRequired(this Control control, Action action)
    {
        if (control.InvokeRequired)
            control.Invoke(action);
        else
            action();
    }

    /// <summary>
    /// Thread-safe add of a ListViewItem to the ListView and refresh.
    /// </summary>
    public static void AddItemSafe(this ListView listView, ListViewItem item)
    {
        listView.InvokeIfRequired(() =>
        {
            listView.BeginUpdate();
            listView.Items.Add(item);
            listView.EndUpdate();
            listView.Refresh();
        });
    }

    /// <summary>
    /// Thread-safe removal of the first ListViewItem that matches the specified predicate, with refresh.
    /// </summary>
    public static bool RemoveItemSafe(this ListView listView, Predicate<ListViewItem> match)
    {
        bool removed = false;
        listView.InvokeIfRequired(() =>
        {
            listView.BeginUpdate();
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
    public static List<ListViewItem> FindItemsSafe(this ListView listView, Predicate<ListViewItem> match)
    {
        List<ListViewItem> results = new List<ListViewItem>();
        listView.InvokeIfRequired(() =>
        {
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
    public static bool UpdateItemSafe(this ListView listView,
                                      Predicate<ListViewItem> match,
                                      Action<ListViewItem> updateAction)
    {
        bool updated = false;
        listView.InvokeIfRequired(() =>
        {
            listView.BeginUpdate();
            var toUpdate = listView.Items.Cast<ListViewItem>().FirstOrDefault(i => match(i));
            if (toUpdate != null)
            {
                updateAction(toUpdate);
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
    public static bool UpdateItemSafe(this ListView listView,
                                      Predicate<ListViewItem> match,
                                      Func<ListViewItem, ListViewItem> replacementFactory)
    {
        bool replaced = false;
        listView.InvokeIfRequired(() =>
        {
            listView.BeginUpdate();
            var oldItem = listView.Items
                                  .Cast<ListViewItem>()
                                  .FirstOrDefault(i => match(i));
            if (oldItem != null)
            {
                int idx = listView.Items.IndexOf(oldItem);
                var newItem = replacementFactory(oldItem);
                listView.Items.RemoveAt(idx);
                listView.Items.Insert(idx, newItem);
                replaced = true;
            }
            listView.EndUpdate();
            listView.Refresh();
        });
        return replaced;
    }
}
