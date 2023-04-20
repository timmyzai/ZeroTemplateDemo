using System.ComponentModel.DataAnnotations;

namespace PepperMintDemo.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
