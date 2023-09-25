using AutoMapper;
using Cadastro.Domain.Interfaces;
using Cadastro.Domain.Models;
using Cadastro.Domain.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Cadastro.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestauranteController : ControllerBase
    {
        private readonly IRepository<Restaurante> _restauranteRepository;
        private readonly IRepository<Prato> _pratoRepository;
        private readonly ILogger<RestauranteController> _logger;
        private readonly IMapper _mapper;

        public RestauranteController(IRepository<Restaurante> restauranteRepository, IRepository<Prato> pratoRepository, ILogger<RestauranteController> logger, IMapper mapper)
        {
            _restauranteRepository = restauranteRepository;
            _pratoRepository = pratoRepository;
            _logger = logger;
            _mapper = mapper;
        }

        #region RESTAURANTE
        [HttpGet()]
        [Tags("Restaurantes")]
        public async Task<ActionResult> RecuperarTodos()
        {
            try
            {
                var listaRestaurantes = await _restauranteRepository.GetAllAsync();
                var listaResultado = _mapper.Map<List<RestauranteDto>>(listaRestaurantes);
                return Ok(listaResultado);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception : {ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpGet("{restauranteId}")]
        [Tags("Restaurantes")]
        public async Task<ActionResult> RecuperarPorId([FromRoute] int restauranteId)
        {
            try
            {
                var restauranteRecuperado = await _restauranteRepository.GetByIdAsync(restauranteId);
                if (restauranteRecuperado is null)
                {
                    return BadRequest("Restaurante não encontrado");
                }
                var resultado = _mapper.Map<RestauranteDto>(restauranteRecuperado);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception : {ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpPost()]
        [Tags("Restaurantes")]
        public async Task<ActionResult> Cadastrar([FromBody] RestauranteDto restauranteDto)
        {
            try
            {
                HttpResponseMessage response = null;
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://viacep.com.br/");
                    response = await client.GetAsync($"/ws/{restauranteDto.Localizacao.Cep}/json/");
                }
                var buscaEndereco = await response.Content.ReadAsStringAsync();
                var enderecoEncontrado = JsonSerializer.Deserialize<EnderecoEncontrado>(buscaEndereco);

                restauranteDto.Localizacao.CompletarLocalizacao(enderecoEncontrado);

                var restauranteParaAdicionar = _mapper.Map<Restaurante>(restauranteDto);
                await _restauranteRepository.AddAsync(restauranteParaAdicionar);
                await _restauranteRepository.SaveChangesAsync();


                return Created("", restauranteDto);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception : {ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpPut("{restauranteId}")]
        [Tags("Restaurantes")]
        public async Task<ActionResult> Atualizar([FromRoute] int restauranteId, [FromBody] RestauranteDto restauranteDto)
        {
            try
            {
                var restauranteRecuperado = await _restauranteRepository.GetByIdAsync(restauranteId);

                if (restauranteRecuperado is null)
                {
                    return BadRequest("Restaurante não encontrado");
                }

                restauranteRecuperado.AtualizarRestaurante(restauranteDto);

                _restauranteRepository.Update(restauranteRecuperado);
                await _restauranteRepository.SaveChangesAsync();


                return Ok(restauranteDto);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception : {ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpDelete("{restauranteId}")]
        [Tags("Restaurantes")]
        public async Task<ActionResult> Deletar([FromRoute] int restauranteId)
        {
            try
            {
                var restauranteRecuperado = await _restauranteRepository.GetByIdAsync(restauranteId);

                if (restauranteRecuperado is null)
                {
                    return BadRequest("Restaurante não encontrado");
                }

                restauranteRecuperado.MarcarDeletado();

                _restauranteRepository.Update(restauranteRecuperado);
                await _restauranteRepository.SaveChangesAsync();


                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception : {ex.Message}");
                return StatusCode(500);
            }
        }
        #endregion

        #region Pratos
        [HttpGet("{restauranteId}/pratos")]
        [Tags("Pratos")]
        public async Task<ActionResult> RecuperarPratosRestaurante([FromRoute] int restauranteId)
        {
            try
            {
                var listaPratos = await _pratoRepository.FindAsync(x => x.RestauranteId == restauranteId);
                var listaResultado = _mapper.Map<List<PratoDto>>(listaPratos);
                return Ok(listaResultado);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception : {ex.Message}");
                return StatusCode(500);
            }
        }
        [HttpPost("{restauranteId}/pratos")]
        [Tags("Pratos")]
        public async Task<ActionResult> CadastrarPrato([FromRoute] int restauranteId, [FromBody] PratoDto pratoDto)
        {
            try
            {
                var restauranteRecuperado = await _restauranteRepository.GetByIdAsync(restauranteId);

                if (restauranteRecuperado is null)
                {
                    return BadRequest("Restaurante não encontrado");
                }

                var pratoParaAdicionar = _mapper.Map<Prato>(pratoDto);
                pratoParaAdicionar.DefinirRestaurante(restauranteRecuperado);

                await _pratoRepository.AddAsync(pratoParaAdicionar);
                await _pratoRepository.SaveChangesAsync();


                return Created("", pratoDto);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception : {ex.Message}");
                return StatusCode(500);
            }
        }
        [HttpPut("{restauranteId}/pratos/{pratoId}")]
        [Tags("Pratos")]
        public async Task<ActionResult> AtualizarPrato([FromRoute] int restauranteId, [FromRoute] int pratoId, [FromBody] PratoDto pratoDto)
        {
            try
            {
                var restauranteRecuperado = await _restauranteRepository.GetByIdAsync(restauranteId);

                if (restauranteRecuperado is null)
                {
                    return BadRequest("Restaurante não encontrado");
                }
                var pratoRecuperado = await _pratoRepository.GetByIdAsync(pratoId);

                if (pratoRecuperado is null)
                {
                    return BadRequest("Prato não encontrado");
                }

                pratoRecuperado.AtualizarPrato(pratoDto);

                _pratoRepository.Update(pratoRecuperado);
                await _pratoRepository.SaveChangesAsync();


                return Ok(pratoDto);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception : {ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpDelete("{restauranteId}/pratos/{pratoId}")]
        [Tags("Pratos")]
        public async Task<ActionResult> DeletarPrato([FromRoute] int restauranteId, [FromRoute] int pratoId)
        {
            try
            {
                var restauranteRecuperado = await _restauranteRepository.GetByIdAsync(restauranteId);

                if (restauranteRecuperado is null)
                {
                    return BadRequest("Restaurante não encontrado");
                }

                var pratoRecuperado = await _pratoRepository.GetByIdAsync(pratoId);

                if (pratoRecuperado is null)
                {
                    return BadRequest("Prato não encontrado");
                }

                pratoRecuperado.MarcarDeletado();

                _pratoRepository.Update(pratoRecuperado);
                await _pratoRepository.SaveChangesAsync();


                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exception : {ex.Message}");
                return StatusCode(500);
            }
        }
        #endregion
    }
}
