using System;
using PrivatePhotoLibrary.ViewModels;
using Xamarin.Forms;

namespace PrivatePhotoLibrary.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            _showAlertException += MainPage__showAlertException;
            BindingContext = new MainPageViewModel(_showAlertException);
        }

        private event Action<string> _showAlertException;

        private void MainPage__showAlertException(string exceptionMessage)
        {
            DisplayAlert("Exception", exceptionMessage, "Close");
        }

        private void Cell_OnTapped(object sender, EventArgs e)
        {
            ListView.SelectedItem = null;
        }
    }
}