using ECommerceWeb.WebApi.DataAccess;
using ECommerceWeb.WebApi.Entities;
using ECommerceWeb.WebApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWeb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _context;

        public CategoriasController(ICategoriaRepository context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            try
            {
                var categorias = await _context.ListAsync(); //select a tabla categorias
                return Ok(categorias);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "No se pudo listar los registros", Error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategoria([FromBody] Categoria categoria)
        {

            try
            {
                await _context.AddAsync(categoria);
                return CreatedAtAction(nameof(GetCategorias), new { id = categoria.Id }, categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "No se pudo crear el registro", Error = ex.Message });
            }

        }

    }
}
