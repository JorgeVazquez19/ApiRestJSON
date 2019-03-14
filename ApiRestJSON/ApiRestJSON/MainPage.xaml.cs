using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ApiRestJSON
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LlenarCursos();
        }

        private async void LlenarCursos()
        {
            HttpClient cliente = new HttpClient();

            string url = "http://tgconsulting.online/tg-rest/servicio.php/cursos";

            var resultado = await cliente.GetAsync(url);
            var json = resultado.Content.ReadAsStringAsync().Result;

            CursosModel modelo = CursosModel.FromJson(json);

            listaCursos.ItemsSource = modelo.Cursos;
        }

        private async void Agregar_Click(object sender, EventArgs args)
        {
            Curso curso = new Curso();
            curso.Nombre = "Xamarin";
            curso.Duracion = 40;

            HttpClient cliente = new HttpClient();

            string url = "http://tgconsulting.online/tg-rest/servicio.php/cursos";

            String jsonCurso = JsonConvert.SerializeObject(curso);
            var resultado = await cliente.PostAsync(url, new StringContent(jsonCurso));
            var json = resultado.Content.ReadAsStringAsync().Result;

            await DisplayAlert("Resultado", json, "Ok");

            LlenarCursos();
        }

        private void Eliminar_Click(object sender, EventArgs args)
        {

        }

    }
}
