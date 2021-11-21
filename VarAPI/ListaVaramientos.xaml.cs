using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VarAPI.Models;

namespace VarAPI
{
    /// <summary>
    /// Lógica de interacción para ListaVaramientos.xaml
    /// </summary>
    public partial class ListaVaramientos : Window
    {
        public List<Varamiento> Varamientos { get; set; }
        public ListaVaramientos()
        {
            InitializeComponent();
            recuperarVaramientos();
        }

        private void recuperarVaramientos()
        {
            try
            {
                VaramientoPaginado resultado = "http://ec2-3-137-222-34.us-east-2.compute.amazonaws.com/yo/varamientos"
                    .WithOAuthBearerToken("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJmcmVzaCI6dHJ1ZSwiaWF0IjoxNjM3NDQ2OTYwLCJqdGkiOiI5YjQ5YzhhOS05Y2IzLTRhM2ItOTUwYi1mMTM3MjVmYWMxNTciLCJ0eXBlIjoiYWNjZXNzIiwic3ViIjoiZjIyN2UxZGEtMTU4ZC00ODZiLWJjY2EtNzU2NjI2YzNjOTE3IiwibmJmIjoxNjM3NDQ2OTYwLCJleHAiOjE2Mzc0Njg1NjB9.jFhHTTInSEb0N4gIXBkJQX4vXr6CaS8RT94gIaCfq7E")
                    .GetJsonAsync<VaramientoPaginado>().GetAwaiter().GetResult();
                Varamientos = resultado.resultados;
                DataGridVaramientos.ItemsSource = Varamientos;
                TotalRegistros.Text = Varamientos.Count.ToString();
            } catch(FlurlHttpException flurlException)
            {
                Console.WriteLine(flurlException.Message);
            }
        }

        private void AbrirVentanaCrearVaramiento(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }
    }
}
