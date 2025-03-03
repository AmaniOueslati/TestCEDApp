namespace WebApi.Services;

using WebApi.Entities;
using WebApi.Models.Interns;

public interface IInternService
{
    IEnumerable<Intern> GetAll();
    Intern GetById(int id);
    void Create(CreateRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
}

