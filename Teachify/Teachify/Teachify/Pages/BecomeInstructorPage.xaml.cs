using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Teachify.Helpers;
using Teachify.Models;
using Teachify.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teachify.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BecomeInstructorPage : ContentPage
    {
        private MediaFile file;
        public BecomeInstructorPage()
        {
            InitializeComponent();
        }

        private async void TapCamera_OnTapped(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                PhotoSize = PhotoSize.Custom,
                CustomPhotoSize = 30,
                CompressionQuality = 60,    
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            await DisplayAlert("File Location", file.Path, "OK");

            ImgProfile.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });
        }

        private async void BtnApply_OnClicked(object sender, EventArgs e)
        {
            var imageArray = FilesHelper.ReadFully(file.GetStream());
            file.Dispose();
            var instructor = new Instructor()
            {
                Name = EntName.Text,
                Language = EntLanguage.Text,
                Nationality = EntNationality.Text,
                Gender = PickerGender.Items[PickerGender.SelectedIndex],
                Phone = EntPhone.Text,
                Email = EntEmail.Text,
                Education = EntEducation.Text,
                Experience = PickerExperience.Items[PickerExperience.SelectedIndex],
                HourlyRate = PickerHourlyRate.Items[PickerHourlyRate.SelectedIndex],
                CourseDomain = PickerCourseDomain.Items[PickerCourseDomain.SelectedIndex],
                City = PickerCity.Items[PickerCity.SelectedIndex],
                OneLineTitle = EntOneLineTitle.Text,
                Description = EdtDescription.Text,
                ImageArray = imageArray,
            };
            ApiService apiService = new ApiService();
            var response = await apiService.BecomeAnInstructor(instructor);
            if (!response)
            {
                await DisplayAlert("Oops", "Something wrong...", "Cancel");
            }
            else
            {
                await DisplayAlert("Congratulations", "You're now an instructor at teachify.", "Alright");
            }
        }
    }
}