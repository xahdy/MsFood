using AutoMapper;
using Marketplace.Domain.Interfaces;
using Marketplace.Domain.Models;
using Marketplace.Domain.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Marketplace.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PratoController : ControllerBase
    {
        private readonly IRepository<Prato> _pratoRepository;
        private readonly ILogger<PratoController> _logger;
        private readonly IMapper _mapper;

        public PratoController(IRepository<Prato> pratoRepository, ILogger<PratoController> logger, IMapper mapper)
        {
            _pratoRepository = pratoRepository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet()]
        [Tags("Pratos")]
        public async Task<ActionResult> RecuperarTodos()
        {
            try
            {
                var listaPratos = await _pratoRepository.GetAllAsync();
                var listaResultado = _mapper.Map<List<PratoDto>>(listaPratos);
                return Ok(listaResultado);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception : {ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("{pratoId}")]
        [Tags("Pratos")]
        public async Task<ActionResult> RecuperarPorId([FromRoute] int pratoId)
        {
            try
            {
                var pratoRecuperado = await _pratoRepository.GetByIdAsync(pratoId);
                if (pratoRecuperado is null)
                {
                    return BadRequest("Prato não encontrado");
                }
                var resultado = _mapper.Map<PratoDto>(pratoRecuperado);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception : {ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("{restauranteId}")]
        [Tags("Pratos")]
        public async Task<ActionResult> RecuperarPratoPorRestaurante([FromRoute] int restauranteId)
        {
            try
            {
                var listaPratos = await _pratoRepository.FindAsync(x => x.RestauranteId == restauranteId);
                if (!listaPratos.Any())
                {
                    return NoContent();
                }
                var resultado = _mapper.Map<List<PratoDto>>(listaPratos);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception : {ex.Message}");
                return StatusCode(500);
            }
        }

    }
}
