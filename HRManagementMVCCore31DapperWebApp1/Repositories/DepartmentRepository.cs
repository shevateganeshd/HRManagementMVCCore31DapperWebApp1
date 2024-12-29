using Dapper;
using HRManagementMVCCore31DapperWebApp1.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRManagementMVCCore31DapperWebApp1.Repositories
{
    public class DepartmentRepository
    {
        private readonly string _connectionString;

        public DepartmentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Department>("SELECT * FROM Department");
            }
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Department>(
                    "SELECT * FROM Department WHERE DepartmentId = @DepartmentId", new { DepartmentId = id });
            }
        }

        public async Task<int> AddDepartmentAsync(Department department)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"INSERT INTO Department (DepartmentName) 
                        VALUES (@DepartmentName)";
                return await connection.ExecuteAsync(sql, department);
            }
        }

        public async Task<int> UpdateDepartmentAsync(Department department)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE Department 
                        SET DepartmentName = @DepartmentName
                        WHERE DepartmentId = @DepartmentId";
                return await connection.ExecuteAsync(sql, department);
            }
        }

        public async Task<int> DeleteDepartmentAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync("DELETE FROM Department WHERE DepartmentId = @DepartmentId", new { DepartmentId = id });
            }
        }
    }
}
