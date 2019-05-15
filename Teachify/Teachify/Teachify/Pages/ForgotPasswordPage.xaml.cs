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
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();
        }

        private async void BtnSend_OnClicked(object sender, EventArgs e)
        {
            ApiService apiService = new ApiService();
            bool response = await apiService.PasswordRecovery(EntEmail.Text);
            if (!response)
            {
                await DisplayAlert("Oops", "Something wrong", "Cancel");
            }
            else
            {
                await DisplayAlert("Hi", "A new password has been sent to your email. Kindly type new password", "Alright");
                await Navigation.PopToRootAsync();
            }
        }
    }
}