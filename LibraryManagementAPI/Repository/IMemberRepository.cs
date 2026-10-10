using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Repository
{
    public interface IMemberRepository
    {
        Task<CommonResponse> GetAllMembers();
        Task<CommonResponse> GetMemberById(int id);
        Task<CommonResponse> InsertMember(MemberRequest request);
        Task<CommonResponse> UpdateMember(int id, MemberRequest request);
        Task<CommonResponse> DeleteMember(int id);
        Task<CommonResponse> GetMemberDetails(int memberId);
    }
}
