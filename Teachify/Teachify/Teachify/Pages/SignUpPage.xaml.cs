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
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage ()
		{
			InitializeComponent ();
		}

	    private async void BtnSignUp_OnClicked(object sender, EventArgs e)
	    {
            ApiService apiService = new ApiService();
	        bool response = await apiService.RegisterUser(EntEmail.Text, EntPassword.Text, EntConfirmPassword.Text);
	        if (!response)
	        {
	            await DisplayAlert("Oops", "Something wrong", "Cancel");
	        }
	        else
	        {
	            await DisplayAlert("Hi", "Your account has been created", "Alright");
	            await Navigation.PopToRootAsync();
	        }
	    }
	}
}