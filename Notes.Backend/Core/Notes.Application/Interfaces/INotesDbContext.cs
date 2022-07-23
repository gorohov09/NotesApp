using Microsoft.EntityFrameworkCore;
using Notes.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Notes.Application.Interfaces
{
    public interface INotesDbContext
    {
        DbSet<Note> Notes { get; set; } //Коллекция всех сущностей в контексте
        Task<int> SaveChangesAsync(CancellationToken cancellationToken); //Сохранение изменение контекста в БД
    }
}
