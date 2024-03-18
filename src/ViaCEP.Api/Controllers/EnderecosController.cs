using Microsoft.AspNetCore.Mvc;

namespace ViaCEP.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EnderecosController : ControllerBase
{
    private readonly ILogger<EnderecosController> _logger;
    private readonly IEnderecoService _enderecoService;

    public EnderecosController(
        ILogger<EnderecosController> logger,
        IEnderecoService enderecoService)
    {
        _logger = logger;
        _enderecoService = enderecoService;
    }

    //private readonly ApplicationContext _context;

    //public EnderecosController(ApplicationContext context)
    //{
    //    _context = context;
    //}

    //// GET: api/Enderecos
    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<Endereco>>> GetEndereco()
    //{
    //    return await _context.Endereco.ToListAsync();
    //}

    // GET: api/Enderecos/5
    [HttpGet("{cep}")]
    public async Task<ActionResult<EnderecoDto?>> GetEndereco(string cep)
    {
        return await _enderecoService.ObterEndereco(cep);
    }

    // GET: api/Enderecos/5
    //[HttpGet("{id}")]
    //public async Task<ActionResult<Endereco>> GetEndereco(long id)
    //{
    //    var endereco = await _context.Endereco.FindAsync(id);

    //    if (endereco == null)
    //    {
    //        return NotFound();
    //    }

    //    return endereco;
    //}

    // PUT: api/Enderecos/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //[HttpPut("{id}")]
    //public async Task<IActionResult> PutEndereco(long id, Endereco endereco)
    //{
    //    if (id != endereco.Id)
    //    {
    //        return BadRequest();
    //    }

    //    _context.Entry(endereco).State = EntityState.Modified;

    //    try
    //    {
    //        await _context.SaveChangesAsync();
    //    }
    //    catch (DbUpdateConcurrencyException)
    //    {
    //        if (!EnderecoExists(id))
    //        {
    //            return NotFound();
    //        }
    //        else
    //        {
    //            throw;
    //        }
    //    }

    //    return NoContent();
    //}

    // POST: api/Enderecos
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //[HttpPost]
    //public async Task<ActionResult<Endereco>> PostEndereco(Endereco endereco)
    //{
    //    _context.Endereco.Add(endereco);
    //    await _context.SaveChangesAsync();

    //    return CreatedAtAction("GetEndereco", new { id = endereco.Id }, endereco);
    //}

    // DELETE: api/Enderecos/5
    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteEndereco(long id)
    //{
    //    var endereco = await _context.Endereco.FindAsync(id);
    //    if (endereco == null)
    //    {
    //        return NotFound();
    //    }

    //    _context.Endereco.Remove(endereco);
    //    await _context.SaveChangesAsync();

    //    return NoContent();
    //}

    //private bool EnderecoExists(long id)
    //{
    //    return _context.Endereco.Any(e => e.Id == id);
    //}
}