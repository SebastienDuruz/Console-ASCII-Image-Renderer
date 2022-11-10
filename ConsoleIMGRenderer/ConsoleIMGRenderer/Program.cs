/// Autor : Sébastien Duruz
/// Date : 18.12.2020

using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.IO;
using System.Threading;

namespace ConsoleIMGRenderer
{
    /// <summary>
    /// Class Program
    /// </summary>
    class Program
    {
        static FilterInfoCollection WebcamColl;
        static VideoCaptureDevice Device;
        static string FilePath = "NO_IMAGE";
        public static Bitmap IMG;
        public static long PixelCounter = 0;

        /// <summary>
        /// Main Method
        /// </summary>
        static void Main(string[] args)
        {
            Bitmap img = null;
            int limited = 0;

            if (args[0] == "help")
            {
                Console.WriteLine("Convert image or webcam stream into ASCII.");
                Console.WriteLine("Parameters :");
                Console.WriteLine("[ImageFilePath] || [w] || [wc] <--> The source of the image");
                Console.WriteLine("[1]                            <--> Limit the nb of operation to 1 by sec");
                Environment.Exit(0);
            }
            

            if (args.Length < 1 || args.Length > 3)
            {
                Console.WriteLine("Not a valid parameter : path\\of\\the\\image.png || w for webcam picture");
                Environment.Exit(0);
            }

            try
            {
                if (File.Exists(args[0]))
                {
                    img = new Bitmap(args[0]);
                    img = new Bitmap(img, new Size(Console.WindowWidth - 1, (int)(Console.WindowHeight - 1)));
                }
                else if (args[0].ToLower().Contains("w"))
                {
                    WebcamColl = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                    if (WebcamColl.Count > 0)
                    {
                        Device = new VideoCaptureDevice(WebcamColl[0].MonikerString);
                        Device.Start();
                        Device.NewFrame += new NewFrameEventHandler(SaveFrame);
                    }
                    else
                    {
                        Console.WriteLine("No Webcam Detected");
                        return;
                    }

                    while (IMG == null)
                    {

                    }

                    img = new Bitmap(IMG);
                    img = new Bitmap(img, new Size(Console.WindowWidth - 1, (int)(Console.WindowHeight - 1)));
                }

                if (args.Length >= 2)
                    limited = int.Parse(args[1]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;

            if (args[0].ToLower() == "wc")
            {
                while(true)
                {
                    for (int y = 0; y < img.Height; ++y)
                    {
                        for (int x = 0; x < img.Width; ++x)
                        {
                            float colorness = img.GetPixel(x, y).GetBrightness();
                            if (colorness > 0.98)
                                Console.Write("@");
                            else if (colorness > 0.95)
                                Console.Write("W");
                            else if (colorness > 0.9)
                                Console.Write("#");
                            else if (colorness > 0.85)
                                Console.Write("M");
                            else if (colorness > 0.8)
                                Console.Write("B");
                            else if (colorness > 0.75)
                                Console.Write("N");
                            else if (colorness > 0.7)
                                Console.Write("Q");
                            else if (colorness > 0.6)
                                Console.Write("X");
                            else if (colorness > 0.55)
                                Console.Write("U");
                            else if (colorness > 0.5)
                                Console.Write("4");
                            else if (colorness > 0.45)
                                Console.Write("s");
                            else if (colorness > 0.4)
                                Console.Write("c");
                            else if (colorness > 0.35)
                                Console.Write("?");
                            else if (colorness > 0.3)
                                Console.Write("=");
                            else if (colorness > 0.25)
                                Console.Write("{");
                            else if (colorness > 0.2)
                                Console.Write("|");
                            else if (colorness > 0.15)
                                Console.Write("^");
                            else if (colorness > 0.1)
                                Console.Write(",");
                            else if(colorness > 0.05)
                                Console.Write(".");
                            else
                                Console.Write(" ");
                            if (limited != 0)
                                Thread.Sleep(1000 / limited);
                        }
                        Console.WriteLine();
                    }
                    PixelCounter += img.Width * img.Height;
                    Console.Write($"Pixels {PixelCounter}");
                    Console.SetCursorPosition(0, 0);
                    img = new Bitmap(IMG, new Size(Console.WindowWidth - 1, (int)(Console.WindowHeight - 1)));

                }
            }
            else
            {
                if (img != null)
                    for (int y = 0; y < img.Height; ++y)
                    {
                        for (int x = 0; x < img.Width; ++x)
                        {
                            float colorness = img.GetPixel(x, y).GetBrightness();
                            if (colorness > 0.98)
                                Console.Write("@");
                            else if (colorness > 0.95)
                                Console.Write("W");
                            else if (colorness > 0.9)
                                Console.Write("#");
                            else if (colorness > 0.85)
                                Console.Write("M");
                            else if (colorness > 0.8)
                                Console.Write("B");
                            else if (colorness > 0.75)
                                Console.Write("N");
                            else if (colorness > 0.7)
                                Console.Write("Q");
                            else if (colorness > 0.6)
                                Console.Write("X");
                            else if (colorness > 0.55)
                                Console.Write("U");
                            else if (colorness > 0.5)
                                Console.Write("4");
                            else if (colorness > 0.45)
                                Console.Write("s");
                            else if (colorness > 0.4)
                                Console.Write("c");
                            else if (colorness > 0.35)
                                Console.Write("?");
                            else if (colorness > 0.3)
                                Console.Write("=");
                            else if (colorness > 0.25)
                                Console.Write("{");
                            else if (colorness > 0.2)
                                Console.Write("|");
                            else if (colorness > 0.15)
                                Console.Write("^");
                            else if (colorness > 0.1)
                                Console.Write(",");
                            else
                                Console.Write(".");

                            if (limited != 0)
                                Thread.Sleep(1000 / limited);
                        }
                        Console.WriteLine();
                    }
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = true;

            if (args[0].ToLower().Contains("w"))
                Device.SignalToStop();
        }

        /// <summary>
        /// Take a picture from webcam and save it to disc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        static void SaveFrame(object sender, NewFrameEventArgs eventArgs)
        {
            IMG = (Bitmap)eventArgs.Frame.Clone();
            //string imagePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"Image{DateTime.Now.Ticks}.jpg");
            //img.Save(imagePath);
            //FilePath = imagePath;
        }
    }
}
