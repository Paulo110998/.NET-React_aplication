using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Stepforma_BR.Data.Dtos;
using Stepforma_BR.Models;
using System.Text.Json;

namespace Stepforma_BR.Controllers;

[ApiController]
[Route("[controller]")]
public class TurmasController : ControllerBase
{
    private ContextStep _context;
    private IMapper _mapper;

    public TurmasController(ContextStep context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult CadastrarTurma([FromBody] CreateTurmaDto turmaDto)
    {
        Turma turma = _mapper.Map<Turma>(turmaDto);
        _context.Add(turma);
        _context.SaveChanges();
        return CreatedAtAction(nameof(BuscarTurmaId),
            new { id = turma.Id }, turma);
        
    }

    [HttpGet]
    public IEnumerable<ReadTurmaDto> BuscarTurmas() 
    {
        return _mapper.Map<List<ReadTurmaDto>>(
            _context.Turmas.ToList());
    
    }

    [HttpGet("{id}")]
    public IActionResult BuscarTurmaId(int id)
    {
        var turma = _context.Turmas.FirstOrDefault(turma => turma.Id == id);
        if (turma == null) NotFound();
        var turmaDto = _mapper.Map<ReadTurmaDto>(turma);
        return Ok(turmaDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateTurmas(int id,
        [FromBody] UpdateTurmaDto turmaDto)
    {
        var turma = _context.Turmas.FirstOrDefault(
            turma => turma.Id == id);
        if (turma == null) NotFound();
        
        _mapper.Map(turmaDto, turma);
        _context.SaveChanges();
        return NoContent();

    }

    [HttpPatch("{id}")]
    public IActionResult UpdateTurmasPatch(int id,
        JsonPatchDocument<UpdateTurmaDto> patch)
    {
        var turma = _context.Turmas.FirstOrDefault(
            turma => turma.Id == id);
        if(turma == null) NotFound();

        var turmaUpdate = _mapper.Map<UpdateTurmaDto>(turma);

        patch.ApplyTo(turmaUpdate, ModelState);

        if (!TryValidateModel(turmaUpdate))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(turmaUpdate, turma);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTurma(int id)
    {
        var turma = _context.Turmas.FirstOrDefault(
            turma => turma.Id == id);
        if (turma == null) NotFound();

        _context.Remove(turma);
        _context.SaveChanges();
        return NoContent();

    }
}
