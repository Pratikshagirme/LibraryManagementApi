using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Interface
{
    public interface IBorrowingRepository
    {
        Task<CommonResponse> BorrowBook(int bookId, int memberId);
        Task<CommonResponse> ReturnBook(int borrowingId);
        Task<CommonResponse> GetAllBorrowings();
        Task<CommonResponse> GetMemberBorrowingHistory(int memberId);
       
        
    }
}
