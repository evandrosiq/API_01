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
    public class SetorRepository : ISetorRepository
    {
        private readonly string connectionString;

        public SetorRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Atualizar(Setor entity)
        {
            var query = "update Setor set Nome = @Nome where IdSetor = @IdSetor";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, entity);
            }
        }
        public void Excluir(Setor entity)
        {
            var query = "delete from Setor where IdSetor = @IdSetor";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public void Inserir(Setor entity)
        {
            var query = "insert into Setor(Nome) values(@Nome)";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, entity);
            }
        }

        public List<Setor> ConsultarTodos()
        {
            var query = "select * from Setor";

            using (var connection = new SqlConnection(connectionString))
            {
               return connection.Query<Setor>(query).ToList();
            }
        }


        public Setor ObterPorId(int id)
        {
            var query = "select * from Setor where IdSetor = @IdSetor";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Setor>
                    (query, new { IdSetor = id }).FirstOrDefault();
            }
        }
    }
}
