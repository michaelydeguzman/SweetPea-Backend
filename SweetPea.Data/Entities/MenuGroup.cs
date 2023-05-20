using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetPea.Domain.Entities
{
    public class MenuGroup
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool Active { get; set; }

        public string? Code { get; set; }

        public DateTime CreatedDate { get; set; }

        public long CreatedBy { get; set; }
        
        public DateTime ModifiedDate { get; set; }

        public long ModifiedBy { get; set; }
    }
}
