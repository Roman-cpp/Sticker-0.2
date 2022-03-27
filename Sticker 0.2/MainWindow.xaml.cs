using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Threading;


namespace Sticker_0._2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            //copy from fail.txt
            using (FileStream fstream = new FileStream($"{path}\\TextFile.txt", FileMode.OpenOrCreate))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                text.Text = textFromFile;
            }

            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, Properties.Settings.Default.minut);
            dispatcherTimer.Start();
        }

        //Context Menu
        private void pasteMenuItem_Click(object sender, EventArgs e) => text.Paste();
        private void copyMenuItem_Click(object sender, EventArgs e) => text.Copy();
        private void cutMenuItem_Click(object sender, EventArgs e) => text.Cut();
        private void exitMenuItem_Click(object sender, EventArgs e) => Application.Current.Shutdown();
        private void settingMenuItem_Ckick(object sender, EventArgs e)
        {
            settings settings = new settings();
            settings.ShowDialog();
        }



        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            using (FileStream fstream = new FileStream($"{path}\\TextFile.txt", FileMode.Create))
            {
                // преобразуем строку в байты
                byte[] array = System.Text.Encoding.Default.GetBytes(text.Text);
                // запись массива байтов в файл
                fstream.Write(array, 0, array.Length);
                //Console.WriteLine("Текст записан в файл");
            }
        }


        private void movingMainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!pin.IsChecked == true)
            {
                DragMove();
            }

        }
        
        private void pin_LostMouseCapture(object sender, MouseEventArgs e)
        {
            Properties.Settings.Default.X = Left.ToString();
            Properties.Settings.Default.Y = Top.ToString();
            Properties.Settings.Default.Save();
        }

        private string path = Directory.GetCurrentDirectory();
        private DispatcherTimer dispatcherTimer = new DispatcherTimer(); 
    }
}
