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
    public class DoctorService: IDoctorService
    {
        public readonly IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;

        }
        public DoctorDTO AddDoctor(DoctorDTO obj)
        {
            var objDoctor = ConvertTOModel(obj);
            var doctor = _doctorRepository.SaveorUpdate(objDoctor);
            return ConvertTODTO(doctor);
        }

        public DoctorDTO GetDoctorsByID(int doctorID)
        {
            var doctor = _doctorRepository.GetDoctorByID(doctorID);
            return ConvertTODTO(doctor);
        }

        public IEnumerable<DoctorDTO> GetAllDoctors()
        {
            List<DoctorDTO> doctorDTOList = new List<DoctorDTO>();
            IEnumerable<Doctor> doctorDTO = _doctorRepository.GetAll();
            foreach (var doctor in doctorDTO)
            {
                var objdoctorDTO = ConvertTODTO(doctor);
                doctorDTOList.Add(objdoctorDTO);

            }
            return doctorDTOList;
        }
        public Doctor ConvertTOModel(DoctorDTO obj)
        {

            var doctor = new Doctor()
            {
                DoctorID = obj.DoctorID,
                UserID = obj.UserID,
                Active = obj.Active,
                Specialist= obj.Specialist,
                LicenseNumber = obj.LicenseNumber,
                VerifiedBy = obj.VerifiedBy

            };
            return doctor;
        }

        public DoctorDTO ConvertTODTO(Doctor obj)
        {

            var doctorDTO = new DoctorDTO()
            {
                DoctorID = obj.DoctorID,
                UserID = obj.UserID,
                Active = obj.Active,
                Specialist = obj.Specialist,
                LicenseNumber = obj.LicenseNumber,
                VerifiedBy = obj.VerifiedBy

            };
            return doctorDTO;
        }

        
    }
}
