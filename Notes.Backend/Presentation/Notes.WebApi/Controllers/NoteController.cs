using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.Queries.GetNoteList;
using System.Threading.Tasks;

namespace Notes.WebApi.Controllers
{
    [Route("api/note")]
    public class NoteController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<NoteListVm>> GetAll()
        {
            var query = new GetNoteListQuery
            {
                UserId = UserId,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
