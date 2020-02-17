using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBook
{
   // [Table("Genres")]
    public partial class Genre
    {
        public Genre()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Designation { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
