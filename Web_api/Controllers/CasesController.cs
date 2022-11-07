using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.ProjectModel;
using System.Diagnostics;
using System.Linq.Expressions;
using Web_api.Data;
using Web_api.Models;
using Web_api.Models.Entities;

namespace Web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CasesController : ControllerBase
    {
        private readonly DataContext _context;

        public CasesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CaseRequest req)
        {
            try
            {
                var _case = new CaseEntity()
                {
                    Subject = req.Subject,
                    Descripation = req.Message

                };
                _context.Add(_case);
                await _context.SaveChangesAsync();

                var Case = await _context.Cases.Include(x => x.Status).FirstOrDefaultAsync(x => x.Id == _case.Id);
                var response = new CaseResponse
                {
                    Id = Case.Id,
                    Created = Case.Created,
                    Subject = Case.Subject,
                    Message = Case.Descripation,
                    Status = Case.Status.Name,
                };

                return new OkObjectResult(response);


            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new BadRequestResult();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cases = new List<CaseResponse>();
            foreach (var Case in await _context.Cases.Include(x => x.Status).ToListAsync())
                cases.Add(new CaseResponse
                {
                    Id = Case.Id,
                    Created = Case.Created,
                    Subject = Case.Subject,
                    Message = Case.Descripation,
                    Status = Case.Status.Name,
                });

            return new OkObjectResult(cases);
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var Case = await _context.Cases.Include(x => x.Status).FirstOrDefaultAsync(x => x.Id == id);
                if (Case != null)
                    return new OkObjectResult(new CaseResponse
                    {
                        Id = Case.Id,
                        Created = Case.Created,
                        Subject = Case.Subject,
                        Message = Case.Descripation,
                        Status = Case.Status.Name,
                    });
            }
            catch (Exception ex) { Debug.WriteLine(ex.Message); }
            return new NotFoundResult();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CaseUpdateRequest req)
        {
            try
            {
                var Case = await _context.Cases.FindAsync(id);
                Case.StatusId = req.StatusId;

                _context.Entry(Case).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                var _case = await _context.Cases.Include(x => x.Status).FirstOrDefaultAsync(x => x.Id == Case.Id);
                return new OkObjectResult(new CaseResponse
                {
                    Id = _case.Id,
                    Created = _case.Created,
                    Subject = _case.Subject,
                    Message = _case.Descripation,
                    Status = _case.Status.Name,
                });

            }
            catch(Exception ex) { Debug.WriteLine(ex.Message); }
            return new NotFoundResult();

        }
        
    }
}
