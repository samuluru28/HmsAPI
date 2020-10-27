using HmsAPI.Dto;
using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services
{
    public class DoctorService
    {
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
