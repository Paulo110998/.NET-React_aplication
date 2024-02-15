using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Stepforma_BR.Data.Dtos;
using Stepforma_BR.Models;

namespace Stepforma_BR.Controllers;

[ApiController]
[Route("[controller]")]
public class EstabelecimentosController : ControllerBase
{
    private ContextStep _context;
    private IMapper _mapper;

    public EstabelecimentosController(ContextStep context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CadastrarEstabelecimentos([FromBody] 
    CreateEstabelecimentoDto estabelecimentoDto) 
    {
        Estabelecimento estabelecimento = _mapper.Map<Estabelecimento>(estabelecimentoDto);
        _context.Add(estabelecimento);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetEstabelecimentoId),
            new { id = estabelecimento.Id }, estabelecimento);
    }

    [HttpGet]
    public IEnumerable<ReadEstabelecimentoDto> GetEstabelecimentos()
    {
        return _mapper.Map<List<ReadEstabelecimentoDto>>(
            _context.Estabelecimentos.ToList());
    }

    [HttpGet("{id}")]
    public IActionResult GetEstabelecimentoId(int id)
    {
        var estabelecimento = _context.Estabelecimentos.FirstOrDefault(
            estabelecimento => estabelecimento.Id == id);
        if (estabelecimento == null) NotFound();
        var estabelecimentoDto = _mapper.Map<ReadEstabelecimentoDto>(estabelecimento);
        return Ok(estabelecimentoDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateEstabelecimentos(int id,
        [FromBody] UpdateEstabelecimentoDto estabelecimentoDto)
    {
        var estabelecimento = _context.Estabelecimentos.FirstOrDefault(
            estabelecimento => estabelecimento.Id == id);
        if (estabelecimento == null) NotFound();

        _mapper.Map(estabelecimentoDto, estabelecimento);
        _context.SaveChanges();
        return NoContent();

    }

    [HttpPatch("{id}")]
    public IActionResult UpdateEstabelecimentosPatch(int id,
        JsonPatchDocument<UpdateEstabelecimentoDto> patch)
    {
        var estabelecimento = _context.Disciplinas.FirstOrDefault(
            estabelecimento=> estabelecimento.Id == id);
        if (estabelecimento == null) NotFound();

        var estabelecimentoUpdate = _mapper.Map<UpdateEstabelecimentoDto>(estabelecimento);

        patch.ApplyTo(estabelecimentoUpdate, ModelState);

        if (!TryValidateModel(estabelecimentoUpdate))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(estabelecimentoUpdate, estabelecimento);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteEstabelecimento(int id)
    {
        var estabelecimento = _context.Disciplinas.FirstOrDefault(
            estabelecimento => estabelecimento.Id == id);
        if (estabelecimento == null) NotFound();

        _context.Remove(estabelecimento);
        _context.SaveChanges();
        return NoContent();

    }
}
