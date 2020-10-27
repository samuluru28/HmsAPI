using HmsAPI.Dto;
using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services
{
    public class PatientMedicineService
    {
        public PatientMedicine ConvertTOModel(PatientMedicineDTO obj)
        {

            var patientMedicine = new PatientMedicine()
            {
                PatientMedicineID = obj.PatientMedicineID,
                AppointmentID = obj.AppointmentID,
                MedicineDescription = obj.MedicineDescription,
                UserID= obj.UserID

            };
            return patientMedicine;
        }

        public PatientMedicineDTO ConvertTODTO(PatientMedicine obj)
        {

            var patientMedicineDTO = new PatientMedicineDTO()
            {
                PatientMedicineID = obj.PatientMedicineID,
                AppointmentID = obj.AppointmentID,
                MedicineDescription = obj.MedicineDescription,
                UserID = obj.UserID

            };
            return patientMedicineDTO;
        }
    }
}
