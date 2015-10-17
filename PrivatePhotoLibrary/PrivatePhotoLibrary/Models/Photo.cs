using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PrivatePhotoLibrary.Models
{
    [Table("Photos")]
    public class Photo
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Path { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
