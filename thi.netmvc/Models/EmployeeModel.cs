using System.ComponentModel.DataAnnotations.Schema;
using thi.netmvc.Entities;

namespace thi.netmvc.Models
{
    public class EmployeeModel
    {
        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public int IdUser { get; set; }
        [ForeignKey("user")]
        public User User { get; set; }
        public int IDepartment { get; set; }
        [ForeignKey("Departiment_Tbl")]
        public Department_Tbl Department { get; set; }

        public string Rank { get; set; }
    }
}
