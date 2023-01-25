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
        public int RandTouch {
            get { return randTouch =  new Random().Next(0,10); }
        }
        public static List<Button> RoboTurn(List<Button> bs)
        {
            Robot robot = new Robot();
            robot.randTouch = robot.RandTouch;
            bool f;
            try
            {
                while ((bs[robot.randTouch].Content != "X" && bs[robot.randTouch].Content != "0"))
                {
                    bs[robot.randTouch].Content = "0";
                    /*if (!(bs[robot.randTouch].Content != "X" && bs[robot.randTouch].Content != "0"))
                    {
                        break;
                    }*/
                }
            }
            catch (Exception e)
            {
                //MessageBox.Show($"{e}");
            }
            
            //MessageBox.Show($"{f}");
            return bs;
        }
    }
}