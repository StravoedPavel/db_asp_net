using EmployeeDBApplication.DataAccess;
using EmployeeDBApplication.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EmployeeDBApplication.Services
{
    public interface IDepartmentService
    {
        Department Get(Expression<Func<Department>> predicate);
        Department Update(Department item);
        int Save(Department item);
        void Delete(int id);
    }
    public class DepartmentService : IDepartmentService
    {
        private readonly IEmployeeApplicationDB _context;

        public DepartmentService(IEmployeeApplicationDB context)
        {
            _context = context;
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Department Get(Expression<Func<Department>> predicate)
        {
            throw new System.NotImplementedException();
        }

        public int Save(Department item)
        {
            throw new System.NotImplementedException();
        }

        public Department Update(Department item)
        {
            throw new System.NotImplementedException();
        }
    }
}