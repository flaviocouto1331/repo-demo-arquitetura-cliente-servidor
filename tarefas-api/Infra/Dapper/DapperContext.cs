using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infra.Dapper
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _conexao;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentException("DapperContext configuração inválida.", nameof(_configuration));
            _conexao = _configuration.GetConnectionString("conexao") ?? throw new InvalidOperationException("Conexão inválida.");
        }

        public IDbConnection DapperConnection() => new SqlConnection(_conexao);
    }
}
