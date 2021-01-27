using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;

using Paymentsense.Coding.Challenge.Domain;

using Tests.Core;

namespace Paymentsense.Coding.Challenge.Infrastructure.RestCountries.Tests.RestCountriesClient
{
    public abstract class RestCountriesClientBaseTests: BaseAutoMock<RestCountries.RestCountriesClient>
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
    }
}