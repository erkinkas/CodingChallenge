using System;
using System.Net;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Exceptions
{
    public class RestCallFailedException: Exception
    {
        public RestCallFailedException(Uri uri, HttpStatusCode code)
            : base($"http call failed: Url: '{uri}', Status code: {code}")
        {
        }
    }
}