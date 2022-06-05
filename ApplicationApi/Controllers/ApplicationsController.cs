using System.Globalization;
using ApplicationApi.DTOs;
using ApplicationApi.Models;
using ApplicationApi.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationApi.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ApplicationsController: ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationsController(IMapper mapper, IApplicationRepository applicationRepository )
        {
            _applicationRepository = applicationRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Application>>> GetApplications()
        {
            try
            {
                var result =   await _applicationRepository.GetApplicationsAsync();
                return Ok(result);

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }

        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<ActionResult<Application>> GetApplication(int id)
        {
            var result =  await _applicationRepository.GetApplicationByIdAsync(id);
            if(result == null)
            {
                return NotFound(id);
            }else{
                return Ok(result);
            }

        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Application>>> GetByCatergoryAndDate([FromQuery] string category , [FromQuery] string? date, string? toDate = null)
        {
            DateTime fromDateTime, toDateTime ;

            IEnumerable<Application> result;
            // if null or invalid datatime defaults to lower bound
            DateTime.TryParse(date, out fromDateTime);
            DateTime.TryParse(toDate, out toDateTime);

            if( toDate == null || toDateTime == DateTime.MinValue)
            {
                // if null or poorly formatted defaults to max value
                toDateTime = DateTime.MaxValue;

            }else{
                DateTime.TryParse(toDate, out toDateTime);
            }
            try
            {
                Console.WriteLine($"{fromDateTime}   {toDateTime}");
                result =  await _applicationRepository.GetApplicationsByCatergoryAndDateAsync(category, fromDateTime, toDateTime);

            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }

            if(result == null || result.Count() == 0 )
            {
                return NotFound($"category {category} From Date {fromDateTime} To Date {toDateTime}");

            }else{

                return Ok(result);
            }

        }

    }

}
