using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisposalManagement.Models
{
    public class Request
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientEmail { get; set; }
        public string ClientPostalCode { get; set; }
        public bool Intern { get; set; }
        public string ContainerId { get; set; }
    }
}