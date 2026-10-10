using Dapper;
using LibraryManagementAPI.Helpers;
using LibraryManagementAPI.Models;
using System.Data;

namespace LibraryManagementAPI.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly DatabaseConnection _dbConnection;

        public MemberRepository(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<CommonResponse> GetAllMembers()
        {
            CommonResponse response = new CommonResponse();
            using var con = _dbConnection.GetConnectionString();
            var members = await con.QueryAsync<MemberResponse>("GetAllMembers",commandType: CommandType.StoredProcedure);

            response.StatusCode = 200;
            response.Message = "Members retrieved successfully";
            response.Data = members;

            return response;
        }

        public async Task<CommonResponse> GetMemberById(int id)
        {
            CommonResponse response = new CommonResponse();

            using var con = _dbConnection.GetConnectionString();

            var result = await con.QueryFirstOrDefaultAsync<dynamic>("GetMemberById",
                new
                {
                    Id = id
                },
                commandType: CommandType.StoredProcedure
            );

            response.StatusCode = 200;
            response.Message = "Member retrieved successfully";
            response.Data = result;

            return response;
        }


        public async Task<CommonResponse> InsertMember(MemberRequest request)
        {
            CommonResponse response = new CommonResponse();
            using var con = _dbConnection.GetConnectionString();

            var result = await con.QueryFirstOrDefaultAsync<dynamic>("InsertMember",
                new
                {
                    request.Name,
                    request.Email,
                    request.Phone
                },
                commandType: CommandType.StoredProcedure
            );

            response.StatusCode = Convert.ToInt32(result.StatusCode);
            response.Message = Convert.ToString(result.Message);
            response.Data = null; 
           
            return response;
        }


        public async Task<CommonResponse> UpdateMember(int id,MemberRequest request)
        {
            CommonResponse response = new CommonResponse();
            using var con = _dbConnection.GetConnectionString();

            var result = await con.QueryFirstOrDefaultAsync<dynamic>("UpdateMember",
                new
                {
                    Id = id,
                    request.Name,
                    request.Email,
                    request.Phone
                },
                commandType: CommandType.StoredProcedure
            );


            response.StatusCode = Convert.ToInt32(result.StatusCode);
            response.Message = Convert.ToString(result.Message);
            response.Data = null;

            return response;
        }


        public async Task<CommonResponse> DeleteMember(int id)
        {
            CommonResponse response = new CommonResponse();
            using var con = _dbConnection.GetConnectionString();

            var result = await con.QueryFirstOrDefaultAsync("DeleteMember",
                new
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


        public async Task<CommonResponse> GetMemberDetails(int memberId)
        {
            CommonResponse response = new CommonResponse();
            using var con = _dbConnection.GetConnectionString();
            using var multi = await con.QueryMultipleAsync("GetMemberDetails",
                new
                {
                    MemberId = memberId
                },
                commandType: CommandType.StoredProcedure
            );
            var member =await multi.ReadFirstOrDefaultAsync<MemberResponse>();
            var currentBorrowings =(await multi.ReadAsync<CurrentBorrowingResponse>()).ToList();
            var borrowingHistory =(await multi.ReadAsync<BorrowingHistoryResponse>()).ToList();

            member.CurrentBorrowings = currentBorrowings;
            member.BorrowingHistory = borrowingHistory;

            response.StatusCode = 200;
            response.Message = "Member details retrieved successfully";
            response.Data = member;

            return response;
        }
    }
}