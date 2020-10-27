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

        IEnumerable<DoctorDTO> GetAllDoctors();
    }
}
