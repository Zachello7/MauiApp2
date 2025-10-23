using MauiApp2.Components.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using MauiApp2.Components.Pages;
using System.Linq.Expressions;

namespace MauiApp2.Components.DAO
{
    public class ClienteDAO
    {
        public async Task<bool> SalvarCliente(Cliente novoCliente)
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
        public async Task<List<Cliente>> ListarClientes()


        {
            try
            {
                var Lista = new List<Cliente>();

                string connectionString = "server=localhost;user=root;password=root;database=db_empresa_1";
                await using var conn = new MySqlConnection(connectionString);
                string sql = "SELECT * FROM cliente";

                await using var cmd = new MySqlCommand(sql, conn);
                await using var reader = await cmd.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    var cliente = new Cliente()
                    {
                        nome = reader.GetString(1),
                        cpf = reader.GetString(2),
                        telefone = reader.GetString(3)
                    };

                    Lista.Add(cliente);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                return new List<Cliente>();
            }
        }

        public async Task ExcluirCliente(int id)
        {
            try
            {
                string connectionString = "server=localhost;user=root;password=root;database=db_empresa_1";

                await using var conn = new MySqlConnection(connectionString);

                await conn.OpenAsync();

                string sql = "Delete FROM cliente WHERE = id= @id";

                await using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                await cmd.ExecuteNonQueryAsync();
            }        
            
            catch 
            { 
            
            }
        }

        public async Task<Cliente?> BuscarClientePorId(int id)
        {
            try
            {
                string connectionString = "server=localhost;user=root;password=root;database=db_empresa_1";
                await using var conn = new MySqlConnection(connectionString);
                string sql = "SELECT * FROM cliente WHERE id = @id";

                await using var cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("id", id);

                await using var reader = await cmd.ExecuteReaderAsync();

                Cliente cliente = new Cliente()
                {
                    id = reader.GetInt32(0),
                    nome = reader.GetString(1),
                    cpf = reader.GetString(2)
                    telefone = reader.GetString(3)
                };

                return cliente;
            }

            catch (Exception ex) {
                return null;
        }
    }
}