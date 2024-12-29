namespace HRManagementMVCCore31DapperWebApp1.Models
{
    public class Salary
    {
        public int SalaryId { get; set; }

        // Foreign Key
        public int EmployeeId { get; set; }
        //public Employee Employee { get; set; }

        public decimal Basic { get; set; }
        public decimal HRA { get; set; }
        public decimal TA { get; set; }
        public decimal Total { get; set; }
    }
}
