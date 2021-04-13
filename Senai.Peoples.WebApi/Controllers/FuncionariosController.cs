using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/Funcionarios
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class FuncionariosController : ControllerBase
    {

        /// <summary>
        /// Objeto _FuncionarioRepository que irá receber todos os métodos definidos na interface IFuncionarioRepository
        /// </summary>
        private IFuncionarioRepository _funcionarioRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _FuncionarioRepository para que haja a referência aos métodos no repositório
        /// </summary>
        public FuncionariosController()
        {
            _funcionarioRepository = new FuncionariosRepository();
        }


        /// <summary>
        /// Lista todos os funcionários
        /// </summary>
        /// <returns>Uma lista de funcionários e um status code</returns>
        /// http://localhost:18442/api/Funcionarios
        [HttpGet]
        public IActionResult Get()
        {
            // Cria uma lista nomeada listaFuncionarios para receber os dados
            List<FuncionarioDomain> listaFuncionario = _funcionarioRepository.ListarTodos();

            // Retorna o status code 200 (Ok) com a lista de gêneros no formato JSON
            return Ok(listaFuncionario);
        }


        /// <summary>
        /// Cadastra um novo funcionário
        /// </summary>
        /// <param name="novoFuncionario">Objeto novoFuncionario recebido na requisição</param>
        /// <returns>Um status code 201 - Created</returns>
        /// http://localhost:5000/api/Funcionarios
        [HttpPost]
        public IActionResult Post(FuncionarioDomain novoFuncionario)
        {
            // Faz a chamada para o método .Cadastrar()
            _funcionarioRepository.Cadastrar(novoFuncionario);

            // Retorna um status code 201 - Created
            return StatusCode(201);
        }


        /// <summary>
        /// Busca um funcionário através do seu id
        /// </summary>
        /// <param name="id">id do funcionário que será buscado</param>
        /// <returns>Um funcionário buscado ou NotFound caso nenhum funcionário seja encontrado</returns>
        /// http://localhost:5000/api/Funcionarios/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto funcionarioBuscado que irá receber o funcionário buscado no banco de dados
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            // Verifica se nenhum funcionário foi encontrado
            if (funcionarioBuscado == null)
            {
                // Caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                return NotFound("Nenhum funcionário foi encontrado!");
            }

            // Caso seja encontrado, retorna o funcionário buscado com um status code 200 - Ok
            return Ok(funcionarioBuscado);
        }



        /// <summary>
        /// Atualiza um funcionário existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="id">id do funcionário que será atualizado</param>
        /// <param name="funcionarioAtualizado">Objeto funcionarioAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        /// http://localhost:5000/api/funcionarios/3
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, FuncionarioDomain funcionarioAtualizado)
        {
            // Cria um objeto funcionarioBuscado que irá receber o funcionário buscado no banco de dados
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para apresentar que houve erro
            if (funcionarioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Funcionário não encontrado!",
                        erro = true
                    }
                    );
            }

            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o método .AtualizarIdUrl()
                _funcionarioRepository.AtualizarIdUrl(id, funcionarioAtualizado);

                // Retorna um status code 204 - No Content
                return NoContent();
            }
            // Caso ocorra algum erro
            catch (Exception erro)
            {
                // Retorna um status 400 - BadRequest e o código do erro
                return BadRequest(erro);
            }
        }



        /// <summary>
        /// Atualiza um funcionário existente passando o seu id pelo corpo da requisição
        /// </summary>
        /// <param name="funcionarioAtualizado">Objeto funcionarioAtualizado com as novas informações</param>
        /// <returns>Um status code</returns>
        [HttpPut]
        public IActionResult PutIdBody(FuncionarioDomain funcionarioAtualizado)
        {
            // Cria um objeto funcionarioBuscado que irá receber o funcionário buscado no banco de dados
            FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(funcionarioAtualizado.idFuncionario);

            // Verifica se algum funcionário foi encontrado
            // ! -> negação (não)
            if (funcionarioBuscado != null)
            {
                // Se sim, tenta atualizar o registro
                try
                {
                    // Faz a chamada para o método .AtualizarIdCorpo()
                    _funcionarioRepository.AtualizarIdCorpo(funcionarioAtualizado);

                    // Retorna um status code 204 - No Content
                    return NoContent();
                }
                // Caso ocorra algum erro
                catch (Exception erro)
                {
                    // Retorna um BadRequest e o código do erro
                    return BadRequest(erro);
                }
            }

            // Caso não seja encontrado, retorna NotFoun com uma mensagem personalizada
            return NotFound
                (
                    new
                    {
                        mensagem = "Funcionário não encontrado!"
                    }
                );
        }




        /// <summary>
        /// Deleta um funcionário existente
        /// </summary>
        /// <param name="id">id do funcionário que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// http://localhost:5000/api/funcionarios/4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar()
            _funcionarioRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return StatusCode(204);
        }
    }
}




    

