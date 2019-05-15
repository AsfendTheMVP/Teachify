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
    public partial class HomePage : ContentPage
    {
        public ObservableCollection<Instructor> Instructors;
        private bool First = true;
        public HomePage()
        {
            InitializeComponent();
            Instructors = new ObservableCollection<Instructor>();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (First)
            {
                ApiService apiService = new ApiService();
                var instructors = await apiService.GetInstructors();
                foreach (var instructor in instructors)
                {
                    Instructors.Add(instructor);
                }

                LvInstructors.ItemsSource = Instructors;
                BusyIndicator.IsRunning = false;
            }

            First = false;

        }

        private void LvInstructors_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedInstructor = e.SelectedItem as Instructor;
            if (selectedInstructor != null)
            {
                Navigation.PushAsync(new InstructorProfilePage(selectedInstructor.Id));
            }

            ((ListView) sender).SelectedItem = null;
        }


        private void TbSearch_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FindInstructorPage());
        }
    }
}