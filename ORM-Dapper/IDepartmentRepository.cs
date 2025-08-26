namespace ORM_Dapper
{
    public interface IDepartmentRepository
    {

        IEnumerable<Department> GetAllDepartments();
    }
}

