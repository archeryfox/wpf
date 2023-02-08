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
        public static int cell = 9;

        static int Ran(int i)
        {
            var r = new Random();
            return r.Next(0, i);
        }
        public static void RoboTurn(List<Button> bs, int rand = 23)
        {
            int i = 0;

            foreach (var item in bs)
            {
                i += !item.IsEnabled ? 1 : 0;
            }
            if (i != bs.Count)
            {
                try
                {
                    var r = new Robot();
                    if (rand == 23)
                    {
                        int a = Ran(bs.Count);
                        if (bs[a].IsEnabled)
                        {
                            bs[a].Content = Robot.Sym;
                            bs[a].IsEnabled = false;
                            return;
                        }
                        else
                        {
                            do
                            {
                                a = Ran(bs.Count);
                                RoboTurn(bs, a);
                                if (bs[a].IsEnabled)
                                {
                                    bs[a].Content = Robot.Sym;
                                    bs[a].IsEnabled = false;
                                    return;
                                }
                            } while (!bs[a].IsEnabled);

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
}