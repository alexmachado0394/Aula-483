using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Windows.Threading;

namespace ValidandoWebSite
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

        List<ListaRequisicoes> list = new List<ListaRequisicoes>();


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var listaDeSite = txtURL.Text.Split(',');

            foreach (var item in listaDeSite)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    try
                    {
                        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(item);
                        HttpWebResponse response = await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, request) as HttpWebResponse;
                        list.Add(new ListaRequisicoes()
                        {
                            Url = item,
                            Status = response.StatusCode.ToString()
                        });
                    }
                    catch
                    {
                        list.Add(new ListaRequisicoes()
                        {
                            Url = item,
                            Status = "Erro"
                        }); //MessageBox.Show(err.Message);
                    }
                }
            }            
        }

        DispatcherTimer timer = new DispatcherTimer();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ListaReq.Clear();
            foreach (var item in list)
            {
                ListaReq.AppendText($"\r\nUrl: {item.Url} \r\nStatus code: {item.Status}");
            }
        }

    }

    public class ListaRequisicoes
    {
        public string Url { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }

    
}
