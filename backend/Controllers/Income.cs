using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPENDINGAPP.backend.Data;
using SPENDINGAPP.backend.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SPENDINGAPP.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly SpendingAppDbContext _context;

        public IncomeController(SpendingAppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddIncome([FromBody] Income income)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Incomes.Add(income);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIncomeById), new { id = income.IncomeId }, income);
        }

        [HttpGet]
        public async Task<IActionResult> GetIncome()
        {
            var incomes = await _context.Incomes.OrderByDescending(i => i.Date).ToListAsync();
            return Ok(incomes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncomeById(int id)
        {
            var income = await _context.Incomes.FindAsync(id);

            if (income == null)
            {
                return NotFound();
            }

            return Ok(income);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncome(int id)
        {
            var income = await _context.Incomes.FindAsync(id);
            if (income == null)
            {
                return NotFound();
            }

            _context.Incomes.Remove(income);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}



