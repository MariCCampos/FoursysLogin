using FoursysLogin.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FoursysLogin.View
{
    public partial class CadastroUsuarioPage : ContentPage
    {
        public static string url = "http://192.168.125.177:3000/api/login/v1/cadastro";

        public Login usuarioModel;

        public CadastroUsuarioPage()
        {
            usuarioModel = new Login();
            NavigationPage.SetHasNavigationBar(this, true);
            InitializeComponent();
        }

        public async void CADASTROAsync(object obj, EventArgs args)
        {
            bool resultado = await CadastrarLogin();

            if (resultado)
            {
                DisplayAlert("MENSAGEM", "Cadastro efetuado com sucesso.", "OK");
                Navigation.PopAsync();
            }
            else
            {
                DisplayAlert("ATENÇÃO", "Erro.", "OK");
            }            
        }

        public async Task<bool> CadastrarLogin()
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
                Console.WriteLine("Exception: " + ex.Message);
            };
            return false;
        }


    }
    }
