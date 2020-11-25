using SQLite;
using SQLITE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLITE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection _conn;
        public Registro()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
        }

        private void btn_agregar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var DatosRegistro = new Estudiante { Nombre = Nombre.Text, Usuario = Usuario.Text, Contrasenia = Contrasenia.Text };
                _conn.InsertAsync(DatosRegistro);
                limpiarFormulario();
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", "ERROR" + ex.Message, "ok");
            }



        }

        void limpiarFormulario()
        {
            Nombre.Text = "";
            Usuario.Text = "";
            Contrasenia.Text = "";
            DisplayAlert("Alerta", "Se agrego correctamente", "Ok");
        }
    }
}