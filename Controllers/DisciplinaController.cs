using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Stepforma_BR.Data.Dtos;
using Stepforma_BR.Models;

namespace Stepforma_BR.Controllers;

[ApiController]
[Route("[controller]")]
public class DisciplinaController : ControllerBase
{
    private ContextStep _context;
    private IMapper _mapper;
  

    public DisciplinaController(ContextStep context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CadastrarDisciplinas([FromBody] CreateDisciplinaDto disciplinaDto)
    {
        Disciplina disciplina = _mapper.Map<Disciplina>(disciplinaDto);
        _context.Add(disciplina);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetDisciplinaId),
            new { id = disciplina.Id }, disciplina);
    }

    [HttpGet]
    public IEnumerable<ReadDisciplinaDto> GetDisciplina()
    {
        return _mapper.Map<List<ReadDisciplinaDto>>(
            _context.Disciplinas.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetDisciplinaId(int id)
    {
        var disciplina = _context.Disciplinas.FirstOrDefault(
            disciplina => disciplina.Id == id);
        if (disciplina == null) NotFound();
        var disciplinaDto = _mapper.Map<ReadDisciplinaDto>(disciplina);
        return Ok(disciplinaDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDisciplinas(int id,
        [FromBody] UpdateDisciplinaDto disciplinaDto)
    {
        var disciplina = _context.Disciplinas.FirstOrDefault(
            disciplina => disciplina.Id == id);
        if (disciplina == null) NotFound();

        _mapper.Map(disciplinaDto, disciplina);
        _context.SaveChanges();
        return NoContent();

    }

    [HttpPatch("{id}")]
    public IActionResult UpdateDisciplinasPatch(int id,
        JsonPatchDocument<UpdateDisciplinaDto> patch)
    {
        var disciplina = _context.Disciplinas.FirstOrDefault(
            disciplina => disciplina.Id == id);
        if (disciplina == null) NotFound();

        var disciplinaUpdate = _mapper.Map<UpdateDisciplinaDto>(disciplina);

        patch.ApplyTo(disciplinaUpdate, ModelState);

        if (!TryValidateModel(disciplinaUpdate))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(disciplinaUpdate, disciplina);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDisciplina(int id)
    {
        var disciplina = _context.Disciplinas.FirstOrDefault(
            disciplina => disciplina.Id == id);
        if(disciplina == null) NotFound();

        _context.Remove(disciplina);
        _context.SaveChanges();
        return NoContent();

    }
}
