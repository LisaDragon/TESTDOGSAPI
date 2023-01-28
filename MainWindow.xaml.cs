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

namespace TESTDOGSAPI
{
  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string k = null;
            CreateImage(k);
        }
        public void CreateImage(string k)
        {
            System.Net.WebRequest reqGET;
            if (k == null)
            {
                reqGET = System.Net.WebRequest.Create(@"https://dog.ceo/api/breeds/image/random");
            }
            else
            {
                reqGET = System.Net.WebRequest.Create($@"https://dog.ceo/api/breed/{k}/images/random");
            }
            System.Net.WebResponse resp = reqGET.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string s = sr.ReadToEnd();
            s = s.Replace("{\"status\":\"success\",\"message\":\"", "").Replace("\"}", "");
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(s, UriKind.Absolute);
            bi3.EndInit();
            Img.Source = bi3;
           
        }

        private void NextImage(object sender, RoutedEventArgs e)
        {
            string k = null;
            CreateImage(k);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string k = PorodsBox.Text;
            CreateImage(k);
        }
    }
}