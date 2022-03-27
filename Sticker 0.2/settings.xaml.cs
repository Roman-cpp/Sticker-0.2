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
using System.Windows.Shapes;
using System.Drawing;
using FontText = System.Windows.Media.FontFamily;

namespace Sticker_0._2
{
    /// <summary>
    /// Логика взаимодействия для settings.xaml
    /// </summary>
    public partial class settings : Window
    {
        public settings()
        {
            InitializeComponent();
            //font
            foreach (FontText font_family in Fonts.SystemFontFamilies)
                font_box.Items.Add(font_family.Source);


            _minut = Convert.ToInt32(Properties.Settings.Default.minut);
            _list_color = Properties.Settings.Default.list_color;
            _font_color = Properties.Settings.Default.font_color;
            _font_size = Properties.Settings.Default.font_size;
            _font = Properties.Settings.Default.font;
        }


        private void colorFont_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = e.Source as TextBox;
            if (textBox.Text.Length == 7)
                Properties.Settings.Default.font_color = textBox.Text;
        }

        private void colorList_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = e.Source as TextBox;
            if (textBox.Text.Length == 7)
                Properties.Settings.Default.list_color = textBox.Text;
        }


        private void ok_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.minut = Convert.ToInt32(minut.Text);
            Properties.Settings.Default.list_color = color_list.Text;
            Properties.Settings.Default.font_color = color_font.Text;
            Properties.Settings.Default.font_size = text_size.Text;
            Properties.Settings.Default.font = font_box.Text;
            Properties.Settings.Default.Save();

            this.Close();
        }
        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.minut = _minut;
            Properties.Settings.Default.list_color = _list_color;
            Properties.Settings.Default.font_color = _font_color;
            Properties.Settings.Default.font_size = _font_size;
            Properties.Settings.Default.font = _font;
         
            this.Close();
        }
        private void factorySettings_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.minut = 5;
            Properties.Settings.Default.list_color = "#fff79a";
            Properties.Settings.Default.font_color = "#000000";
            Properties.Settings.Default.font_size = "24";
            Properties.Settings.Default.font = "PF Scandal Pro Black";
            Properties.Settings.Default.Save();
            this.Close();
        }

        private int _minut;
        private string _list_color;
        private string _font_color;
        private string _font_size;
        private string _font;

    }
}
