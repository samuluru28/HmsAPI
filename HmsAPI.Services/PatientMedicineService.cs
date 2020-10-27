using HmsAPI.DataAccess;
using HmsAPI.Dto;
using HmsAPI.Model;
using HmsAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services
{
    public class PatientMedicineService: IPatientMedicineService
    {
        public readonly IPatientMedicineRepository _patientMedicineRepository;
        public PatientMedicineService(IPatientMedicineRepository patientMedicineRepository)
        {
            _patientMedicineRepository = patientMedicineRepository;

        }

        public PatientMedicineDTO AddMedicine(PatientMedicineDTO obj)
        {
            var objMedicine = ConvertTOModel(obj);
            var medicine = _patientMedicineRepository.SaveorUpdate(objMedicine);
            return ConvertTODTO(medicine);           
        }

        public PatientMedicineDTO GetMedicineByID(int patientMedicineID)
        {
            var patientMedicine = _patientMedicineRepository.GetMedicineByID(patientMedicineID);
            return ConvertTODTO(patientMedicine);
        }

        public IEnumerable<PatientMedicineDTO> GetAllMedicines()
        {
            List<PatientMedicineDTO> patientMedicineDTOList = new List<PatientMedicineDTO>();
            IEnumerable<PatientMedicine> patientMedicines = _patientMedicineRepository.GetAll();
            foreach (var medicine in patientMedicines)
            {
                var medicineDTO = ConvertTODTO(medicine);
                patientMedicineDTOList.Add(medicineDTO);

            }
            return patientMedicineDTOList;
        }
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
