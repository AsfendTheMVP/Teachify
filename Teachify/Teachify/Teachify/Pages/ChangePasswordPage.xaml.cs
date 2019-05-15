using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teachify.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teachify.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChangePasswordPage : ContentPage
    {
        public ChangePasswordPage()
        {
            InitializeComponent();
        }

        private async void BtnChangePassword_OnClicked(object sender, EventArgs e)
        {
            ApiService apiService = new ApiService();
            bool response = await apiService.ChangePassword(EntOldPassword.Text, EntNewPassword.Text, EntConfirmPassword.Text);
            if (!response)
            {
                await DisplayAlert("Oops", "Something wrong", "Cancel");
            }
            else
            {
                await DisplayAlert("Password Changed", "Kindly login with the new password", "Alright");
                Application.Current.MainPage = new NavigationPage(new LoginPage());
            }
        }
    }
}