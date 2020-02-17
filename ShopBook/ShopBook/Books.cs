using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopBook
{
    //[Table("Books")]
    public partial class Book
    {
        public Book()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public int? GenreId { get; set; }
        public int? AutorId { get; set; }

        public virtual Author Autors { get; set; }
        public virtual Genre Genres { get; set; }
        public virtual ICollection<Order> Orders { get; set; }



    }
}
