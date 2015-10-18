using System.Collections.Generic;
using System.Linq;
using PrivatePhotoLibrary.Models;
using PrivatePhotoLibrary.Services.SQLite;
using SQLite;
using Xamarin.Forms;

namespace PrivatePhotoLibrary.Services.PhotoService
{
    public class PhotoService : IPhotoService
    {
        public readonly SQLiteConnection _connection;

        public PhotoService()
        {
            _connection = DependencyService.Get<ISQLite>().GetConnection();
            _connection.CreateTable<PhotoModel>();
        }

        public void AddPhoto(PhotoModel photo)
        {
            _connection.Insert(new PhotoModel {Path = photo.Path, DateCreated = photo.DateCreated});
        }

        public List<PhotoModel> GetPhotos()
        {
            //   _connection.DeleteAll<PhotoModel>();
            return _connection.Table<PhotoModel>().ToList();
        }

        public List<string> GetPhotosPaths()
        {
            return _connection.Table<PhotoModel>().ToList().Select(t => t.Path).ToList();
        }
    }
}