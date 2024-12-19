using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutionCenterApp.DataBase;
using TutionCenterApp.Entity;
using TutionCenterApp.Model;

namespace TutionCenterApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly TutionDbContext _context;
        public StudentController(IMapper Mapper,TutionDbContext Context)
        {
            _mapper = Mapper;
            _context = Context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            List<StudentReadModel> student = new List<StudentReadModel>();
            student = _context.Set<Student>().AsNoTracking().Include(student=>student.Department).Select(student=> new StudentReadModel()
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
                DepartmentId = student.DepartmentId,
            }).ToList();
            return Ok(student);

        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Student student = _context.Set<Student>().FirstOrDefault(student => student.Id == id);
            return Ok(_mapper.Map<Student>(student));

        }
        [HttpPost]
        public IActionResult Post([FromBody] StudentModel model)
        {
            Student student = _mapper.Map<Student>(model);
            student.Id = Guid.NewGuid();
            _context.Set<Student>().Add(student);
            _context.SaveChanges();
            return Ok(_mapper.Map<StudentModel>(model));
        }

        [HttpPut]
        public IActionResult Put([FromBody] StudentModel model)
        {
            Student student = _mapper.Map<Student>(model);
            _context.Set<Student>().Update(student);
            _context.SaveChanges();
            return Ok(_mapper.Map<StudentModel>(model));
        }
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            Student student = _context.Set<Student>().FirstOrDefault(student=>student.Id==id);
            return Ok(student);
        }
        [HttpGet("[action]")]
        public IActionResult GetQuery([FromQuery] StudentQueryModel query)
        {
            List<StudentReadModel> readModel = new List<StudentReadModel>();
            var student = _context.Set<Student>().AsNoTracking().Include(student=>student.Department).AsQueryable();
            if(query != null)
            {
                if(query.Id.HasValue)
                {
                    student = student.Where(student=>student.Id==query.Id);
                }
                if(!string.IsNullOrEmpty(query.Name))
                {
                    student = student.Where(student => student.Name == query.Name);
                }
                if (query.Age.HasValue)
                {
                    student = student.Where(student => student.Age == query.Age);
                }
                if (query.DepartmentId.HasValue)
                {
                    student = student.Where(student => student.DepartmentId == query.DepartmentId);
                }
            }
            readModel = student.Select(student=> new StudentReadModel()
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
                DepartmentId = student.DepartmentId,
            }).ToList();
            return Ok(readModel);
        }

    }
}
