using Microsoft.AspNetCore.Identity;

namespace ProiectDeAnMRSTW.Infrastructure.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string ?Age { get; set; }
        [PersonalData]
        public string ?Gender{ get; set; }
        [PersonalData]
        public string ?Country { get; set; }
    }

}