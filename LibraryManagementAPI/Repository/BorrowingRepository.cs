using Dapper;
using LibraryManagementAPI.Helpers;
using LibraryManagementAPI.Interface;
using LibraryManagementAPI.Models;
using System.Data;

namespace LibraryManagementAPI.Repository
{
    public class BorrowingRepository:IBorrowingRepository
    {
        private readonly DatabaseConnection _dbConnection;
        public BorrowingRepository(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<CommonResponse> BorrowBook(int bookId, int memberId)
        {
            CommonResponse response = new CommonResponse();
            var con = _dbConnection.GetConnectionString();
            var result = await con.QueryFirstOrDefaultAsync<dynamic>("BorrowBook", new
            {
                BookId=bookId,
                MemberId=memberId
            }, commandType: CommandType.StoredProcedure
            );
            response.StatusCode = Convert.ToInt32(result.StatusCode);
            response.Message = Convert.ToString(result.Message);
            response.Data = null;
            return response;

        }
        public async Task<CommonResponse> ReturnBook(int borrowingId)
        {
            CommonResponse response = new CommonResponse();
            var con = _dbConnection.GetConnectionString();
            var result = await con.QueryFirstOrDefaultAsync<dynamic>("ReturnBook", new
            {
                BorrowingId=borrowingId
            }, commandType: CommandType.StoredProcedure
            );
            response.StatusCode = Convert.ToInt32(result.StatusCode);
            response.Message = Convert.ToString(result.Message);
            response.Data = null;
            return response;
        }
        public async Task<CommonResponse> GetAllBorrowings()
        {
            CommonResponse response = new CommonResponse();
            var con = _dbConnection.GetConnectionString();
            var result = await con.QueryAsync<AllBorrowingsResponse>("GetAllBorrowings", commandType: CommandType.StoredProcedure);
            response.StatusCode = 200;
            response.Message = "Borrowings retrieved successfully";
            response.Data = result;
            return response;
        }
        public async Task<CommonResponse> GetMemberBorrowingHistory(int memberId)
        {
            CommonResponse response = new CommonResponse();
            var con = _dbConnection.GetConnectionString();
            var result = await con.QueryAsync<dynamic>("GetMemberBorrowingHistory", new
            {
                MemberId=memberId
            }, commandType: CommandType.StoredProcedure);
            response.StatusCode = 200;
            response.Message = "Borrowing history retrieved successfully";
            response.Data = result;
            return response;
        }
       
        
    }
}
