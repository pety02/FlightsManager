using FlightsManager.Models.Web.Flights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightsManager.Models.Web.Employees
{
    public class IndexEmployeeViewModel
    {
        public PagerViewModel Pager { get; set; }
        public List<EmployeeViewModel> Items { get; set; }
    }
}
