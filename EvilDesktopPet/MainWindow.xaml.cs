using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Input;

namespace EvilDesktopPet
{
    public partial class MainWindow : Window
    {
        private bool isDragging = false;
        private Point clickPosition;
        private Random rand = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        // 🐾 Click & drag to move the pet
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            clickPosition = e.GetPosition(this);
            CaptureMouse();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                var mousePos = e.GetPosition(null);
                Left = mousePos.X + Left - clickPosition.X;
                Top = mousePos.Y + Top - clickPosition.Y;
            }
        }

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            ReleaseMouseCapture();
        }

        // 💬 When you click the pet, it opens Notepad with a nice message
        private async void Pet_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string ipInfo = await GetIpInfoAsync();
            string[] messages = {
                "I know where you live",
            };

            // Compose final message
            string message = messages[new Random().Next(messages.Length)]
                             + Environment.NewLine + Environment.NewLine
                             + "----- IP Info -----" + Environment.NewLine
                             + ipInfo;

            string tempFile = Path.Combine(Path.GetTempPath(), "pet_message.txt");
            File.WriteAllText(tempFile, message);

            Process.Start(new ProcessStartInfo("notepad.exe", tempFile)
            {
                UseShellExecute = true
            });
        }
        private async Task<string> GetIpInfoAsync()
        {
            // 1) Try to get public IP from a simple service (api.ipify.org)
            try
            {
                using (var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3))) // short timeout
                using (var http = new HttpClient())
                {
                    // api.ipify.org returns plain text
                    http.Timeout = TimeSpan.FromSeconds(3);
                    string publicIp = await http.GetStringAsync("https://api.ipify.org?format=text").ConfigureAwait(false);
                    if (!string.IsNullOrWhiteSpace(publicIp))
                    {
                        return $"Public IP: {publicIp.Trim()}";
                    }
                }
            }
            catch
            {
                // ignore and fall back to local IPs
            }

            // 2) Fallback: list local (LAN) IP addresses
            try
            {
                string hostName = Dns.GetHostName();
                var addresses = Dns.GetHostAddresses(hostName)
                                   .Where(a => a.AddressFamily == AddressFamily.InterNetwork) // IPv4, omit IPv6 for readability
                                   .Select(a => a.ToString())
                                   .ToArray();

                if (addresses.Length > 0)
                {
                    return "Local IP(s): " + string.Join(", ", addresses) + Environment.NewLine + $"Hostname: {hostName}";
                }
                else
                {
                    return $"No IPv4 addresses found. Hostname: {hostName}";
                }
            }
            catch (Exception ex)
            {
                return "Could not determine IP addresses: " + ex.Message;
            }
        }
    }
}
