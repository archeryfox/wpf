using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Chat
{
    public class UserAva
    {
        public string ip;
        
        public LinearGradientBrush LGB = new LinearGradientBrush();
        public UserAva(string ip)
        {
            this.ip = ip;
            this.LGB = new LinearGradientBrush(
                Color.FromArgb((byte)new Random().Next(0, 56), (byte)new Random().Next(0, 56), (byte)new Random().Next(0, 56), 5),
                Color.FromArgb((byte)new Random().Next(0, 256), (byte)new Random().Next(0, 256), (byte)new Random().Next(0, 256), (byte)new Random().Next(0, 256))
                , 0);
        }
    }
}
