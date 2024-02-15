using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Stepforma_BR.Data.Dtos;
using Stepforma_BR.Models;
using System.Text.Json;

namespace Stepforma_BR.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriasController : ControllerBase
{
    private ContextStep _context;
    private IMapper _mapper;

    public CategoriasController(ContextStep context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CadastrarCategorias([FromBody] 
    CreateCategoriaDto categoriaDto )
    {
        Categorias categoria = _mapper.Map<Categorias>( categoriaDto );
        _context.Add(categoria);
        _context.SaveChanges();
        return CreatedAtAction(
            nameof(GetCategoriaId),
            new { id = categoria.Id }, categoria);
    }

    [HttpGet]
    public IEnumerable<ReadCategoriaDto> GetCategorias(
        [FromQuery] string? nomeTurma)
    {
        if(nomeTurma == null)
        {
            return _mapper.Map<List<ReadCategoriaDto>>(
            _context.Categorias.ToList());

        }
        return _mapper.Map<List<ReadCategoriaDto>>(
            _context.Categorias
            .Select(categorias =>
            categorias.Turma.Titulo == nomeTurma)).ToList();
    }

    [HttpGet("{id}")]
    public IActionResult GetCategoriaId(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(
            categoria => categoria.Id == id );
        if (categoria == null) NotFound();
        var categoriaDto = _mapper.Map<ReadCategoriaDto>(categoria);
        return Ok();

    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategoria(int id,
        [FromBody] UpdateCategoriaDto categoriaDto)
    {
        var categoria = _context.Categorias.FirstOrDefault(
            categoria => categoria.Id == id );
        if (categoria == null) NotFound();
        _mapper.Map(categoriaDto, categoria);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateCategoriaPacth(int id,
        JsonPatchDocument<UpdateCategoriaDto> patch)
    {
        var categoria = _context.Categorias.FirstOrDefault(
            categoria => categoria.Id == id);
        if(categoria == null) NotFound();

        // convertendo categoria para um tipo "UpdateCategoriaDto
        var updateCategoria = _mapper.Map<UpdateCategoriaDto>(categoria);

        // Se oque tem aplicado conter um modelo de estado (model)
        patch.ApplyTo(updateCategoria, ModelState);

        // Se não for valido
        if (!TryValidateModel(updateCategoria))
        {
            return ValidationProblem(ModelState);
        }

        // Se for valido
        _mapper.Map(updateCategoria, categoria);
        _context.SaveChanges();
        return NoContent();
    }

    // Método para deletar o objeto através do ID
    [HttpDelete("{id}")]
    public IActionResult DetelaCategoria(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(
            categoria => categoria.Id == id);
        if (categoria == null) return NotFound();

        _context.Remove(categoria);
        _context.SaveChanges();
        return NoContent();
    }
}
