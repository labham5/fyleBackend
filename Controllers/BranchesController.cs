using FyleAssignment.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FyleAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchesController(IBranchService branchService)
        {
            _branchService = branchService;
        }
        [HttpGet("autocomplete")]
        public IActionResult GetByBranch([FromQuery(Name ="q")] string branch,[FromQuery(Name = "limit")] int limit,[FromQuery(Name = "offset")] int offset)
        {

            var branches = _branchService.GetByBranch(branch, limit, offset);
            var res =new  { branches };
            return Ok(res);
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery(Name = "q")] string query, [FromQuery(Name = "limit")] int limit, [FromQuery(Name = "offset")] int offset)
        {

            var branches = _branchService.GetAll(query, limit, offset);
            var res = new { branches };
            return Ok(res);
        }
    }
}
