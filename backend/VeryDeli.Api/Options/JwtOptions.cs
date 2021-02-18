using System;

namespace VeryDeli.Api.Options
{
    public class JwtOptions
    {
        public string Secret { get; set; }
        public TimeSpan TokenLifetime { get; set; }
    }
}
