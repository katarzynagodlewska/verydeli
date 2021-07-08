using System;

namespace VeryDeli.Libraries.Abstraction.Options
{
    public class JwtOptions
    {
        public string Secret { get; set; }
        public TimeSpan TokenLifetime { get; set; }
    }
}
