using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLITE.Models;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLITE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
   
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection _conn;

        
        public Login()
        {
            InitializeComponent();
            _conn = DependencyService.Get<Database>().GetConnection();
        }

        private void btn_login_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = SELECT_WHERE(db, usuario.Text, contra.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("Alerta", "Verifique su usuario/contraseña", "Ok");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "Ok");
            }
        }

        public static IEnumerable<Estudiante> SELECT_WHERE(SQLiteConnection db, string usuario, string contra)
        {
            return db.Query<Estudiante>("SELECT * from Estudiante where Usuario = ? and Contrasenia = ?", usuario, contra);
        }

        private async void btn_registrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Registro());
        }


    }
}