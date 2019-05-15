using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teachify.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teachify.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstructorProfilePage : ContentPage
    {
        private string number;
        private string email;
        public InstructorProfilePage(int id)
        {
            InitializeComponent();
            GetInstructorProfile(id);
        }

        public async void GetInstructorProfile(int id)
        {
            ApiService apiService = new ApiService();
            var instructor = await apiService.GetInstructor(id);
            ImgProfile.Source = instructor.FullLogoPath;
            LblCity.Text = instructor.City;
            LblLanguage.Text = instructor.Language;
            LblNationality.Text = instructor.Nationality;
            LblExperience.Text = instructor.Experience;
            LblSpecialization.Text = instructor.CourseDomain;
            LblName.Text = instructor.Name;
            LblOneLineDescription.Text = instructor.OneLineTitle;
            LblHourlyRate.Text = instructor.HourlyRate;
            LblDescription.Text = instructor.Description;
            number = instructor.Phone;
            email = instructor.Email;
        }

        private void BtnCall_OnClicked(object sender, EventArgs e)
        {
            PhoneDialer.Open(number);
        }

        private void BtnSms_OnClicked(object sender, EventArgs e)
        {
            var message = new SmsMessage("",number);
            Sms.ComposeAsync(message);
        }

        private void BtnEmail_OnClicked(object sender, EventArgs e)
        {
            var message = new EmailMessage("","",email);
            Email.ComposeAsync(message);
        }
    }
}