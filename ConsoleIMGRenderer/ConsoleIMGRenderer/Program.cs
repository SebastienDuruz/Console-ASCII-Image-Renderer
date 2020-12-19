/// Autor : Sébastien Duruz
/// Date : 18.12.2020

using System;
using System.Drawing;

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

            if(args.Length != 1)
            {
                Console.WriteLine("Not a valid parameter : path\\of\\the\\image.png");
                Environment.Exit(0);
            }

            try
            {
                img = new Bitmap(args[0]);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            if (img != null)
            {
                for (int y = 0; y < img.Height; ++y)
                {
                    for (int x = 0; x < img.Width; ++x)
                    {
                        Color color = img.GetPixel(x, y);
                        int colorTemp = color.A + color.B + color.G;

                        if (colorTemp > 730)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("█");
                        }
                        else if (colorTemp > 700)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("▓");
                        }
                        else if (colorTemp > 650)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("▒");
                        }
                        else if (colorTemp > 600)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("#");
                        }
                        else if (colorTemp > 550)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("H");
                        }
                        else if (colorTemp > 500)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("O");
                        }
                        else if (colorTemp > 450)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("#");
                        }
                        else if (colorTemp > 400)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("H");
                        }
                        else if (colorTemp > 350)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("O");
                        }
                        else if (colorTemp > 300)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write("C");
                        }
                        else if (colorTemp > 250)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("O");
                        }
                        else if (colorTemp > 200)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("C");

                        }
                        else if (colorTemp > 150)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("i");
                        }
                        else if (colorTemp > 100)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write("*");
                        }
                        else if (colorTemp > 50)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write(".");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
