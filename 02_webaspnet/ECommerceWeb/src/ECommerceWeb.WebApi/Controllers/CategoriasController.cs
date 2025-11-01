using ECommerceWeb.WebApi.DataAccess;
using ECommerceWeb.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWeb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ECommerceDbContext _context;

        public CategoriasController(ECommerceDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            var categorias = await _context.Categorias.ToListAsync(); //select a tabla categorias
            return Ok(categorias);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoria([FromBody] Categoria categoria)
        {
            _context.Categorias.Add(categoria); // INSERT INTO CATEGORIAS
            await _context.SaveChangesAsync(); //confirma los datos en la DB
            //return CreatedAtAction(nameof(GetCategorias), new { id = categoria.Id }, categoria);
            return Ok();
        }

    }
}
