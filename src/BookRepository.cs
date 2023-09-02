using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using VirtualDars.Demo.SQLInjection.Entities;

namespace VirtualDars.Demo.SQLInjection
{
    public interface IBookRepository
    {
        Task<Book> GetById(int id);
    }

    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _dbContext;

        public BookRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // sql injection in ADO.NET!
        /* public async Task<Book> GetById(string id)
         {
             Book book = new Book();
             using (var connection = new SqlConnection(_dbContext.Database.GetConnectionString()))
             {
                 await connection.OpenAsync();

                 using (var command = new SqlCommand($"SELECT Id, Title, Author, ISBN FROM Books WHERE Id = {id}", connection))
                 {
                     using (var reader = await command.ExecuteReaderAsync())
                     {
                         while (await reader.ReadAsync())
                         {
                             book = new Book
                             {
                                 Id = reader.GetInt32(0),
                                 Title = reader.GetString(1),
                                 Author = reader.GetString(2),
                                 ISBN = reader.GetString(3)
                             };

                             break;
                         }
                     }
                 }
             }

             return book;
         }*/

        /*public async Task<Book> GetById(string id)
        {
            Book book = null;
            using (var connection = new SqlConnection(_dbContext.Database.GetConnectionString()))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("SELECT Id, Title, Author, ISBN FROM Books WHERE Id = @id", connection))
                {
                    command.Parameters.Add(new SqlParameter("@id", DbType.Int32) { Value = id });
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            book = new Book
                            {
                                Id = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Author = reader.GetString(2),
                                ISBN = reader.GetString(3)
                            };

                            break;
                        }
                    }
                }
            }

            return book;
        }*/


        // sql injection in EFCore raw sql!
        /* public async Task<Book> GetById(string id)
         {
             return await _dbContext.Books.FromSqlRaw($"SELECT Id, Title, Author, ISBN FROM Books WHERE Id = {id}").FirstOrDefaultAsync();
         }*/

        public async Task<Book> GetById(int id)
        {
            return await _dbContext.Books.Where(b => b.Id.Equals(id)).FirstOrDefaultAsync();
        }




    }
}
