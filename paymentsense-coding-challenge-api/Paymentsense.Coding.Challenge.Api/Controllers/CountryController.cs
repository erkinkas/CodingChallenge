using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Paymentsense.Coding.Challenge.Api.Models;
using Paymentsense.Coding.Challenge.Api.Models.Country;
using Paymentsense.Coding.Challenge.Api.Services;
using Paymentsense.Coding.Challenge.Api.Services.Pagination;

namespace Paymentsense.Coding.Challenge.Api.Controllers
{
    [ApiController]
    [Produces("application/json")]
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

        /// <summary>
        /// Get list of all countries 
        /// </summary>
        /// <param name="PageIndex">page number. Starts from 1</param>
        /// <param name="PageLimit">page size. 50 by default</param>
        /// <returns>Returns list of countries</returns>
        /// <response code="200">Returns paginated response</response>
        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<VmPage<VmCountryList>>> List([FromQuery] ApiParams apiParams)
        {
            var results = await _listService.Get(new PageParams
            {
                PageIndex = apiParams.PageIndex,
                PageSize = apiParams.PageLimit,
            });

            return Ok(new VmPage<VmCountryList>
            {
                Items = VmCountryList.Build(results),
                PageIndex = results.PageIndex,
                PageSize = results.PageSize,
                TotalCount = results.Total
            });
        }

        /// <summary>
        /// Get country details by code
        /// </summary>
        /// <param name="code">Country code. Alpha2 or Alpha3</param>
        /// <returns>Returns country details by code</returns>
        /// <response code="200">Returns country details</response>
        /// <response code="404">If country is not found</response>
        [HttpGet("{code}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<VmCountryDetails>> Details(string code)
        {
            var result = await _detailsService.Get(code);

            if (result == null)
                return NotFound();

            return Ok(VmCountryDetails.Build(result));
        }
    }
}