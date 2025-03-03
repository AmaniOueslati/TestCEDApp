using AutoMapper;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Interns;

namespace WebApi.Services
{
    public class InternService : IInternService
    {
        private DataContext _context;
        private readonly IMapper _mapper;

        public InternService(
            DataContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<Intern> GetAll()
        {
            return _context.Interns;
        }

        public Intern GetById(int id)
        {
            return getIntern(id);
        }

        public void Create(CreateRequest model)
        {
            // validate
            if (_context.Interns.Any(x => x.Email == model.Email))
                throw new AppException("Intern with the email '" + model.Email + "' already exists");

            // map model to new user object
            var Intern = _mapper.Map<Intern>(model);

            // save user
            _context.Interns.Add(Intern);
            _context.SaveChanges();
        }

        public void Update(int id, UpdateRequest model)
        {
            var intern = getIntern(id);

            // validate
            if (model.Email != intern.Email && _context.Interns.Any(x => x.Email == model.Email))
                throw new AppException("Intern with the email '" + model.Email + "' already exists");

            // copy model to user and save
            _mapper.Map(model, intern);
            _context.Interns.Update(intern);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var intern = getIntern(id);
            _context.Interns.Remove(intern);
            _context.SaveChanges();
        }

        // helper methods

        private Intern getIntern(int id)
        {
            var intern = _context.Interns.Find(id);
            if (intern == null) throw new KeyNotFoundException("Intern not found");
            return intern;
        }
    }
}
