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
	public partial class SearchInstructorPage : ContentPage
	{
	    public ObservableCollection<Instructor> Instructors;
	    private bool First = true;
	    private string _course;
	    private string _gender;
	    private string _city;

        public SearchInstructorPage(string course, string city, string gender)
        {
	        InitializeComponent();
	        Instructors = new ObservableCollection<Instructor>();
            _course = course;
            _gender = gender;
            _city = city;
        }

	    protected override async void OnAppearing()
	    {
	        base.OnAppearing();
	        if (First)
	        {
	            ApiService apiService = new ApiService();
	            var instructors = await apiService.SearchInstructors(_course,_gender,_city);
	            foreach (var instructor in instructors)
	            {
	                Instructors.Add(instructor);
	            }

	            LvInstructors.ItemsSource = Instructors;
	        }

	        First = false;

	    }

	    private void LvInstructors_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
	    {
	        var selectedInstructor = e.SelectedItem as Instructor;
	        Navigation.PushAsync(new InstructorProfilePage(selectedInstructor.Id));
	    }
    }
}