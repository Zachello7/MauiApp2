using MauiApp2.Components.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace MauiApp2.Components.DAO
{
    public class ClienteDAO
    {
        public async Task<bool > SalvarCliente(Cliente novoCliente)
        {
            try
            {
                //string de conexao
                string connectionString = "server=localhost;user=root;password=root;database=db_empresa_1";

                await using var conn = new MySqlConnection(connectionString);

                await conn.OpenAsync();

                string sql = "INSERT INTO cliente (nome, cpf, telefone) VALUES(@nome, @cpf, @telefone)";

                await using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", novoCliente.nome);
                cmd.Parameters.AddWithValue("@cpf", novoCliente.cpf);
                cmd.Parameters.AddWithValue("@telefone", novoCliente.telefone);

                int rows = await cmd.ExecuteNonQueryAsync();

                return rows > 0;

            }

            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
