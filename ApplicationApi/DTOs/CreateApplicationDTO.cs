using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationApi.DTOs
{
    public class CreateApplicationDTO
    {
        public DateTime DateTimeUpdated { get; set; }
        public string Email { get; set; }
        public string NameFirst { get; set; }
        public string NameLast { get; set; }
        public string BusinessCategory { get; set; }
        public string BusinessName { get; set; }

    }
}
