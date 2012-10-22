using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Witchr.Core.Domain;

namespace Witchr.Auth
{
    public class OAuthService : AuthService
    {
        public string GenerateSignature(string baseString, string consumerSecret, string tokenSecret)
        {
            OAuth.Net.Common.ISigningProvider provider = new OAuth.Net.Components.HmacSha1SigningProvider();
            return provider.ComputeSignature(baseString, consumerSecret, tokenSecret);
        }
    }
}
