using Dapper;
using Projeto.Repository.Contracts;
using Projeto.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Projeto.Repository.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {

        private readonly string connectionString;

        public FuncionarioRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Atualizar(Funcionario entity)
        {
            var query = "update Funcionario set Nome = @Nome, Salario = @Salario, "
                + "DataAdmissao = @DataAdmissao, IdSetor = @IdSetor, IdFuncao = @IdFuncao "
                + "where IdFuncionario = @IdFuncionario";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public List<Funcionario> ConsultarTodos()
        {
            var query = "Select * from Funcionario";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Funcionario>(query).ToList();
            }
        }

        public void Excluir(Funcionario entity)
        {
            var query = "delete from Funcionario where IdFuncionario = @IdFuncionario";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public void Inserir(Funcionario entity)
        {
            var query = "insert into Funcionario(Nome, Salario, DataAdmissao, IdSetor, IdFuncao) "
                        + "values(@Nome, @Salario, @DataAdmissao, @IdSetor, @IdFuncao)";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public Funcionario ObterPorId(int id)
        {
            var query = "select * from Funcionario where IdFuncionario = @IdFuncionario";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Funcionario>(query, new { IdFuncionario = id }).FirstOrDefault();
            }
        }
    }
}
