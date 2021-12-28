using System.ComponentModel.DataAnnotations;

namespace SteckPointTestSendData.Model
{
    public class User
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
