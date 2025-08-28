using System.Data;
using Dapper;

namespace ORM_Dapper
{
    
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;

        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM Departments;");
        }

        public void InsertDepartmentMethod(string name)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@name);",
                new {name=name});
        }
        
       
    }

}

