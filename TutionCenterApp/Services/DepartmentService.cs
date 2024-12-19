using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutionCenterApp.DataBase;
using TutionCenterApp.Entity;
using TutionCenterApp.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TutionCenterApp.Services
{
    public interface IDepartmentService
    {
        IList<DepartmentReadModel> Get(DepartmentQueryModel query);

         DepartmentModel Get(Guid id);

         DepartmentModel Insert(DepartmentModel model);

         DepartmentModel Update(DepartmentModel model);

         void Delete(Guid id);






    }
    public class DepartmentService : IDepartmentService
    {
        private readonly TutionDbContext _context;
        private readonly IMapper _mapper;
        public DepartmentService(TutionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<DepartmentReadModel> Get(DepartmentQueryModel query)
        {
            List<DepartmentReadModel> readList = new List<DepartmentReadModel>();
            var dept = _context.Set<Department>().AsNoTracking().AsQueryable();
            if (query != null)
            {
                if (query.Id.HasValue)
                {
                    dept = dept.Where(dept => dept.Id == query.Id);
                }
                if (!string.IsNullOrEmpty(query.Name))
                {
                    dept = dept.Where(dept => dept.Name == query.Name);
                }
            }
            readList = dept.Select(dept => new DepartmentReadModel()
            {
                Id = dept.Id,
                Name = dept.Name,

            }).ToList();
            return readList;

        }

        public DepartmentModel Get(Guid id)
        {
            Department dept = _context.Set<Department>().FirstOrDefault(dept => dept.Id == id);
            return _mapper.Map<DepartmentModel>(dept);
        }

        public DepartmentModel Insert(DepartmentModel model)
        {
            Department dept = _mapper.Map<Department>(model);
            dept.Id = Guid.NewGuid();
            _context.Set<Department>().Add(dept);
            _context.SaveChanges();
            return _mapper.Map<DepartmentModel>(dept);
        }

        public DepartmentModel Update(DepartmentModel model)
        {
            Department dept = _mapper.Map<Department>(model);
            _context.Set<Department>().Update(dept);
            _context.SaveChanges();
            return _mapper.Map<DepartmentModel>(dept);

        }
        public  void Delete(Guid id)
        {
            Department dept = _context.Set<Department>().FirstOrDefault(dept => dept.Id == id);
            _context.Set<Department>().Remove(dept);
             


        }
    }
}
