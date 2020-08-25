using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace VeryDeli.Data.Domains
{
    public class User : IdentityUser<Guid>
    {
        [Required]
        [Column(Order = 4)]
        public Enums.UserType UserTypeId { get; set; }

        [ForeignKey(nameof(UserTypeId))]
        public virtual UserType UserType { get; set; }
    }
}
