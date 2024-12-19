using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TutionCenterApp.DataBase;
using TutionCenterApp.Entity;
using TutionCenterApp.Model;
using TutionCenterApp.Services;

namespace TutionCenterApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {


        private readonly IDepartmentService _departmentService;

        
        public DepartmentController(IDepartmentService departmentService)
        {
            
            
            _departmentService = departmentService; 
        }
        [HttpGet]
        public IActionResult Get()
        {
           
            return Ok(_departmentService.Get(new DepartmentQueryModel()));
        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_departmentService.Get(id));
        }
        [HttpPost]
        public IActionResult Post([FromBody] DepartmentModel model)
        {
           
            return Ok(_departmentService.Insert(model));
        }
        [HttpPut]
        public IActionResult Put([FromBody]DepartmentModel model)
        {
           
            return Ok(_departmentService.Update(model));

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {

            _departmentService.Delete(id);
            return Ok();
        }
        [HttpGet("[action]")]
        public IActionResult GetQuery([FromQuery]DepartmentQueryModel query)
        {
            return Ok(_departmentService.Get(query));
        }

    }
}
