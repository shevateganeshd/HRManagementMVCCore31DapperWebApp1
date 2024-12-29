using Dapper;
using HRManagementMVCCore31DapperWebApp1.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRManagementMVCCore31DapperWebApp1.Repositories
{
    public class SalaryRepository
    {
        private readonly string _connectionString;

        public SalaryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Salary>> GetAllSalariesAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryAsync<Salary>("SELECT * FROM Salary");
            }
        }

        public async Task<Salary> GetSalaryByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Salary>(
                    "SELECT * FROM Salary WHERE SalaryId = @SalaryId", new { SalaryId = id });
            }
        }

        public async Task<Salary> GetSalaryByEmployeeIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Salary>(
                    "SELECT * FROM Salary WHERE EmployeeId = @EmployeeId", new { EmployeeId = id });
            }
        }

        public async Task<int> AddSalaryAsync(Salary Salary)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"INSERT INTO Salary (EmployeeId, Basic, HRA, TA, Total) 
                        VALUES (@EmployeeId, @Basic, @HRA, @TA, @Total)";
                return await connection.ExecuteAsync(sql, Salary);
            }
        }

        public async Task<int> UpdateSalaryAsync(Salary Salary)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE Salary 
                        SET Basic = @Basic, HRA = @HRA, TA = @TA, Total = @Total 
                        WHERE SalaryId = @SalaryId";
                return await connection.ExecuteAsync(sql, Salary);
            }
        }

        public async Task<int> UpdateSalaryByEmployeeIdAsync(Salary Salary)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"UPDATE Salary 
                        SET Basic = @Basic, HRA = @HRA, TA = @TA, Total = @Total 
                        WHERE EmployeeId = @EmployeeId";
                return await connection.ExecuteAsync(sql, Salary);
            }
        }

        public async Task<int> DeleteSalaryAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync("DELETE FROM Salary WHERE SalaryId = @SalaryId", new { SalaryId = id });
            }
        }

        public async Task<int> DeleteSalaryByEmployeeIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.ExecuteAsync("DELETE FROM Salary WHERE EmployeeId = @EmployeeId", new { EmployeeId = id });
            }
        }
    }
}
