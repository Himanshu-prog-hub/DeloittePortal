using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalDeloitte.Models
{
    public class Employee
    {
        public string Name { get; set; }
        public DateTime date { get; set; }

        public HttpPostedFileBase File { get; set; }
    }
}