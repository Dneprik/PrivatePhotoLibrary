using System.IO;
using PrivatePhotoLibrary.Droid.Services.SQLite;
using PrivatePhotoLibrary.Services.SQLite;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace PrivatePhotoLibrary.Droid.Services.SQLite
{

    public class SQLite_Android: ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "TodoSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection
            var conn = new SQLiteConnection(path);
            // Return the database connection
            return conn;
        }
    }
}