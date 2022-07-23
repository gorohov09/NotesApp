using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notes.Domain;

namespace Notes.Persistence.EntityTypeConfiguration
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(note => note.Id); //Id - первичный ключ
            builder.HasIndex(note => note.Id).IsUnique(); //Индексирование по Id(уникальный)
            builder.Property(note => note.Title).HasMaxLength(250); //Огроничение заголовка в 250 символов
        }
    }
}
