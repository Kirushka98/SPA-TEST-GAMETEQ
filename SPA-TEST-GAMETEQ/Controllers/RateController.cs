using DB_TEST_GAMETEQ;
using Microsoft.AspNetCore.Mvc;
using SPA_TEST_GAMETEQ.Dto;

namespace SPA_TEST_GAMETEQ.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RateController : ControllerBase
{
    private readonly ApplicationContext _applicationContext;
    private readonly ILogger<RateController> _logger;

    public RateController(ILogger<RateController> logger, ApplicationContext applicationContext)
    {
        _logger = logger;
        _applicationContext = applicationContext;
    }

    [HttpGet("{date}")]
    public IEnumerable<Rate> Get(DateTime date)
    {
        date = date.Date;
        while (!_applicationContext.Rates.Any(x => x.Date == date))
        {
            date = date.AddDays(-1);
        }

        return _applicationContext.Rates.Where(x => x.Date == date)
            .Select(x => new Rate
            {
                Currency = x.Currency,
                Value = x.Value
            });
    }
}