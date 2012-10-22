using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FlickrNet;
using System.IO;
using System.IO.IsolatedStorage;

namespace Witchr.Core.Domain
{
    public class FlickrManager
    {
        public const string ApiKey = "e55d235dafc0804e063844cec9b81a3e";
        public const string SharedSecret = "10811d5329cf4531";

        public static Flickr GetInstance()
        {
            return new Flickr(ApiKey, SharedSecret);
        }

        public static Flickr GetAuthInstance()
        {
            var f = new Flickr(ApiKey, SharedSecret);
            f.OAuthAccessToken = OAuthToken.Token;
            f.OAuthAccessTokenSecret = OAuthToken.TokenSecret;
            return f;
        }

        public static OAuthAccessToken OAuthToken
        {
            get
            {
                return Properties.Settings.Default.OAuthToken;
            }
            set
            {
                Properties.Settings.Default.OAuthToken = value;
                Properties.Settings.Default.Save();
            }
        }
    }
}
