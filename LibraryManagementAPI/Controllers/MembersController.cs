using LibraryManagementAPI.Repository;
using LibraryManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly IMemberRepository _memberRepository;

        public MembersController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }


       
        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            var response = await _memberRepository.GetAllMembers();

            return Ok(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberById(int id)
        {
            var response = await _memberRepository.GetMemberById(id);

            return Ok(response);
        }


     
        [HttpPost]
        public async Task<IActionResult> InsertMember(MemberRequest request)
        {
            var response = await _memberRepository.InsertMember(request);

            return Ok(response);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(
            int id,
            MemberRequest request)
        {
            var response =
                await _memberRepository.UpdateMember(id, request);

            return Ok(response);
        }


    
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var response =
                await _memberRepository.DeleteMember(id);

            return Ok(response);
        }


        [HttpGet("{memberId}/details")]
        public async Task<IActionResult> GetMemberDetails(int memberId)
        {
            var response =
                await _memberRepository.GetMemberDetails(memberId);

            return Ok(response);
        }
    }
}