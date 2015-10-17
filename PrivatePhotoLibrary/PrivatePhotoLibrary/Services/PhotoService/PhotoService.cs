using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            _connection.CreateTable<Photo>();
        }

        public void AddPhoto(Photo photo)
        {
            _connection.Insert(new Photo() {Path = photo.Path, DateCreated = photo.DateCreated });

        }

        public List<Photo> GetPhotos()
        {
            return _connection.Table<Photo>().ToList();
        }
    }
}
