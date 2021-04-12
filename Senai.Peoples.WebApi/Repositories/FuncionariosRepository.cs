using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    public class FuncionariosRepository : IFuncionarioRepository
    {
                       //Criação string/ Nome do servidor/             Nome do banco de dados/ Usuário/    Senha 

        private string stringConexao = "Data Source=DESKTOP-RGIIP6F; initial catalog=M_Peoples; user Id= sa; pwd=Semprepea10";
        //WINDOWS = private string stringConexao = "Data Source=DESKTOP-RGIIP6F; initial catalog=Filmes; integrated security=true";


        public void AtualizarIdCorpo(FuncionarioDomain funcionario)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, FuncionarioDomain funcionario)
        {
            throw new NotImplementedException();
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a query a ser executada
                string querySelectById = "SELECT idFuncionario, Nome, Sobrenome FROM Funcionarios;

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para receber os valores do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    // Passa o valor para o parâmetro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        // Se sim, instancia um novo objeto FuncionarioBuscado do tipo FuncionarioDomain
                        FuncionarioDomain funcionarioBuscado = new FuncionarioDomain()
                        {
                            // Atribui à propriedade idFuncionario o valor da coluna "idFuncionario" da tabela do banco de dados
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"]),

                            // Atribui à propriedade nome o valor da coluna "nome" da tabela do banco de dados
                            nome = rdr["nome"].ToString(),

                            // Atribui à propriedade nome o valor da coluna "sobrenome" da tabela do banco de dados
                            sobrenome = rdr ["sobrenome"].ToString()
                        };

                        // Retorna o FuncionarioBuscado com os dados obtidos
                        return funcionarioBuscado;
                    }

                    // Se não, retorna null
                    return null;
                }
            }
        }

        public void Cadastrar(FuncionarioDomain novoFuncionario)
        {
            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            { 

                // Declara a query que será executada
                string queryInsert = "INSERT INTO (nome), (sobrenome) VALUES @nome, @sobrenome )";

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    // Passa o valor para o parâmetro @Nome
                    cmd.Parameters.AddWithValue("@nome", novoFuncionario.nome);
                    cmd.Parameters.AddWithValue("@sobrenome", novoFuncionario.sobrenome);

                    // Abre a conexão com o banco de dados
                    con.Open();

                    // Executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<FuncionarioDomain> ListarTodos()
        {
            // Cria uma lista listaFuncionarios onde serão armazenados os dados
            List<FuncionarioDomain> listaFuncionario = new List<FuncionarioDomain>();

            // Declara a SqlConnection con passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                // Declara a instrução a ser executada
                string querySelectAll = "SELECT idfuncionario, Nome FROM Funcionarios";

                // Abre a conexão com o banco de dados
                con.Open();

                // Declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                // Declara o SqlCommand cmd passando a query que será executada e a conexão como parâmetros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    // Executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    // Enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        // Instacia um objeto funcionario do tipo FuncionarioDomain
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            // Atribui à propriedade idfuncionario o valor da primeira coluna da tabela do banco de dados
                            idFuncionario = Convert.ToInt32(rdr[0]),

                            // Atribui à propriedade nome o valor da segunda coluna da tabela do banco de dados
                            nome = rdr[1].ToString(), 

                            sobrenome = rdr[1].ToString()


                            //Atribui à propriedade nome o valor da terceira coluna da tabela do banco de dados
                            //sobrenome = rdr[2].ToString()

                        };

                        // Adiciona o objeto funcionario à lista listaFuncionarios
                        listaFuncionario.Add(funcionario);
                    }
                }
            }

            // Retorna a lista de gêneros
            return listaFuncionario;
        }
       


    }
}
