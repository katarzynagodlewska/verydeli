using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace VeryDeli.Modules.Users.Core.Data.Domains
{
    public class User : IdentityUser<Guid>
    {
        [Required]
        [Column(Order = 4)]
        public Enums.UserType UserTypeId { get; set; }

        [ForeignKey(nameof(UserTypeId))]
        public UserType UserType { get; set; }
    }
}
