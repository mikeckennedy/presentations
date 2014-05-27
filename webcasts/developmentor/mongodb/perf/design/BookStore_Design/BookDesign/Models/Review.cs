using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDesign.Models
{
    class Review
    {
        public DateTime Created { get; set; }
        public string Comment { get; set; }

        public Review()
        {
            Created = DateTime.Now;
        }

    }
}
