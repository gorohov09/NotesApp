using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Notes.Application.Notes.Commands.CreateNote;
using Notes.Application.Notes.Commands.DeleteNote;
using Notes.Application.Notes.Commands.UpdateNote;
using Notes.Application.Notes.Queries.GetNoteDetails;
using Notes.Application.Notes.Queries.GetNoteList;
using System;
using System.Threading.Tasks;

namespace Notes.WebApi.Controllers
{
    [Route("api/note")]
    public class NoteController : BaseController
    {
        private readonly IMapper _mapper;
        public NoteController(IMapper mapper) => _mapper = mapper;

        [HttpGet("{UserId}")]
        public async Task<ActionResult<NoteListVm>> GetAll(Guid UserId)
        {
            var query = new GetNoteListQuery
            {
                UserId = UserId,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{UserId}/{Id}")]
        public async Task<ActionResult<NoteDetailsVm>> GetById(Guid UserId, Guid Id)
        {
            var query = new GetNoteDetailsQuery
            {
                Id = Id,
                UserId = UserId,
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost("{UserId}")]
        public async Task<ActionResult<Guid>> CreateNote(Guid UserId, [FromBody]CreateNoteDto model)
        {
            if (model is null)
                return BadRequest();
            var command = _mapper.Map<CreateNoteCommand>(model);
            command.UserId = UserId;

            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("{UserId}")]
        public async Task<ActionResult<bool>> UpdateNote(Guid UserId, [FromBody] UpdateNoteDto model)
        {
            if (model is null)
                return BadRequest();
            var command = _mapper.Map<UpdateNoteCommand>(model);
            command.UserId = UserId;

            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{UserId}/{Id}")]
        public async Task<ActionResult<bool>> DeleteNote(Guid UserId, Guid Id)
        {
            var command = new DeleteNoteCommand
            {
                Id = Id,
                UserId = UserId,
            };
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
