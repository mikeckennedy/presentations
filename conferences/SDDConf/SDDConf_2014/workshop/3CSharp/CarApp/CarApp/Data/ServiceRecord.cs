using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApp.Data
{
    class ServiceRecord
    {
        public DateTime Created { get; set; }
        public string Desc { get; set; }
        public double Price { get; set; }

        public ServiceRecord()
        {
            Created = DateTime.Now;
        }
    }
}
