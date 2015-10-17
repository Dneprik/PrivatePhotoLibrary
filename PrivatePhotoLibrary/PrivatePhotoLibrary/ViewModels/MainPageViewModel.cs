using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PrivatePhotoLibrary.Models;
using PrivatePhotoLibrary.Services.PhotoService;
using Xamarin.Forms;
using XLabs.Platform.Services;
using XLabs.Platform.Services.Media;

namespace PrivatePhotoLibrary.ViewModels
{
    class MainPageViewModel : BaseMainPageViewModel
    {
        public ObservableCollection<string> Photos { get; set; }
        private IMediaPicker _mediaPicker = DependencyService.Get<IMediaPicker>();
        private readonly IPhotoService _photoService = new PhotoService();

        public ICommand OpenCammeraCommand { get; }

        public MainPageViewModel()
        {
         Photos = new ObservableCollection<string>() {"Link1", "Link2", "Link3"};
            OpenCammeraCommand = new Command(OpenCamera);
 
        }

        async private void OpenCamera()
        {
            MediaFile file = null;
            if (_mediaPicker.IsCameraAvailable)
            {
                file = await _mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions());
            }
            else
            {
                file = await _mediaPicker.SelectPhotoAsync(new CameraMediaStorageOptions());
            }
            //Source = ImageSource.FromStream(() => file.Source);

            //  _photoService.AddPhoto(new Photo() {Path = @"asdsad\asd\sda", DateCreated = DateTime.Now});
            // var a =_photoService.GetPhotos();

        }


        async void TakePhotoClicked(object sender, EventArgs e)
        {

            //MediaFile file = null;
            //if (_mediaPicker.IsCameraAvailable)
            //{
            //    file = await _mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions());
            //}
            //else
            //{
            //    file = await _mediaPicker.SelectPhotoAsync(new CameraMediaStorageOptions());
            //}
            //priviewImage.Source = ImageSource.FromStream(() => file.Source);
        }
    }
}
