using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace XO
{
    public class Robot
    {
        private int randTouch;

        static public bool Turn = false;
        public static string Sym;
        public static int cell = 99;
        public static void RoboTurn(List<Button> bs, int rand = 23)
        {

            try
            {
                var r = new Robot();
                if (rand == 23)
                {
                    int a = new Random().Next(1, bs.Count);
                    if (bs[a - 1].IsEnabled)
                    {
                        bs[a - 1].Content = Robot.Sym;
                        bs[a - 1].IsEnabled = false;
                    }
                    else
                    {
                        RoboTurn(bs, new Random().Next(1, bs.Count));
                    }
                }
                if (rand != 23)
                {
                    int b = new Random().Next(1, bs.Count);
                    while (true)
                    {
                        b = new Random().Next(1, bs.Count);
                        
                        if (bs[b - 1].IsEnabled)
                        {
                            bs[b - 1].Content = Robot.Sym;
                            bs[b - 1].IsEnabled = false;
                            return;
                        }
                        if (!bs[b - 1].IsEnabled)
                        {
                            RoboTurn(bs, new Random().Next(1, bs.Count));
                        }
                    }

                }
            }
            catch (Exception we)
            {
                MessageBox.Show(Convert.ToString(we));
            }


        }
    }
}