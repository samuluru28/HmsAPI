using HmsAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services.Interfaces
{
    public interface IDoctorService
    {
        DoctorDTO AddDoctor(DoctorDTO obj);

        DoctorDTO GetDoctorsByID(int doctorID);

        List<DoctorDTO> GetAllDoctors();
        List<DoctorDTO> GetDoctorsByHospitalID(int hospitalID);
        List<DoctorDTO> GetDoctorsByspecialization(string specialist);
        List<DoctorAvailabilityDTO> GetDoctorAvailability(int doctorID, DateTime date, int hospitalID);
    }
}
