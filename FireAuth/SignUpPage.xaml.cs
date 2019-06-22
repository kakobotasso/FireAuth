using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FireAuth
{
    public partial class SignUpPage : ContentPage
    {
        IAuth auth;

        public SignUpPage()
        {
            InitializeComponent();
            auth = DependencyService.Get<IAuth>();
        }

        async void SignUpClicked(object sender, EventArgs e)
        {
            bool created = auth.SignUpWithEmailPassword(EmailInput.Text, PasswordInput.Text);
            if (created)
            {
                await DisplayAlert("Success", "Welcome to our system. Log in to have full access", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Sign Up Failed", "Something went wrong. Try again!", "OK");
            }
        }
    }
}
