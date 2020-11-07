using HmsAPI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services.Interfaces
{
    public interface IHospitalService
    {
        HospitalDTO AddHospital(HospitalDTO obj);

        HospitalDTO GetHospitalsByID(int hospitalID);

        List<HospitalDTO> GetAllHospitals();
    }
}
