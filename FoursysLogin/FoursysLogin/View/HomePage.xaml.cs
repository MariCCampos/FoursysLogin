using FoursysLogin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoursysLogin.View
{
    public partial class HomePage : ContentPage
    {
        public Login Login { get; set; }
        public HomePage(Login usuarioModel)
        {
            NavigationPage.SetHasNavigationBar(this,true);
            InitializeComponent();
            this.Login = usuarioModel;
            this.BindingContext = this;
        }
    }
}