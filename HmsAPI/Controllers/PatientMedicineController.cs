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
    [RoutePrefix("api/v1/PatientMedicine")]
    public class PatientMedicineController: ApiController
    {
        private readonly IPatientMedicineService _patientMedicineService;
        public PatientMedicineController(IPatientMedicineService patientMedicineService)
        {
            _patientMedicineService = patientMedicineService;
        }


        /// <summary>
        /// Adds PatientMedicine Info
        /// </summary>
        /// <param name="patientMedicineDTO"></param>
        /// <returns></returns>
        [Route("PatientMedicine")]
        [HttpPost]
        public IHttpActionResult AddPatientMedicine([FromBody] PatientMedicineDTO patientMedicineDTO)
        {
            if (patientMedicineDTO == null)
            {
                return BadRequest();
            }

            var results = _patientMedicineService.AddMedicine(patientMedicineDTO);
            return Ok(results);
        }

        /// <summary>
        /// Gets PatientMedicine Info
        /// </summary>
        /// <param name="patientMedicineID"></param>
        /// <returns></returns>
        [Route("GetMedicine")]
        [HttpGet]
        public IHttpActionResult GetPatientMedicineByID(int patientMedicineID)
        {
            if(patientMedicineID > 0)
            {
                var oPatientMedicineDTO = _patientMedicineService.GetMedicineByID(patientMedicineID);

                return Ok(oPatientMedicineDTO);

            }
            return BadRequest();
           
        }

        
        /// <summary>
        /// Gets PatientMedicine Info per Appointment
        /// </summary>
        /// <param name="appointmentID"></param>
        /// <returns></returns>
        [Route("Getmedicines")]
        [HttpGet]
        public IHttpActionResult GetMedicinesByAppointmnetID(int appointmentID)
        {
            if (appointmentID > 0)
            {
                var oPatientMedicineDTO = _patientMedicineService.GetMedicinesByAppointmnetID(appointmentID);

                return Ok(oPatientMedicineDTO);

            }
            return BadRequest();

        }

        /// <summary>
        /// Gets PatientMedicine Info for Specific User
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [Route("GetmedicinesByUser")]
        [HttpGet]
        public IHttpActionResult GetMedicinesByUserID(int userID)
        {
            if (userID > 0)
            {
                var oPatientMedicineDTO = _patientMedicineService.GetMedicinesByUserID(userID);

                return Ok(oPatientMedicineDTO.ToList());

            }
            return BadRequest();

        }

    }
}
