using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Repository.Contracts;
using Projeto.Repository.Entities;
using Projeto.Services.Models;

namespace Projeto.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncaoController : ControllerBase
    {
        private readonly IFuncaoRepository funcaoRepository;
        public FuncaoController(IFuncaoRepository funcaoRepository)
        {
            this.funcaoRepository = funcaoRepository;
        }

        [HttpPost]
        public IActionResult Post(FuncaoCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var funcao = new Funcao();
                    funcao.Descricao = model.Descricao;

                    funcaoRepository.Inserir(funcao);

                    var result = new
                    {
                        mensagem = "Função cadastrada comsucesso.",
                        funcao = funcao
                    };

                    return Ok(result);

                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            } else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put(FuncaoEdicaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var funcao = funcaoRepository.ObterPorId(model.IdFuncao);

                    if (funcao != null)
                    {
                        funcao.Descricao = model.Descricao;

                        funcaoRepository.Atualizar(funcao);

                        var result = new
                        {
                            mensagem = "Função atualizada com sucesso",
                            funcao = funcao
                        };

                        return Ok(result);
                    } else
                    {
                        return UnprocessableEntity("Id da função não foi encontrada no sistema.");
                    }
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            } else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var funcao = funcaoRepository.ObterPorId(id);

                if (funcao != null)
                {
                    funcaoRepository.Excluir(funcao);
                    return Ok("Função excluída com sucesso.");

                } else
                {
                    return UnprocessableEntity("Id da Função não foi encontardo com sucesso.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var lista = funcaoRepository.ConsultarTodos();

                if (lista != null && lista.Count > 0)
                {
                    return Ok(lista);
                } else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var funcao = funcaoRepository.ObterPorId(id);

                if (funcao != null)
                {
                    return Ok(funcao);
                } else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}


