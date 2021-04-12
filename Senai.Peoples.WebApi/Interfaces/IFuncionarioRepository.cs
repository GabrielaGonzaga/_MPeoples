using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório FuncionariosRepository
    /// </summary>
    interface IFuncionarioRepository
    {
        /// <summary>
        /// Retorna todos os funcionarios
        /// </summary>
        /// <returns>Uma lista de funcionarios</returns>
        List<FuncionarioDomain> ListarTodos();


        /// <summary>
        /// Busca um funcionário através do seu id
        /// </summary>
        /// <param name="id">id do funcionario que será buscado</param>
        /// <returns>Um objeto do tipo FuncionariosDomain que foi buscado</returns>
        FuncionarioDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo funcionário
        /// </summary>
        /// <param name="novoFuncionario">Objeto novofuncionario que será cadastrado</param>
        void Cadastrar(FuncionarioDomain novoFuncionario);


        /// <summary>
        /// Atualiza um funcionário existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="funcionario">Objeto funcionario com as novas informações</param>
        void AtualizarIdCorpo(FuncionarioDomain funcionario);

        /// <summary>
        /// Atualiza um funcionário existente passando o id pela url da requisição
        /// </summary>
        /// /// <param name="id">id do funcionário que será atualizado</param>
        /// <param name="funcionario">Objeto funcionario com as novas informações</param>
        void AtualizarIdUrl(int id, FuncionarioDomain funcionario);

        /// <summary>
        /// Deleta um funcionário
        /// </summary>
        /// <param name="id">id do funcionário que será deletado</param>
        void Deletar(int id);

    }
}
