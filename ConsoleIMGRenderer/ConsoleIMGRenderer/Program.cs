/// Autor : Sébastien Duruz
/// Date : 18.12.2020

using System;
using System.Drawing;
using System.Threading;

namespace ConsoleIMGRenderer
{
    /// <summary>
    /// Class Program
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main Method
        /// </summary>
        static void Main(string[] args)
        {
            Bitmap img = null;
            bool limited = false;

            if (args.Length < 1 || args.Length > 2)
            {
                Console.WriteLine("Not a valid parameter : path\\of\\the\\image.png");
                Environment.Exit(0);
            }

            try
            {
                img = new Bitmap(args[0]);
                double scaleFactor = img.Width / Console.WindowWidth;
                img = new Bitmap(img, new Size(Console.WindowWidth - 1, (int)(Console.WindowHeight - 1)));
                if (args.Length == 2)
                    limited = args[1] == "1" ? true : false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

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

                        if (limited)
                            Thread.Sleep(1000);
                    }
                    Console.WriteLine();
                }
        }
    }
}
