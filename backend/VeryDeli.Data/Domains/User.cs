using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace VeryDeli.Data.Domains
{
    [Table("User")]
    public class User : IdentityUser<Guid>
    {
    }
}
