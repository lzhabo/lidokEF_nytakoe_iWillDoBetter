using System;
using System.Linq;

namespace ShopBook
{
    class Program
    {
        static void Main(string[] args)
        {
            /*using (booksContext db = new booksContext())
            {
                Author a1 = new Author { Name = "au1", LastName = "au1" },
                       a2 = new Author { Name = "au2", LastName = "au2" },
                       a3 = new Author { Name = "au3", LastName = "au3" },
                       a4 = new Author { Name = "au4", LastName = "au4" },
                       a5 = new Author { Name = "au15", LastName = "au5" };
                db.Authors.AddRange(a1,a2,a3,a4,a5);
                //db.SaveChanges();

                Genre g1 = new Genre { Designation = "g1" },
                      g2 = new Genre { Designation = "g2" },
                      g3 = new Genre { Designation = "g3" },
                      g4 = new Genre { Designation = "g4" },
                      g5 = new Genre { Designation = "g5" };
                db.Genres.AddRange(g1,g2,g3,g4,g5);
                //db.SaveChanges();

                Book b1 = new Book { Title = "Анна Каренина'", Price = 125, AutorId = 3, GenreId = 1 },
                     b2 = new Book { Title = "book2", Price = 123, AutorId = 1, GenreId = 1 },
                     b3 = new Book { Title = "book3", Price = 150, AutorId = 1, GenreId = 1 },
                     b4 = new Book { Title = "book4", Price = 350, AutorId = 1, GenreId = 1 },
                     b5 = new Book { Title = "book5", Price = 480, AutorId = 1, GenreId = 1 },
                     b6 = new Book { Title = "book6", Price = 235, AutorId = 1, GenreId = 1 },
                     b7 = new Book { Title = "book7", Price = 124, AutorId = 1, GenreId = 1 },
                     b8 = new Book { Title = "book8", Price = 723, AutorId = 1, GenreId = 1 };

                db.Books.AddRange(b1,b2,b3,b4,b5,b6,b7,b8);
                //db.SaveChanges();

                Customer c1 = new Customer { Name = "person1", LastName = "person1", Address = "kudikina gora 12, kv 5", Phone = "38000000000" };

                //c2 = new Customer { Name = "reson2", Address = "kudikina gora 12, kv 6", Phone = "3800000123000" },
                //c3 = new Customer { Name = "reson3", Address = "kudikina gora 12, kv 7", Phone = "235r3565" },
                //c = new Customer { Name = "reson4", Address = "kudikina gora 12, kv 8", Phone = "6786798" },
                //c4 = new Customer { Name = "reson5", Address = "kudikina gora 12, kv 9", Phone = "38000000000" },
                //c5 = new Customer { Name = "reson6", Address = "kudikina gora 12, kv 1", Phone = "34254" },
                //c6 = new Customer { Name = "reson7", Address = "kudikina gora 12, kv 2", Phone = "38000000000" },
                //c7 = new Customer { Name = "reson8", Address = "kudikina gora 12, kv 3", Phone = "5445454" },
                //c8 = new Customer { Name = "reson9", Address = "kudikina gora 12, kv 4", Phone = "545343" };

                // db.Customers.AddRange(c1,c2,c3,c4,c5,c6,c7,c8);
                db.Customers.Add(c1);
                db.SaveChanges();

                Console.WriteLine("everything is working! yaaaaay");


            }*/

            using (booksContext db = new booksContext())
            {
                
                var authors = db.Authors.Where(a=> a.Name == "au1").ToList();
                Console.WriteLine("Au1");
                foreach (var au in authors)
                {
                    Console.WriteLine($"{au.Id}. {au.Name} {au.LastName}");
                }

                Console.WriteLine();

                var genres = db.Genres.ToList();
                Console.WriteLine("Genres");
                foreach (var g in genres)
                {
                    Console.WriteLine($"{g.Id}. {g.Designation}");
                }

                   
                var books = from book in db.Books
                             join autor in db.Authors on book.AutorId equals autor.Id
                             join genre in db.Genres on book.AutorId equals genre.Id
                             
                             select new
                             {
                                 Title = book.Title,
                                 Autor = autor.Name + " " + autor.LastName,
                                 Genre = genre.Designation,
                                 Price = book.Price
                             };
                int i =1;
                Console.WriteLine();
                foreach (var b in books)
                {
                    
                    Console.WriteLine($"{i++}. {b.Title} - {b.Autor} ({b.Price})");
                }


            }
            Console.ReadLine();
        }
    }
}
