using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SteckPointTestSendData.Domain.Entities
{
    [Table("Organizations")]
    public class Organizations
    {
        public int Id { get; set; }
        [MaxLength(150)]
        [Required]
        public string OrganizationsName { get; set; }        
    }
}
