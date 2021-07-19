using AutoMapper;
using Data.Entities;
using DesafioTecnico.Validators;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Threading.Tasks;

namespace DesafioTecnico.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FilmeController : ControllerBase
    {
        private readonly FilmeServices _services;
        private readonly IMapper _mapper;
        public readonly FilmeValidator _validator;

        public FilmeController(FilmeServices services, IMapper mapper, FilmeValidator validator)
        {
            _services = services;
            _mapper = mapper;
            _validator = validator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarFilmePorId(int id)
        {
            try
            {
                var filme = await _services.ListarFilmeCadastradoPorIdAsync(id);
                var filmesDto = _mapper.Map<FilmeDto[]>(filme);

                if (filmesDto is not null)
                    return Ok(filmesDto);

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro não catalogado: {ex}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarFilmesCadastrados()
        {
            try
            {
                var filmes = await _services.ListarFilmesCadastradosAsync();
                var filmesDto = _mapper.Map<FilmeDto[]>(filmes);

                if (filmesDto is not null)
                    return Ok(filmesDto);

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro não catalogado: {ex}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> AlterarFilmeCadastrado([FromBody] FilmeDto filmeDto)
        {
            try
            {
                // Processo de validação através de Fluent Validation
                var resultValidation = await _validator.ValidateAsync(filmeDto);
                if (!resultValidation.IsValid) return BadRequest();

                var filme = _mapper.Map<Filme>(filmeDto);
                var result = await _services.AlterarFilmeCadastradoAsync(filme);

                if (result is not null)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro não catalogado: {ex}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarNovoFilme([FromBody] FilmeDto filmeDto)
        {
            try
            {
                var resultValidation = await _validator.ValidateAsync(filmeDto);
                if (!resultValidation.IsValid) return BadRequest();

                var filme = _mapper.Map<Filme>(filmeDto);
                var result = await _services.CadastrarNovoFilmeAsync(filme);

                if (result is not null)
                {
                    // Retorno com status 201 (created) com uri para consulta e objeto
                    var uri = Url.Action("BuscarFilmesPorId", new { id = result.Id });
                    return Created(uri, result);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro não catalogado: {ex}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoverFilmes([FromBody] params FilmeDto[] filmesDto)
        {
            try
            {
                var filmes = _mapper.Map<Filme[]>(filmesDto);

                var result = await _services.RemoverFilmesAsync(filmes);

                filmesDto = _mapper.Map<FilmeDto[]>(filmes);

                if (result is not null)
                    return Ok(filmesDto);

                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro não catalogado: {ex}");
            }
        }
    }
}