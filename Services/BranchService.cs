using System.Collections.Generic;
using FyleAssignment.Models;
using FyleAssignment.Repository;

namespace FyleAssignment.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;

        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public IEnumerable<Branch> GetAll(string query, int limit, int offset)
        {
            query = "%" + query + "%";
            return _branchRepository.GetAll(query, limit, offset);
        }

        public IEnumerable<Branch> GetByBranch(string branchName, int limit, int offset)
        {
            branchName = "%" + branchName + "%";
            return _branchRepository.GetByBranch(branchName, limit, offset);
        }
    }
}
