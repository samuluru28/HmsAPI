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
    [RoutePrefix("api/v1/doctor")]
    public class DoctorController: ApiController
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }


        /// <summary>
        /// Adds new Doctor Information
        /// </summary>
        /// <param name="doctorDTO"></param>
        /// <returns></returns>
        [Route("AddDoctor")]
        [HttpPost]
        public IHttpActionResult AddDoctor([FromBody] DoctorDTO doctorDTO)
        {
            if (doctorDTO == null)
            {
                return BadRequest();
            }
            var results = _doctorService.AddDoctor(doctorDTO);
            return Ok(results);

        }


        /// <summary>
        /// Gets Doctor Details
        /// </summary>
        /// <param name="doctorID"></param>
        /// <returns></returns>
        [Route("GetDoctor")]
        [HttpGet]
        public IHttpActionResult GetDoctorsByID(int doctorID)
        {
            if (doctorID > 0)
            {
                var odoctorDTO = _doctorService.GetDoctorsByID(doctorID);

                return Ok(odoctorDTO);

            }
            return BadRequest();

        }



        /// <summary>
        /// Gets Doctor Details specific to Hospital
        /// </summary>
        /// <param name="hospitalID"></param>
        /// <returns></returns>
        [Route("GetDoctorByHospital")]
        [HttpGet]
        public IHttpActionResult GetDoctorsByHospitalID(int hospitalID)
        {
            if(hospitalID > 0)
            {
                var oDoctorDTO = _doctorService.GetDoctorsByHospitalID(hospitalID);
                return Ok(oDoctorDTO);
            }
            return BadRequest();

        }


        /// <summary>
        /// Gets Doctor Details by Specialization
        /// </summary>
        /// <param name="specialist"></param>
        /// <returns></returns>
        [Route("GetDoctorBySpecialist")]
        [HttpGet]
        public IHttpActionResult GetDoctorsByspecialization(string specialist)
        {
            if(!string.IsNullOrWhiteSpace(specialist))
            {
                var oDoctorDTO = _doctorService.GetDoctorsByspecialization(specialist);
                return Ok(oDoctorDTO);
            }
            return BadRequest();

        }


        /// <summary>
        /// Gets List of All Doctors Details
        /// </summary>
        /// <returns></returns>
        [Route("GetAllDoctors")]
        [HttpGet]
        public IHttpActionResult GetAllDoctors()
        {
            var doctors = _doctorService.GetAllDoctors();
            return Ok(doctors);

        }




        /// <summary>
        /// Gets the DoctorAvailability Information
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [Route("Availability")]
        [HttpPost]
        public IHttpActionResult GetDoctorAvailability([FromBody] DoctorParameters parameters)
        {
            if( (parameters.DoctorID > 0) && (parameters.Docdate== null) && (parameters.HospitalId > 0))
            {
                var DoctorAvailabilityDTO = _doctorService.GetDoctorAvailability(parameters.DoctorID, parameters.Docdate, parameters.HospitalId);
                return Ok(DoctorAvailabilityDTO);
            }
            return BadRequest();

        }

    }
}
