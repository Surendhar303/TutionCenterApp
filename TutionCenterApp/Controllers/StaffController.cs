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
    public class StaffController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly TutionDbContext _context;
        public StaffController(IMapper Mapper, TutionDbContext Context)
        {
            _mapper = Mapper;
            _context = Context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<StaffReadModel> staff = new List<StaffReadModel>();
            staff = _context.Set<Staff>().AsNoTracking().Include(staff => staff.Department).Select(staff => new StaffReadModel()
            {
                Id = staff.Id,
                Name = staff.Name,
                Age = staff.Age,
                DepartmentId = staff.DepartmentId,
            }).ToList();
            return Ok(staff);

        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Staff staff = _context.Set<Staff>().FirstOrDefault(staff => staff.Id == id);
            return Ok(_mapper.Map<Staff>(staff));

        }
        [HttpPost]
        public IActionResult Post([FromBody] StaffModel model)
        {
            Staff staff = _mapper.Map<Staff>(model);
            staff.Id = Guid.NewGuid();
            _context.Set<Staff>().Add(staff);
            _context.SaveChanges();
            return Ok(_mapper.Map<StaffModel>(staff));
        }

        [HttpPut]
        public IActionResult put([FromBody] StaffModel model)
        {
            Staff staff = _mapper.Map<Staff>(model);
            _context.Set<Staff>().Update(staff);
            _context.SaveChanges();
            return Ok(_mapper.Map<StaffModel>(model));
        }
        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            Staff staff = _context.Set<Staff>().FirstOrDefault(staff => staff.Id == id);
            return Ok(staff);
        }
        [HttpGet("[action]")]
        public IActionResult GetQuery([FromQuery] StaffQueryModel query)
        {
            List<StaffReadModel> readModel = new List<StaffReadModel>();
            var staff = _context.Set<Staff>().AsNoTracking().Include(staff => staff.Department).AsQueryable();
            if (query != null)
            {
                if (query.Id.HasValue)
                {
                    staff = staff.Where(staff => staff.Id == query.Id);
                }
                if (!string.IsNullOrEmpty(query.Name))
                {
                    staff = staff.Where(staff => staff.Name == query.Name);
                }
                if (query.Age.HasValue)
                {
                    staff = staff.Where(staff => staff.Age == query.Age);
                }
                if (query.DepartmentId.HasValue)
                {
                    staff = staff.Where(staff => staff.DepartmentId == query.DepartmentId);

                }
            }
            readModel = staff.Select(staff=> new StaffReadModel()
            {
                Id = staff.Id,
                Name = staff.Name,
                Age = staff.Age,
                DepartmentId = staff.DepartmentId,
            }).ToList();
            return Ok(readModel);
        }
    }
}
