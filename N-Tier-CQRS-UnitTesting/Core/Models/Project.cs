using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core
{
    public class Project : BaseEntity<int>
    {

        public string Name { get; set; }

        [MinLength(2)]
        public string Code { get; set; }

        public string Description { get; set; }
        public int CompanyId { get; set; }

    }
}
