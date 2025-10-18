using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Windows.Threading;

namespace EvilDesktopPet
{
    public partial class MainWindow : Window
    {
        private bool isClone = false;
        private readonly Random rand = new Random();
        private readonly DispatcherTimer actionTimer = new DispatcherTimer();


        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out POINT lpPoint);

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;
        }
        private bool isHoldingMouse = false;

        private bool isDragging = false;
        private Point clickPosition;
        
        
        private readonly DispatcherTimer wanderTimer = new DispatcherTimer();
        private double wanderSpeed = 2; // pixels per tick
        private double wanderDirectionX;
        private double wanderDirectionY;
        private int ticksUntilDirectionChange;


        public MainWindow() : this(false) { }
        public MainWindow(bool clone = false)
        {
            InitializeComponent();


            lock (instancesLock)
            {
                instances.Add(this);
            }

            // Action timer
            cloneCount++;

            // remove instance on close
            this.Closed += (s, e) =>
            {
                lock (instancesLock)
                {
                    instances.Remove(this);
                }
                cloneCount--;
            };

            isClone = clone;
            if (!isClone)
            {
                // Only the original pet moves and acts
                actionTimer.Interval = TimeSpan.FromSeconds(5);
                actionTimer.Tick += DoRandomAction;
                actionTimer.Start();
                TestCreateFile();
                PlayWabash();
            }

            // Wandering timer
            wanderTimer.Interval = TimeSpan.FromMilliseconds(50);
            wanderTimer.Tick += WanderAround;
            wanderTimer.Start();

            // Pick initial direction
            PickNewWanderDirection();
            //TestCreateFile();
            //Paint();
            //Smile();
            //TestCreateFile();
            //Smile();
            
            //TestCreateFile();
            RansomeWindow window = new RansomeWindow();
            window.Show();
            //TextToSpeech();
            
        }


        private void TextToSpeech()
        {
            using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
            {
                synthesizer.Speak("Hello! This is a test");
            }
        }


        private void DoRandomAction(object? sender, EventArgs e)
        {

            /* 
             int choice = rand.Next(5); // number of safe actions you have

            switch (choice)
            {
                case 0:
                    IpInfo();
                    break;

                case 1:
                    RickRoll();
                    break;
                case 2:
                    OnehundredOpenCloseJumpscare();
                    break;
                case 3:
                    SpawnClone();
                    break;
                case 4:
                    Glitch();
                    break;
            }
             */
            //RickRoll();
            //RickRoll();
            SpawnClone();
            GlitchAll();
        }

        private void Smile()
        {
            Process.Start("cmd.exe", "/c start microsoft.windows.camera:");
        }
        private void TestCreateFile()
        {
            string message = "Virus downloaded";
            MessageBox.Show(message, "Evil Desktop Pet");

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string filePath = Path.Combine(desktop, "Virus.bat");

            // Batch content: opens Notepad with a temporary text file containing the message
            string batchContent = "@echo off\n" +
                                  "echo Please enter your credit card info below Please.... > \"%TEMP%\\Message.txt\"\n" +
                                  "notepad \"%TEMP%\\Message.txt\"\n";

            File.WriteAllText(filePath, batchContent);
        }
        private void OnehundredOpenCloseJumpscare()
        {
            for(int i = 0; i < 30; i++)
            {
                Process.Start("cmd.exe", "/c start chrome data:image/jpeg;base64,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");

            }
        }
        private async void IpInfo()
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

        private void Ransomeware()
        {

        }
        private void RickRoll()
        {
            Process.Start("cmd.exe", "/c start chrome https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }
        //Send a mean message about the user's desktop background
        private void ChangeBackground()
        {
            // Open the Windows background settings
            Process.Start("cmd.exe", "/c start ms-settings:personalization-background");
            string[] colors = { "red", "green", "blue", "yellow", "purple", 
                "orange", "black", "white", "something less... yucky" };
            string color = colors[new Random().Next(colors.Length)];
            // List of messages to pull from
            string[] messages = {
                $"Yeesh, background is getting stale. Mix it up. Try {color} instead.",
                $"Spruce it up dude. This background is horrific. Change it up with {color}.",
                $"Yikes still that same background? Just saying {color} would look better!",
                $"Glad that's not my desktop. If it were, my background would be {color}. Much cleaner",
                $"And you wonder why you don't have friends... Change that background to {color}!",
            };
            string message = messages[new Random().Next(messages.Length)];

            // Show message box
            MessageBox.Show(message, "Evil Desktop Pet");
        }

        public void PlayWabash()
        { 
            System.Media.SoundPlayer wabash = new System.Media.SoundPlayer();
            string filePath = "C:\\Users\\soren\\Source\\Repos\\EvilDesktopPet\\EvilDesktopPet\\wabash.wav";
            if (File.Exists(filePath))
            {
                MessageBox.Show("Does exist");
            }
            else 
            {
                MessageBox.Show("Does not exist");
            }
            /*
            wabash.SoundLocation = "EvilDesktopPet"; // Ensure the WAV file is in the executable directory
            wabash.Load();
            wabash.Play();*/
        }

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


        private Task<string> GetIpInfoAsync()
        {
            try
            {
                string hostName = Dns.GetHostName();
                var addresses = Dns.GetHostAddresses(hostName)
                                   .Where(a => a.AddressFamily == AddressFamily.InterNetwork)
                                   .Select(a => a.ToString())
                                   .ToArray();
                return Task.FromResult("Local IP(s): " + (addresses.Length > 0 ? string.Join(", ", addresses) : "none")
                                       + Environment.NewLine + $"Hostname: {hostName}");
            }
            catch (Exception ex)
            {
                return Task.FromResult("Could not determine IP addresses: " + ex.Message);
            }
        }
        private void WanderAround(object? sender, EventArgs e)
        {
            if (isDragging) return; // don't wander while dragging

            // Move pet
            Left += wanderDirectionX * wanderSpeed;
            Top += wanderDirectionY * wanderSpeed;

            // Keep pet inside screen bounds
            var screenWidth = SystemParameters.PrimaryScreenWidth;
            var screenHeight = SystemParameters.PrimaryScreenHeight;

            if (Left < 0) { Left = 0; wanderDirectionX = Math.Abs(wanderDirectionX); }
            if (Top < 0) { Top = 0; wanderDirectionY = Math.Abs(wanderDirectionY); }
            if (Left + Width > screenWidth) { Left = screenWidth - Width; wanderDirectionX = -Math.Abs(wanderDirectionX); }
            if (Top + Height > screenHeight) { Top = screenHeight - Height; wanderDirectionY = -Math.Abs(wanderDirectionY); }

            // Update ticks for direction change
            ticksUntilDirectionChange--;
            if (ticksUntilDirectionChange <= 0)
            {
                PickNewWanderDirection();
            }

            // Check cursor position
            // Check cursor position
            if (GetCursorPos(out POINT cursor))
            {
                // Check if cursor is over the pet window
                if (!isHoldingMouse &&
                    cursor.X >= Left && cursor.X <= Left + 110 +  Width &&
                    cursor.Y >= Top && cursor.Y <= Top + 300 + Height)
                {
                    isHoldingMouse = true;
                }

                if (isHoldingMouse)
                {
                    // Move the cursor to the center of the window
                    int newCursorX = (int)(Left + Width - 40);
                    int newCursorY = (int)(Top + Height - 40);
                    SetCursorPos(newCursorX, newCursorY);

                    // Optionally release after some time
                    ticksUntilDirectionChange--;
                    if (ticksUntilDirectionChange <= 0)
                    {
                        isHoldingMouse = false;
                        PickNewWanderDirection();
                    }
                }
            }

        }



        private void PickNewWanderDirection()
        {
            // Random angle in radians
            double angle = rand.NextDouble() * 2 * Math.PI;
            wanderDirectionX = Math.Cos(angle);
            wanderDirectionY = Math.Sin(angle);

            // Move in this direction for 1–3 seconds
            ticksUntilDirectionChange = rand.Next(20, 60); // 20–60 ticks of 50 ms = 1–3 seconds
        }

        private static int cloneCount = 0;
        private const int maxClones = 5;
        private static readonly object instancesLock = new object();
        private static readonly List<MainWindow> instances = new List<MainWindow>();

        private void SpawnClone()
        {
            if (cloneCount >= maxClones)
                return;
            MainWindow clone = new MainWindow(true); // <- mark as clone
            clone.Left = this.Left + rand.Next(-200, 200);
            clone.Top = this.Top + rand.Next(-200, 200);
            clone.Show();
        }


        public async Task RunGlitch(int shakeIterations = 15, int shakeDelayMs = 30, int shakeMagnitude = 10)
        {
            // Read original pos on UI thread
            double originalLeft = await Dispatcher.InvokeAsync(() => this.Left);
            double originalTop = await Dispatcher.InvokeAsync(() => this.Top);

            for (int i = 0; i < shakeIterations; i++)
            {
                // Update position on UI thread
                await Dispatcher.InvokeAsync(() =>
                {
                    this.Left = originalLeft + rand.Next(-shakeMagnitude, shakeMagnitude + 1);
                    this.Top = originalTop + rand.Next(-shakeMagnitude, shakeMagnitude + 1);
                });

                // Delay off the UI thread
                await Task.Delay(shakeDelayMs);
            }

            // Reset on UI thread
            await Dispatcher.InvokeAsync(() =>
            {
                this.Left = originalLeft;
                this.Top = originalTop;
            });
        }
        public static void GlitchAll()
        {
            List<MainWindow> snapshot;
            lock (instancesLock)
            {
                // take snapshot to avoid holding lock during Dispatcher work
                snapshot = instances.ToList();
            }

            foreach (var w in snapshot)
            {
                // Fire-and-forget each window's glitch on its dispatcher
                _ = w.RunGlitch();
            }
        }


    }

}


