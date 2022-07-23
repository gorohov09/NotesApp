using MediatR;
using System;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteCommand : IRequest<Guid> //Результат выполнение команды - Guid
    {
        public Guid UserId { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }
    }
}
