using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentEmployees.Web.DTO
{
    public class MessageDTO
    {
        [TempData]
        public string StatusMessage { get; set; }
    }
}
