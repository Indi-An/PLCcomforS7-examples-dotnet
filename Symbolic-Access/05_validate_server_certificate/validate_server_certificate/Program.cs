using Org.BouncyCastle.Tls;
using Org.BouncyCastle.X509;
using PLCcom;
using PLCcom.Core.S7Plus.Tls;
using System.Collections;

namespace validate_server_certificate
{
    internal class Program
    {

        static void Main(string[] args)
        {
            var device = new Tls13Device("192.168.1.10");
            try
            {

                authentication.User = "";
                authentication.Serial = "";


                // 1) Create validator
                var validator = new MyCustomCertificateValidator();

                // 2) Assign validator to the device
                device.ServerCertificateValidator = validator;

                // 3. optional Load trusted certificates (e.g. from file, embedded resource, etc.)
                //device.TrustedCertificates = null;

                // 4. optional Accept all server certificates (not recommended for production)
                //device.AcceptAllServerCertificates = true;

                //4. connect and validate server certificate
                var connectResult = device.Connect();
                if (connectResult.IsQualityGood())
                {
                    Console.WriteLine("Connected successfully with valid server certificate.");
                }
                else
                {
                    Console.WriteLine($"Connection failed: {connectResult.ToString()}");
                }

                Console.WriteLine("Enter any key");
                Console.ReadKey();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                device.DisConnect();
            }
        }
    }

    public sealed class MyCustomCertificateValidator : IServerCertificateValidator
    {
        public void Validate(string host, X509Certificate[] certs, X509Certificate[] trustedCertificates, bool acceptAllServerCertificates)
        {
            try
            {
                if (certs == null || certs.Length == 0)
                    throw new TlsFatalAlert(
                        AlertDescription.no_certificate,
                        new Exception("Server did not send a certificate."));

                if (acceptAllServerCertificates)
                    return;

                var leaf = certs[0];

                // 1. Check validity period
                var now = DateTime.UtcNow;
                if (now < leaf.NotBefore.ToUniversalTime() || now > leaf.NotAfter.ToUniversalTime())
                {
                    throw new TlsFatalAlert(
                        AlertDescription.certificate_expired,
                        new Exception(
                            $"Certificate expired/not yet valid:{Environment.NewLine}" +
                            $"NotBefore: {leaf.NotBefore.ToUniversalTime()}{Environment.NewLine}" +
                            $"NotAfter: {leaf.NotAfter.ToUniversalTime()}{Environment.NewLine}" +
                            $"SubjectDN: {leaf.SubjectDN}"));
                }

                // 2. Verify against trust store – only if one is present
                if (trustedCertificates != null && trustedCertificates.Length > 0)
                {
                    foreach (var cert in certs)
                    {
                        bool trusted = false;
                        foreach (var trustedCert in trustedCertificates)
                        {
                            try
                            {
                                cert.Verify(trustedCert.GetPublicKey());
                                trusted = true;
                                break;
                            }
                            catch
                            {
                                // ignore and try next trustedCert
                            }
                        }

                        if (!trusted)
                        {
                            throw new TlsFatalAlert(
                                AlertDescription.unknown_ca,
                                new Exception("Untrusted certificate: " + cert.SubjectDN));
                        }
                    }
                }

                // 3. Compare host name or IP address to certificate
                if (!MatchesHostName(leaf, host))
                {
                    throw new TlsFatalAlert(
                        AlertDescription.bad_certificate,
                        new Exception($"Certificate does not match host '{host}'."));
                }
            }
            catch (TlsFatalAlert)
            {
                // Already a TLS-specific error, just rethrow
                throw;
            }
            catch (Exception e)
            {
                throw new TlsFatalAlert(AlertDescription.internal_error, e);
            }
        }

        private bool MatchesHostName(X509Certificate cert, string expectedHost)
        {
            // Check Subject Alternative Names first (DNS and IP)
            var altNames = cert.GetSubjectAlternativeNames();
            if (altNames != null)
            {
                foreach (IList entry in altNames)
                {
                    int type = (int)entry[0];
                    string value = entry[1] as string;

                    // 2 = DNSName, 7 = IPAddress
                    if ((type == 2 || type == 7) &&
                        string.Equals(value, expectedHost, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }

            // Fallback: CN from subject
            var subject = cert.SubjectDN.ToString(); // e.g. "CN=plc1.example.com, O=..."
            const string cnPrefix = "CN=";
            var cnIndex = subject.IndexOf(cnPrefix, StringComparison.OrdinalIgnoreCase);
            if (cnIndex >= 0)
            {
                var cnEnd = subject.IndexOf(',', cnIndex);
                string cn = cnEnd >= 0
                    ? subject.Substring(cnIndex + cnPrefix.Length, cnEnd - cnIndex - cnPrefix.Length)
                    : subject.Substring(cnIndex + cnPrefix.Length);

                if (string.Equals(cn.Trim(), expectedHost, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }
    }
}
