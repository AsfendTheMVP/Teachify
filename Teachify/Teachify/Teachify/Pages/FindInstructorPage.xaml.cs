using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teachify.Models;
using Teachify.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Teachify.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FindInstructorPage : ContentPage
    {
        public ObservableCollection<Course> Courses;
        public ObservableCollection<City> Cities;
        ApiService apiService = new ApiService();
        public FindInstructorPage()
        {
            InitializeComponent();
            Courses = new ObservableCollection<Course>();
            Cities = new ObservableCollection<City>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadCourses();
            LoadCities();
        }

        public async void LoadCities()
        {
            var cities = await apiService.GetCities();
            foreach (var city in cities)
            {
                Cities.Add(city);
            }

            PickerCity.ItemsSource = Cities;
        }

        public async void LoadCourses()
        {
            var courses = await apiService.GetCourses();
            foreach (var course in courses)
            {
                Courses.Add(course);
            }

            PickerCourse.ItemsSource = Courses;
        }

        private void BtnSearchInstructor_OnClicked(object sender, EventArgs e)
        {
            if (PickerCourse.SelectedIndex < 0 || PickerCity.SelectedIndex < 0 || PickerGender.SelectedIndex < 0)
            {
                DisplayAlert("Oops", "Please select all the options", "Cancel");
            }
            else
            {
               var course = PickerCourse.Items[PickerCourse.SelectedIndex].Trim();
               var city = PickerCity.Items[PickerCity.SelectedIndex].Trim();
               var gender = PickerGender.Items[PickerGender.SelectedIndex].Trim();
                Navigation.PushAsync(new SearchInstructorPage(course,city,gender));
            }
        }
    }
}