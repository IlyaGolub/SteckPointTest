using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SteckPointTestSendData.Domain.Entities
{
    [Table("Users",Schema = "dbo")]
    [Serializable]
    public class UsersDTO
    {
        public int Id { get; set; }
        [MaxLength(150)]
        [Required]
        public string Name { get; set; }
        [MaxLength(150)]
        [Required]
        public string LastName { get; set; }
        
        public string SecondName { get; set; }
        [MaxLength(250)]
        [Required]
        public string PhoneNamber { get; set; }
        [MaxLength(250)]
        [Required]
        public string Email { get; set; }
    }
}
