using LibraryManagementAPI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingsController : ControllerBase
    {
        private readonly IBorrowingRepository _borrowingRepository;

        public BorrowingsController(
            IBorrowingRepository borrowingRepository)
        {
            _borrowingRepository = borrowingRepository;
        }

        [HttpPost("borrow")]
        public async Task<IActionResult> BorrowBook(
            int bookId,
            int memberId)
        {
            var response =
                await _borrowingRepository.BorrowBook(
                    bookId,
                    memberId);

            return Ok(response);
        }


        [HttpPut("return/{borrowingId}")]
        public async Task<IActionResult> ReturnBook(
            int borrowingId)
        {
            var response =
                await _borrowingRepository.ReturnBook(
                    borrowingId);

            return Ok(response);
        }


       
        [HttpGet]
        public async Task<IActionResult> GetAllBorrowings()
        {
            var response =
                await _borrowingRepository.GetAllBorrowings();

            return Ok(response);
        }


       
        [HttpGet("member/{memberId}")]
        public async Task<IActionResult> GetMemberBorrowingHistory(
            int memberId)
        {
            var response =
                await _borrowingRepository.GetMemberBorrowingHistory(
                    memberId);

            return Ok(response);
        }
    }
}