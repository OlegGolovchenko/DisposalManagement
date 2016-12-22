using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisposalManagement.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PostalCode { get; set; }
        public string Email { get; set; }
    }
}