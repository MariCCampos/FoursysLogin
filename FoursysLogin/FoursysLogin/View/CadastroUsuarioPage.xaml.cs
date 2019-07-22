using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoursysLogin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroUsuarioPage : ContentPage
    {
        public CadastroUsuarioPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
    }
}