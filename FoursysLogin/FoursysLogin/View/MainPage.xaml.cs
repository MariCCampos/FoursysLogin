using FoursysLogin.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoursysLogin.View
{
    public partial class MainPage : ContentPage
    {
        public static string url = "http://192.168.125.177:3000/api/login/v1";

        public Login usuarioModel;
        

        public MainPage()
        {
            usuarioModel = new Login();
            BindingContext = usuarioModel;
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        public async void ENTRARAsync(object obj, EventArgs args)
        {
            bool resultado = await VerificarLogin();
            if (resultado)
            {
               Navigation.PushAsync(new HomePage(usuarioModel));
            }
            else
            {
                DisplayAlert("ATENÇÃO", "Usuário ou senha incorretos.", "OK");
            }           
        }

        public void PRIMEIRO(object obj, EventArgs args)
        {
            Navigation.PushAsync(new CadastroUsuarioPage());
        }

        public async Task<bool> VerificarLogin()
        {
            usuarioModel.Usuario = login.Text;
            usuarioModel.Senha = senha.Text;
            var json = JsonConvert.SerializeObject(usuarioModel);

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string sContentType = "application/json";
                    var oTaskPostAsync = await client.PostAsync(url, new StringContent(json, Encoding.UTF8, sContentType)).ConfigureAwait(false);
                    if (oTaskPostAsync.IsSuccessStatusCode)
                    {
                        var ret = await oTaskPostAsync.Content.ReadAsStringAsync();
                        return true;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;                
            };
            return false;
        }

    }
    
}
