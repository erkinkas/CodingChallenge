using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Models.Country;
using Paymentsense.Coding.Challenge.Services;
using Paymentsense.Coding.Challenge.Services.Pagination;

namespace Paymentsense.Coding.Challenge.Api.Controllers
{
    [ApiController]
    [Route("country")]
    public class CountryController: ControllerBase
    {
        private readonly ILogger<CountryController> _logger;
        private readonly ICountryListService _listService;
        private readonly ICountryDetailsService _detailsService;

        public CountryController(
            ILogger<CountryController> logger,
            ICountryListService listService,
            ICountryDetailsService detailsService)
        {
            _logger = logger;
            _listService = listService;
            _detailsService = detailsService;
        }

        [HttpGet("")]
        public async Task<IActionResult> List([FromQuery] ApiParams apiParams, CancellationToken cancellationToken)
        {
            var results = await _listService.Get(new PageParams
            {
                PageIndex = apiParams.PageIndex,
                PageSize = apiParams.PageLimit,
            }, cancellationToken);

            return Ok(new VmPage<VmCountryList>
            {
                Items = VmCountryList.Build(results),
                PageIndex = results.PageIndex,
                PageSize = results.PageSize,
                TotalCount = results.Total
            });
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> Details(string code, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(code))
            {
                return BadRequest("country code is not provided");
            }

            var result = await _detailsService.Get(code, cancellationToken);

            return Ok(VmCountryDetails.Build(result));
        }
    }
}