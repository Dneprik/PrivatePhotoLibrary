using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using PrivatePhotoLibrary.Models;
using PrivatePhotoLibrary.Services.PhotoService;
using Xamarin.Forms;
using XLabs.Platform.Services.Media;

namespace PrivatePhotoLibrary.ViewModels
{
    internal class MainPageViewModel : BaseMainPageViewModel
    {
        private readonly IPhotoService _photoService = new PhotoService();
        private bool _isCameraAvailable;
        private readonly IMediaPicker _mediaPicker = DependencyService.Get<IMediaPicker>();
        private bool isFirstExecution = true;//For binding method
        private readonly Action<string> ShowAlertException;

        public MainPageViewModel(Action<string> showAlertExceptionAction)
        {
            Photos = new List<PhotoModel>();
            ListViewPhotos = new ObservableCollection<ListViewPhotoModel>();

            OpenCammeraCommand = new Command(OpenCamera);
            IsCameraAvailable = _mediaPicker.IsCameraAvailable;
            ShowAlertException = showAlertExceptionAction;

            Photos = _photoService.GetPhotos();
            PhotosToListModel(Photos);
        }

        public List<PhotoModel> Photos { get; set; }
        public ObservableCollection<ListViewPhotoModel> ListViewPhotos { get; set; }

        public ICommand OpenCammeraCommand { get; }


        public bool IsCameraAvailable
        {
            get { return _isCameraAvailable; }
            set
            {
                if (value == _isCameraAvailable) return;
                _isCameraAvailable = value;
                OnPropertyChanged();
            }
        }

        private bool IsInt(object obj)
        {
            return Convert.ToInt32(obj) == Convert.ToDouble(obj);
        }
        //Binding ListView Images with ObservableCollection
        public void PhotosToListModel(List<PhotoModel> photoModels)
        {
            var startCounter = 1;
            if (!isFirstExecution)
            {
                var d = photoModels.Count/3d;
                var removeItem = Convert.ToInt32(Math.Floor(d));

                if (IsInt(d) && (d >= 1.0)) removeItem = Convert.ToInt32(d) - 1;

                if ((ListViewPhotos.Count != 0) && (removeItem < ListViewPhotos.Count))
                    ListViewPhotos.RemoveAt(removeItem);
                startCounter = removeItem*3 + 1;
            }

            ListViewPhotoModel tempListViewPhotoModel = null;
            for (var i = startCounter; i <= photoModels.Count; i++)
            {
                switch (i%3)
                {
                    case 1:
                        tempListViewPhotoModel = new ListViewPhotoModel {Image1Path = photoModels[i - 1].Path};
                        break;
                    case 2:
                        tempListViewPhotoModel.Image2Path = photoModels[i - 1].Path;
                        break;
                    case 0:
                        tempListViewPhotoModel.Image3Path = photoModels[i - 1].Path;
                        break;
                }

                if ((i == photoModels.Count) || (i%3 == 0))
                {
                    ListViewPhotos.Add(tempListViewPhotoModel);
                }
            }

            isFirstExecution = false;
        }


        private async void OpenCamera()
        {
            try
            {
                MediaFile file = null;
                if (_mediaPicker.IsCameraAvailable)
                {
                    file = await _mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions());
                    var photo = new PhotoModel {DateCreated = DateTime.Now, Path = file.Path};
                    _photoService.AddPhoto(photo);
                    Photos.Add(photo);
                    PhotosToListModel(Photos);
                }
                else
                {
                    IsCameraAvailable = false;
                }
            }
            catch (TaskCanceledException ex)
            {
            }
            catch (Exception ex)
            {
                if (ShowAlertException != null)
                    ShowAlertException(ex.Message);
            }
        }
    }
}