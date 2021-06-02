using System.Collections.Generic;
using Dapper;
using FyleAssignment.Models;
using Microsoft.Extensions.Options;
using Npgsql;

namespace FyleAssignment.Repository
{
    public class BranchRepository:IBranchRepository
    {
        private readonly ConnectionString _connectionString;

        public BranchRepository(IOptions<ConnectionString> connectionString)
        {
            _connectionString = connectionString.Value;
        }

        public IEnumerable<Branch> GetAll(string query, int limit, int offset)
        {
            string sql = @"SELECT *
FROM branches
WHERE branch LIKE UPPER(@Query)
	OR address LIKE UPPER(@Query)
	OR city LIKE UPPER(@Query)
	OR district LIKE UPPER(@Query)
	OR state LIKE UPPER(@Query)
ORDER BY ifsc LIMIT @Limit OFFSET @Offset";
            using (var connection = new NpgsqlConnection(_connectionString.FYLEDB))
            {
                var branches = connection.Query<Branch>(sql, new { @Query = query, @Limit = limit, @Offset = offset });
                return branches;
            }
        }

        public IEnumerable<Branch> GetByBranch(string branchName, int limit, int offset)
        {
            string sql = @"SELECT *
FROM branches
WHERE branch LIKE @BranchName
ORDER BY ifsc LIMIT @Limit OFFSET @Offset";
            using(var connection=new NpgsqlConnection(_connectionString.FYLEDB))
            {
                var branches=connection.Query<Branch>(sql,new { @BranchName=branchName,@Limit=limit,@Offset=offset });
                return branches;
            }
        }
    }
}
