using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Moq;

using Newtonsoft.Json;

using Paymentsense.Coding.Challenge.Domain;

using Tests.Core;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Tests.RestCountries.RestCountriesClient
{
    public abstract class RestCountriesClientBaseTests: BaseAutoMock<Infrastructure.RestCountries.RestCountries.RestCountriesClient>
    {
        private readonly string _testDataRootPath;

        protected RestCountriesClientBaseTests()
        {
            _testDataRootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestData");
        }

        protected IList<Country> GetTestData(string testDataFilename)
        {
            var testDataFilepath = Path.Combine(_testDataRootPath, testDataFilename);
            var data = File.ReadAllText(testDataFilepath);
            return JsonConvert.DeserializeObject<IList<Country>>(data);
        }

        protected void FakeHttpClient(HttpStatusCode httpStatusCode, HttpContent httpContent)
        {
            var mockHttpMessageHandler = new MockHttpMessageHandler(httpStatusCode, httpContent);

            var fakeHttpClient = new HttpClient(mockHttpMessageHandler);

            GetMock<IHttpClientFactory>()
                .Setup(x => x.CreateClient(It.IsAny<string>()))
                .Returns(fakeHttpClient);
        }
    }

    public class MockHttpMessageHandler: HttpMessageHandler
    {
        private readonly HttpStatusCode _httpStatusCode;
        private readonly HttpContent _httpContent;

        public MockHttpMessageHandler(HttpStatusCode httpStatusCode, HttpContent httpContent)
        {
            _httpStatusCode = httpStatusCode;
            _httpContent = httpContent;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            return new HttpResponseMessage
            {
                StatusCode = _httpStatusCode,
                Content = _httpContent
            };
        }
    }
}