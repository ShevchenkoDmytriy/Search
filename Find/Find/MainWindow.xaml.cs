using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Find
{

    public partial class MainWindow : Window
    {
        string text1 = "";
        public MainWindow()
        {
            InitializeComponent();

        }

        private async void but1_Click(object sender, RoutedEventArgs e)
        {
            await Open();
        }

        private async void but2_Click(object sender, RoutedEventArgs e)
        {
            await Open1();
        }

        private async void Ok_Click(object sender, RoutedEventArgs e)
        {
            await Open2();
        }

        private async void Ok_Copy_Click(object sender, RoutedEventArgs e)
        {
            await Open3();
        }

        private async void Write_Click(object sender, RoutedEventArgs e)
        {
            await Open4();
        }
        async Task Open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {

                Text1_Copy.Text = openFileDialog.FileName;
            }
            string path = "";
            if (Text1_Copy.Text == "")
            {
                MessageBox.Show("Error");
            }
            else
            {
                path = Text1_Copy.Text;
            }
            if (path != "")
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    text1 = await reader.ReadToEndAsync();
                }
            }
        }
        async Task Open1()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {

                Text1.Text = openFileDialog.FileName;
            }
        }
        async Task Open2()
        {
            string path = "";
            if (Text1.Text == "")
            {
                MessageBox.Show("Error");
            }
            else
            {
                path = Text1.Text;
            }
            if (path != "")
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    string text = await reader.ReadToEndAsync();
                    Text2.Text = text;
                }
            }
        }
        async Task Open3()
        {
            string str = Text2.Text;
            if (str.Contains(text1))
                Text3.Text += str;
        }
        async Task Open4()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {

                Text4.Text = openFileDialog.FileName;
            }
            using (StreamWriter writer = new StreamWriter(Text4.Text, true))
            {
                await writer.WriteLineAsync(Text3.Text);
            }
        }
    }
}
