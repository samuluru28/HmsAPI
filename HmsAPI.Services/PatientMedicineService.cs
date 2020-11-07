using HmsAPI.DataAccess;
using HmsAPI.Dto;
using HmsAPI.Model;
using HmsAPI.Services.Interfaces;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services
{
    public class PatientMedicineService: IPatientMedicineService
    {
        private ILog log = LogManager.GetLogger(typeof(RolesService));
        public readonly IPatientMedicineRepository _patientMedicineRepository;
        public PatientMedicineService(IPatientMedicineRepository patientMedicineRepository)
        {
            _patientMedicineRepository = patientMedicineRepository;

        }

        public PatientMedicineDTO AddMedicine(PatientMedicineDTO obj)
        {
            try
            {
                var objMedicine = ConvertTOModel(obj);
                var medicine = _patientMedicineRepository.SaveorUpdate(objMedicine);
                log.Info("PatientMedicine info Added Successfully");
                return ConvertTODTO(medicine);
            }
            catch(Exception ex)
            {
                log.ErrorFormat("Exception occured while Adding new PatientMedicine Ex:{0}", ex.Message);
                return null;

            }
        }

        public PatientMedicineDTO GetMedicineByID(int patientMedicineID)
        {
            try
            {

                var patientMedicine = _patientMedicineRepository.GetMedicineByID(patientMedicineID);
                return ConvertTODTO(patientMedicine);
            }
            catch(Exception ex)
            {
                log.ErrorFormat("Exception occured while Adding new PatientMedicine info Ex:{0}", ex.Message);
                return null;

            }
            
        }

        public List<PatientMedicineDTO> GetAllMedicines()
        {
            try
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
            catch (Exception ex)
            {
                log.ErrorFormat("Exception occured while retreiving list of PatientMedicine info Ex:{0}", ex.Message);
                return null;

            }
        }

        public PatientMedicineDTO GetMedicinesByAppointmnetID(int appointmentID)
        {
            try
            {
                var results = _patientMedicineRepository.GetMedicinesByAppointmnetID(appointmentID);
                return ConvertTODTO(results);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Exception occured while retreiving PatientMedicines by Appointment info Ex:{0}", ex.Message);
                return null;

            }

        }
        public List<PatientMedicineDTO> GetMedicinesByUserID(int userID)
        {
            try
            {
                List<PatientMedicineDTO> patientMedicineDTOList = new List<PatientMedicineDTO>();
                IEnumerable<PatientMedicine> patientMedicines = _patientMedicineRepository.GetMedicinesByUserID(userID);
                foreach (var medicine in patientMedicines)
                {
                    var medicineDTO = ConvertTODTO(medicine);
                    patientMedicineDTOList.Add(medicineDTO);

                }
                return patientMedicineDTOList;
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Exception occured while retreiving all the list of PatientMedicines Ex:{0}", ex.Message);
                return null;

            }

        }
        public PatientMedicine ConvertTOModel(PatientMedicineDTO obj)
        {

            var patientMedicine = new PatientMedicine()
            {
                PatientMedicineID = obj.PatientMedicineID,
                AppointmentID = obj.AppointmentID,
                MedicineDescription = obj.MedicineDescription,
                UserID = obj.UserID

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
