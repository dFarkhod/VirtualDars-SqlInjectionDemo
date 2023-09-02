using Microsoft.AspNetCore.Mvc;

namespace VirtualDars.Demo.SQLInjection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _repo;

        public BooksController(IBookRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var foundBook = await _repo.GetById(id);
            if (foundBook == null)
                return NotFound();

            return  Ok(foundBook);
        }

    }
}
