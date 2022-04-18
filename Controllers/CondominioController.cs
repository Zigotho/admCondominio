using System.Threading.Tasks;
using admCondominio.Data;
using admCondominio.Models;
using admCondominio.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace admCondominio.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class CondominioController : ControllerBase
    {
        [HttpGet("")]
        public async Task<IActionResult> GetAsync(
            [FromServices] AppDbContext context)
        {
            var condominios = await context.Condominios.AsNoTracking().ToListAsync();
            return await Task.FromResult<ActionResult>(Ok(condominios));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIDAsync(
            [FromServices] AppDbContext context, int id)
        {
            var condominio = await context.Condominios.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return condominio != null
                ? await Task.FromResult<ActionResult>(Ok(condominio))
                : NotFound();
        }

        [HttpPost("")]
        public async Task<IActionResult> PostAsync(
            [FromServices] AppDbContext context,
            [FromBody] CreateCondominioViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var condominio = new Condominio
            {
                Nome = model.Nome,
                Bairro = model.Bairro
            };

            try
            {
                context.Condominios.Add(condominio);
                await context.SaveChangesAsync();

                return await Task.FromResult<ActionResult>(Created($"/v1/condominio/{condominio.Id}", condominio));
            }
            catch (DbUpdateException)
            {
                return BadRequest("Não foi possível inserir o registro.");
            }


        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromServices] AppDbContext context,
            int id,
            [FromBody] CreateCondominioViewModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            var condominio = await context.Condominios.FirstOrDefaultAsync(x => x.Id == id);

            if (condominio == null) return NotFound();

            condominio.Nome = model.Nome;
            condominio.Bairro = model.Bairro;

            try
            {
                await context.SaveChangesAsync();
                return Ok(condominio);
            }
            catch (DbUpdateException)
            {
                return BadRequest("Não foi possível atualizar o registro.");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromServices] AppDbContext context,
            int id)
        {
            var condominio = await context.Condominios.FirstOrDefaultAsync(x => x.Id == id);

            if (condominio == null) return NotFound();

            try
            {
                context.Condominios.Remove(condominio);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateException)
            {
                return BadRequest("Não foi possível remover o registro.");
            }
        }

    }
}