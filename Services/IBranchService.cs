using System.Collections.Generic;
using FyleAssignment.Models;

namespace FyleAssignment.Services
{
    public interface IBranchService
    {
        public IEnumerable<Branch> GetByBranch(string branchName,int limit,int offset);
        public IEnumerable<Branch> GetAll(string query, int limit, int offset);

    }
}
