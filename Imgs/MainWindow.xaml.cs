using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mime;
using System.Windows.Data;
using System.Windows.Documents;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Image = System.Drawing.Image;
using System.Collections;
using Microsoft.Win32;

namespace Imgs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Метод для «преобразования» объекта изображения в массив байтов, отформатированный в формате файла PNG, который 
        /// обеспечивает сжатие без потерь. Это можно использовать вместе с GetImageFromByteArray().
        /// способ обеспечить своего рода сериализацию/десериализацию.
        /// </summary>
        /// <param name="theImage">Объект изображения, должен быть конвертируемым в формат PNG</param>
        /// <returns>изображение массива байтов файла PNG, содержащего изображение</returns>
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        //два метода, которые я брал за основу
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        private void Kesys(object sender, KeyEventArgs e)
        {
            System.Windows.Controls.Image img = new System.Windows.Controls.Image();
            #region Maybe works, but i want it to bytes

            //Uri uriI = new Uri(@"C:\Users\arche\OneDrive\Изображения\IMG_20221129_124922_034.jpg", UriKind.Absolute);
            //BitmapImage Bmp = new BitmapImage(uriI);
            //MessageBox.Show(Bmp.ToString());
            //img.Source = new DrawingImage();
            //BB.Content = (Image)bitmap;

            #endregion

            #region Image to Bytes

            FileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            //dialog.FileName            ##gives full way to file 
            Image d = Image.FromFile(dialog.FileName);
            Bitmap bitmap = new Bitmap((Image)d);
            byte[] bts;
            string dds = "";
            try
            {
                // pishem ma bin file
                using (MemoryStream mStream = new MemoryStream())// используем файловый поток
                {
                    d.Save(mStream, d.RawFormat);
                    bts = mStream.ToArray();
                    SaveFileDialog SvFileDialg = new SaveFileDialog(); // окошко для сохранения файла
                    SvFileDialg.DefaultExt = "Img";
                    SvFileDialg.ShowDialog();
                    File.WriteAllBytesAsync(SvFileDialg.FileName //savewayyy
                        , bts);//binarnik
                }

                #endregion

                #region Bytes to Image
                //читаем массив байт из файлов
                byte[] imageBytes = File.ReadAllBytes(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\33.txt");
                using (MemoryStream mStream = new MemoryStream(imageBytes))
                {
                    ImageConverter ic = new ImageConverter();
                    //делаем из него дравабельную картинку 
                    Image img1 = (Image)ic.ConvertFrom(imageBytes);
                    //делаем из этого битмап
                    bitmap = new Bitmap(img1);
                    IntPtr bmpPt = bitmap.GetHbitmap(); //делаем цифрохэшбитмап 
                    BitmapSource bitmapSource = //создаём полноценный Источник из битмапа
                        System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                            bmpPt,
                            IntPtr.Zero,
                            Int32Rect.Empty,
                            BitmapSizeOptions.FromEmptyOptions());

                    //заморозить bitmapSource и очистить память, чтобы избежать утечек памяти = убираем хлам за собой
                    bitmapSource.Freeze();
                    //заполняем до этого дравабельную картинку источником из битмапа
                    img.Source = bitmapSource;
                    //заполняем контент фрейма элементом "картинка img" выше
                    BB.Content = img;
                }
                #endregion
            }
            catch { }
        }
    }
}
