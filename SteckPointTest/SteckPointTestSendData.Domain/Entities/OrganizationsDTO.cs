using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SteckPointTestSetData.Domain.Entities
{
    [Table("Organizations", Schema = "dbo")]
    public class OrganizationsDTO
    {
        public int Id { get; set; }
        [MaxLength(150)]
        [Required]
        public string OrganizationsName { get; set; }        
    }
}
