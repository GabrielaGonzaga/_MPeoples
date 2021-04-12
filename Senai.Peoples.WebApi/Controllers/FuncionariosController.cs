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
    }
}
