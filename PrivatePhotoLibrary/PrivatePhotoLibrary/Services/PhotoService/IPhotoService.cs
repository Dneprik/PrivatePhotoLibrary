using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrivatePhotoLibrary.Models;

namespace PrivatePhotoLibrary.Services.PhotoService
{
    public interface IPhotoService
    {
        void AddPhoto(PhotoModel photo);
        List<PhotoModel> GetPhotos();
        List<string> GetPhotosPaths();
    }
}
