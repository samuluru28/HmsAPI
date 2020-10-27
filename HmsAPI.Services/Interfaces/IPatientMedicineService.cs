using HmsAPI.Dto;
using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services.Interfaces
{
    public interface IPatientMedicineService
    {
        PatientMedicineDTO AddMedicine(PatientMedicineDTO obj);

        PatientMedicineDTO GetMedicineByID(int patientMedicineID);

        IEnumerable<PatientMedicineDTO> GetAllMedicines();
    }
}
