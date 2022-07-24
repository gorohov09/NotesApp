using AutoMapper;
using Notes.Application.Common.Mapping;

namespace Notes.Application.Notes.Commands.CreateNote
{
    public class CreateNoteDto : IMapWith<CreateNoteCommand>
    {
        public string Title { get; set; }

        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNoteDto, CreateNoteCommand>()
                .ForMember(createnoteCommand => createnoteCommand.Title,
                opt => opt.MapFrom(noteDto => noteDto.Title))
                .ForMember(createnoteCommand => createnoteCommand.Details,
                opt => opt.MapFrom(noteDto => noteDto.Details));
        }
    }
}
