using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using WebAPI_IOCContainerSampleNET6.Services;

namespace WebAPI_IOCContainerSampleNE6.Controllers
{

    //Beispiel zeigt den Zugriff auf den IOC Container via Konstruktor Injection, Method Injection, und via HttpContext 

    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {

        //Sample 1: Konstruktor Injection -> Wird verwendet, wenn ein Service in einer Klasse mehrfach an verschienden Stellen verwendet wird. (Klassenweite Verwendung) 
        private readonly ITimeService _timeService;
        
        //Konsturktor-injection 
        public SampleController(ITimeService timeService)
        {
            _timeService = timeService;
        }

        //Sample 2: Methoden Injection -> Eine Methode benötigt explziet einen Service, der nur in der jenigen Methode verwendet wird.
        [HttpGet("MeineActionMethode")]
        public IActionResult MeineActionMethode([FromServices] ITimeService timeService)
        {
            //[FromServices] ITimeService timeService steht nur in dieser Methode zu Verfügung

            return Ok(timeService.GetCurrentTime());
        }


        [HttpGet("HttpContextSample")]
        public IActionResult MeineActionMethode()
        {
            ITimeService timeService = HttpContext.RequestServices.GetService<ITimeService>();

            ITimeService timeService2 = HttpContext.RequestServices.GetRequiredService<ITimeService>();

            return Ok(timeService.GetCurrentTime());
        }


    }
}
