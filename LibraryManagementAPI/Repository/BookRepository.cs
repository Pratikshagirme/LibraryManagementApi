using Dapper;
using LibraryManagementAPI.Helpers;
using LibraryManagementAPI.Interface;
using LibraryManagementAPI.Models;
using System.Data;

namespace LibraryManagementAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DatabaseConnection _dbConnection;
        public BookRepository(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<CommonResponse> GetAllBooks()
        {
            CommonResponse response = new CommonResponse();
            var con =  _dbConnection.GetConnectionString();
            var result = await con.QueryAsync<Book>("GetAllBooks", commandType: System.Data.CommandType.StoredProcedure);
            response.StatusCode = 200;
            response.Message = "Books retrieved successfully";
            response.Data = result;
            return response;

        }
        public async Task<CommonResponse> GetBookById(int id)
        {
            CommonResponse response = new CommonResponse();
            var con =  _dbConnection.GetConnectionString();
            var result = await con.QueryFirstOrDefaultAsync<Book>("GetBookById", new
            {
                Id = id
            },
            commandType: CommandType.StoredProcedure
            );
            response.StatusCode = 200;
            response.Message = "Books retrieved successfully";
            response.Data = result;
            return response;
        }
        public async Task<CommonResponse> InsertBook(BookRequest request)
        {
            CommonResponse response = new CommonResponse();
            var con =  _dbConnection.GetConnectionString();
            var result = await con.QueryFirstOrDefaultAsync<CommonResponse>("InsertBook", new
            {
                request.Title,
                request.Author,
                request.Category,
                request.Quantity,
               
            },
            commandType: CommandType.StoredProcedure
            );
          

            response.StatusCode = Convert.ToInt32(result.StatusCode);
            response.Message = Convert.ToString(result.Message);
            response.Data = null;

            return response;
        }
        public async Task<CommonResponse> UpdateBook(int id, BookRequest request)
        {
            CommonResponse response = new CommonResponse();
            var con =  _dbConnection.GetConnectionString();
            var result = await con.QueryFirstOrDefaultAsync("UpdateBook", new
            {
                Id = id,
                request.Title,
                request.Author,
                request.Category,
                request.Quantity,
            },
            commandType: CommandType.StoredProcedure
            );
            response.StatusCode = Convert.ToInt32(result.StatusCode);
            response.Message = Convert.ToString(result.Message);
            response.Data = null;
            return response;
        }
        public async Task<CommonResponse> DeleteBook(int id)
        {
            CommonResponse response = new CommonResponse();
            var con =  _dbConnection.GetConnectionString();
            var result = await con.QueryFirstOrDefaultAsync("DeleteBook", new
            {
                Id = id
            },
            commandType: CommandType.StoredProcedure
            );
            response.StatusCode = Convert.ToInt32(result.StatusCode);
            response.Message = Convert.ToString(result.Message);
            response.Data = null;
            return response;
        }
        public async Task<CommonResponse> SearchBooks(string search)
        {
            CommonResponse response = new CommonResponse();

            using var con = _dbConnection.GetConnectionString();

            var result = await con.QueryAsync<Book>("SearchBooks",
                new
                {
                    Search = search
                },
                commandType: CommandType.StoredProcedure
            );

            response.StatusCode = 200;
            response.Message = "Books retrieved successfully";
            response.Data = result;

            return response;
        }
    }
}
