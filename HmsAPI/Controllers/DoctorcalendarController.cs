using HmsAPI.Dto;
using HmsAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HmsAPI.Controllers
{
    [RoutePrefix("api/v1/doctorcalendar")]
    public class DoctorcalendarController: ApiController
    {
        private readonly IDoctorCalendarService _doctorCalendarService;
        public DoctorcalendarController(IDoctorCalendarService doctorCalendarService)

        {
            _doctorCalendarService = doctorCalendarService;
        }


        /// <summary>
        /// Adds the DoctorCalendar Information
        /// </summary>
        /// <param name="doctorCalendarDTO"></param>
        /// <returns></returns>
        [Route("AddDoctorCalendar")]
        [HttpPost]
        public IHttpActionResult AddDoctorCalendar([FromBody] DoctorCalendarDTO doctorCalendarDTO)
        {
            if (doctorCalendarDTO == null)
            {
                return BadRequest();
            }
            var results = _doctorCalendarService.AddDoctorCalender(doctorCalendarDTO);
            return Ok(results);
        }


        /// <summary>
        /// Get DoctorCalendar Details
        /// </summary>
        /// <param name="doctorCalendarID"></param>
        /// <returns></returns>
        [Route("GetDoctorCalendar")]
        public IHttpActionResult GetDoctorCalendarByID(int doctorCalendarID)
        {
            if (doctorCalendarID > 0)
            {
                var odoctorCalendarDTO = _doctorCalendarService.GetDoctorCalendarByID(doctorCalendarID);
                return Ok(odoctorCalendarDTO);
            }
            return BadRequest();
        }


        /// <summary>
        /// Gets all DoctorCalendar details
        /// </summary>
        /// <returns></returns>
        [Route("GetAllDoctorsCalendar")]
        [HttpGet]
        public IHttpActionResult GetAllDoctorsCalendar()
        {
            var odoctorCalendarDTOs = _doctorCalendarService.GetAllDoctorsCalendar();
            return Ok(odoctorCalendarDTOs);

        }
    }
}
