using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OAuth.Net.Common;

namespace Witchr.Auth.Tests
{
    [TestClass]
    public class OAuthServiceTest
    {

        [TestMethod]
        public void ShouldGenerateSignatureForExampleForFlickr()
        {
            //given
            string expected = "0fhNGlzpFNAsTme/hDfUb5HPB5U=";
            OAuthParameters parameters = new OAuthParameters()
            {
                Nonce = "C2F26CD5C075BA9050AD8EE90644CF29",
                SignatureMethod = "HMAC-SHA1",
                Timestamp = "1316657628",
                Version = "1.0",
                Callback = "http://www.wackylabs.net/oauth/test",
                ConsumerKey = "768fe946d252b119746fda82e1599980"
            };
            string baseString = SignatureBase.Create("GET", new Uri("http://www.flickr.com/services/oauth/request_token"), parameters);
            string consumerSecret = "1a3c208e172d3edc";
            string tokenSecret = string.Empty;
            OAuthService testee = new OAuthService();
            //when
            string result = testee.GenerateSignature(baseString, consumerSecret, tokenSecret);

            //then
            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void ShouldGenerateSignatureForFlickr()
        {
            //given
            OAuth.Net.Common.ISigningProvider provider = new OAuth.Net.Components.HmacSha1SigningProvider();
            OAuth.Net.Common.INonceProvider nonceProvider = new OAuth.Net.Components.GuidNonceProvider();
            DateTime time = DateTime.Now;
            OAuthParameters parameters = new OAuthParameters()
            {
                Nonce = nonceProvider.GenerateNonce(),
                SignatureMethod = "HMAC-SHA1",
                Timestamp = "1316657628",
                Version = "1.0",
                Callback = "http://www.wackylabs.net/oauth/test",
                ConsumerKey = "768fe946d252b119746fda82e1599980"
            };
            string baseString = SignatureBase.Create("GET", new Uri("http://www.flickr.com/services/oauth/request_token"), parameters);
            string consumerSecret = "1a3c208e172d3edc";
            string tokenSecret = string.Empty;
            OAuthService testee = new OAuthService();
            //when
            string result = provider.ComputeSignature(baseString, consumerSecret, tokenSecret);

            //then
            Assert.AreEqual(expected, result);
        }
    }
}
