using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduLms.Data
{
    public interface ISqlConnectionFactory
    {
        IDbConnection Create();
    }

    public sealed class SqlConnectionFactory : ISqlConnectionFactory
    {
        private readonly string _cs;
        public SqlConnectionFactory(string cs) => _cs = cs;
        public IDbConnection Create() => new SqlConnection(_cs);
    }
}
