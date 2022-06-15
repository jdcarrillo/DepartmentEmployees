using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentEmployees.Web.DTO
{
    public class DepartmentsDTO
    {
        public int id { get; set; }
        public int id_enterprises { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string description { get; set; }
        public bool status { get; set; }
        public string created_by { get; set; }
        public DateTime created_date { get; set; }
        public string modified_by { get; set; }
        public DateTime? modified_date { get; set; }


        [NotMapped]
        public virtual EnterpriseDTO EnterpriseDto { get; set; }

        [NotMapped]
        public virtual ICollection<DepartmentEmployeeDTO> DepartmentEmployees { get; set; }
        [NotMapped]
        [DisplayName("Company")]
        public List<SelectListItem> enterprisesList { get; set; }



    }
}
