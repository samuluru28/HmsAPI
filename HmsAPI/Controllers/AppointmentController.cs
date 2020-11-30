using HmsAPI.Dto;
using HmsAPI.Dto.Request;
using HmsAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HmsAPI.Controllers
{
    /// <summary>
    /// Provides functionality/Methods to the Appointment.
    /// </summary>   
    [RoutePrefix("api/v1/appointment")]
   
    public class AppointmentController : ApiController
    {
        private readonly IAppointmentService _appointmentService;

        /// <summary>  
        /// Public constructor to initialize appointmentService instance  
        /// </summary> 
        public AppointmentController(IAppointmentService appointmentService)

        {
            _appointmentService = appointmentService;
        }

       
        /// <summary>
        /// Adds new Appointment Information
        /// </summary>
        /// <param name="appointmentDTO"></param>
        /// <returns></returns>
        [Route("AddAppointment")]
        [HttpPost]
        public IHttpActionResult AddAppointment([FromBody] AppointmentDTO appointmentDTO)
        {
            if (appointmentDTO == null)
            {
                return BadRequest();
            }
            var results = _appointmentService.AddAppointment(appointmentDTO);
            return Ok(results);
        }

        /// <summary>
        /// Get Appointmnent Details
        /// </summary>
        /// <param name="appointmentID"></param>
        /// <returns></returns>
        [Route("GetAppointment")]
        [HttpGet]
        public IHttpActionResult GetAppointmentByID(int appointmentID)
        {
            if (appointmentID > 0)
            {
                var appointmentDTO = _appointmentService.GetAppointmentByID(appointmentID);
                return Ok(appointmentDTO);
            }
            return BadRequest();
        }


        /// <summary>
        /// Gets List of Appointments
        /// </summary>
        /// <returns></returns>
        [Route("GetAllAppointments")]
        [HttpGet]
        public IHttpActionResult GetAllAppointments()
        {
            var Appointments = _appointmentService.GetAllAppointments();
            return Ok(Appointments);

        }


        /// <summary>
        /// Get Appointment Details specific to Doctor and Date
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// Changing Get method to post to receive parameters in Body
        [Route("GetDoctorAppointment")]
        [HttpPost]
        public IHttpActionResult GetDoctorAppointmentByDate([FromBody] AppointmentParameters parameters)
        {
            if (parameters.DoctorID > 0 && parameters.AppDate != null)
            {
                var oDoctorAppointmentDTO = _appointmentService.GetDoctorAppointmentByDate(parameters.DoctorID, parameters.AppDate);
                return Ok(oDoctorAppointmentDTO);
            }
            return BadRequest();
        }


    }
}
