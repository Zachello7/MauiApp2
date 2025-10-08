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
            }

            catch
            {

            }
        }
    }
}
