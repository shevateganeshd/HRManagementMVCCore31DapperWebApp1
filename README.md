# HRManagementMVCCore31DapperWebApp1

**Startup.cs**

public void ConfigureServices(IServiceCollection services)
<br/>
{
<br/>
    //To includes both APIs and Razor Views<br/> 
    services.AddControllersWithViews();

    services.AddScoped<EmployeeRepository>((provider =>
    {
        var configuration = provider.GetRequiredService<IConfiguration>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        return new EmployeeRepository(connectionString);
    }));
    
    services.AddScoped<DepartmentRepository>((provider =>
    {
        var configuration = provider.GetRequiredService<IConfiguration>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        return new DepartmentRepository(connectionString);
    }));
    
    services.AddScoped<SalaryRepository>((provider =>
    {
        var configuration = provider.GetRequiredService<IConfiguration>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        return new SalaryRepository(connectionString);
    }));
}

<br/>

**EmployeeRepository.cs**

public class EmployeeRepository
<br/>
{
<br/>
    private readonly string _connectionString;

    public EmployeeRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            return await connection.QueryAsync<Employee>("SELECT emp.EmployeeId, emp.FirstName, emp.MiddleName, emp.LastName, emp.Address, emp.Email, emp.Phone, dept.DepartmentName 
            FROM Employee emp INNER JOIN 
            Department dept ON dept.DepartmentId=emp.DepartmentId;");
        }
    }
    
    public async Task<Employee> GetEmployeeByIdAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            return await connection.QueryFirstOrDefaultAsync<Employee>(
                "SELECT emp.EmployeeId, emp.FirstName, emp.MiddleName, emp.LastName, emp.Address, emp.Email, emp.Phone, dept.DepartmentId, dept.DepartmentName 
                FROM Employee emp INNER JOIN 
                Department dept ON dept.DepartmentId=emp.DepartmentId 
                WHERE EmployeeId= @EmployeeId", new { EmployeeId = id });
        }
    }
    
    public async Task<int> AddEmployeeAsync(Employee Employee)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = @"INSERT INTO Employee (FirstName, MiddleName, LastName, Address, Email, Phone, DepartmentId) 
                    VALUES (@FirstName, @MiddleName, @LastName, @Address, @Email, @Phone, @DepartmentId)";
            return await connection.ExecuteAsync(sql, Employee);
        }
    }
    
    public async Task<int> UpdateEmployeeAsync(Employee Employee)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            var sql = @"UPDATE Employee 
                    SET FirstName = @FirstName, MiddleName = @MiddleName, LastName = @LastName, Address = @Address, Email=@Email, Phone=@Phone, DepartmentId=@DepartmentId
                    WHERE EmployeeId = @EmployeeId";
            return await connection.ExecuteAsync(sql, Employee);
        }
    }
    
    public async Task<int> DeleteEmployeeAsync(int id)
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            return await connection.ExecuteAsync("DELETE FROM Employee WHERE EmployeeId = @EmployeeId", new { EmployeeId = id });
        }
    }
}
