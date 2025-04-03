﻿using Jogos_API.Domains;
using Jogos_API.Interfaces;
using Jogos_API.Repositorys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Jogos_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoController(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_jogoRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post (IJogoRepository jogo)
        {
            try
            {
                _jogoRepository.Cadastrar(jogo);

                return StatusCode(201, jogo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, IJogoRepository jogo)
        {
            try
            {
                _jogoRepository.Atualizar(id, jogo);

                return StatusCode(204, jogo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _jogoRepository.Deletar(id);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
