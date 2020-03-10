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
    public class FuncaoRepository : IFuncaoRepository
    {
        private readonly string connectionString;

        public FuncaoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Atualizar(Funcao entity)
        {
            var query = "update Funcao set Nome = @Nome where IdFuncao = @IdFuncao";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public void Excluir(Funcao entity)
        {
            var query = "delete from Funcao where IdFuncao = @IdFuncao";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public void Inserir(Funcao entity)
        {
            var query = "insert into Funcao(Nome) values(@Nome)";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public Funcao ObterPorId(int id)
        {
            var query = "Select * from Funcao where IdFuncao = @IdFuncao";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Funcao>
                   (query, new { IdFuncao = id }).FirstOrDefault();
            }
        }

        public List<Funcao> ConsultarTodos()
        {
            var query = "select * from Funcao";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Funcao>(query).ToList();
            }
        }
    }
}
