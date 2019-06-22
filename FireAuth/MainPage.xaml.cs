using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FireAuth
{
    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {
        IAuth auth;

        public MainPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        async void LoginClicked(object sender, EventArgs e)
        {
            string Token = await auth.LoginWithEmailPassword(EmailInput.Text, PasswordInput.Text);
            if (Token != "")
            {
                await Navigation.PushAsync(new LoggedPage());
            }
            else
            {
                ShowError();
            }
        }

        async private void ShowError()
        {
            await DisplayAlert("Authentication Failed", "E-mail or password are incorrect. Try again!", "OK");
        }

        async void SignUpClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
    }
}
