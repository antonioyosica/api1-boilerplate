using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Domain.Extensions
{
    public class Response
    {
        public bool Status { get; set; } = true;
        public string? Message { get; set; }
    }
}