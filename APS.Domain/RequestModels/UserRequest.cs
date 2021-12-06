using System.ComponentModel.DataAnnotations;

namespace APS.Domain.ResponseModels
{
    public class UserRequest
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
