using AutoMapper;
using DomainApiFilmes.DesafioTecnico;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI.Exceptions;
using WebAPI.Filters;
using WebAPI.Services;
using WebAPI.Validators;

namespace WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(statusCode: 200, Type = typeof(FilmeDto))]
    [ProducesResponseType(404)]
    [ProducesResponseType(statusCode: 500, Type = typeof(ErrorResponse))]
    public class FilmeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFilmeValidator _validator;
        private readonly IFilmeApiServices _services;

        public FilmeController(IFilmeApiServices filmeApiServices, IMapper mapper, IFilmeValidator validator)
        {
            _mapper = mapper;
            _validator = validator;
            _services = filmeApiServices;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarFilmePorId(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var filme = await _services.GetByIdAsync(id);
            var filmesDto = _mapper.Map<FilmeDto[]>(filme);

            if (filmesDto is not null)
                return Ok(filmesDto);

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> BuscarFilmesCadastrados([FromQuery] FilmeFiltro filtro,
                                                                 [FromQuery] FilmeOrdem ordem,
                                                                 [FromQuery] FilmePaginacao paginacao)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var filmes = await _services.GetAllAsync(filtro, ordem, paginacao);
            var filmesDto = _mapper.Map<FilmeDto[]>(filmes);

            if (filmesDto is not null)
                return Ok(filmesDto);

            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> AlterarFilmeCadastrado([FromBody] FilmeDto filmeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            // Processo de validação através de Fluent Validation
            var resultValidation = await _validator.ValidateAsync(filmeDto);
            if (!resultValidation.IsValid) return BadRequest();

            await _services.UpdateAsync(filmeDto);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarNovoFilme([FromBody] FilmeDto filmeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var resultValidation = await _validator.ValidateAsync(filmeDto);
            if (!resultValidation.IsValid) return BadRequest();

            await _services.AddAsync(filmeDto);

            return Ok(filmeDto);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoverFilmes([FromBody] params FilmeDto[] filmesDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _services.RemoveAsync(filmesDto);

            return Ok(filmesDto);
        }
    }
}