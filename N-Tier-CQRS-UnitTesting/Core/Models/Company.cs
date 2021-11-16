using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class Company : BaseEntity<int>
    {
       
        public string Name { get; set; }

        public string Website { get; set; }

        public string Phone { get; set; }

        public IEnumerable<Project> Projects { get; set; }

    }
}
