using HmsAPI.DataAccess.Interface;
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
    public class HospitalService: IHospitalService
    {
        private ILog log = LogManager.GetLogger(typeof(HospitalService));
       
        public readonly IHospitalRepository _hospitalRepository;
        public HospitalService(IHospitalRepository hospitalRepository)
        {
            _hospitalRepository = hospitalRepository;

        }

        public HospitalDTO AddHospital(HospitalDTO obj)
        {
            try
            {
                var objHospital = ConvertTOModel(obj);
                var hospital = _hospitalRepository.SaveorUpdate(objHospital);
                log.Info("Hospital info Added Successfully");
                return ConvertTODTO(hospital);
            }
            catch(Exception ex)
            {
                log.ErrorFormat("Exception occured while Adding new Hospital Info Ex:{0}", ex.Message);
                return null;

            }
        }

        public List<HospitalDTO> GetAllHospitals()
        {
            try
            {

                List<HospitalDTO> hospitalDTOList = new List<HospitalDTO>();
                IEnumerable<Hospital> hospitalDTO = _hospitalRepository.GetAll();
                foreach (var hospital in hospitalDTO)
                {
                    var objhospitalDTO = ConvertTODTO(hospital);
                    hospitalDTOList.Add(objhospitalDTO);

                }
                return hospitalDTOList;
            }
            catch(Exception ex)
            {
                log.ErrorFormat("Exception occured while retreiving list of Hospital  Details Info Ex:{0}", ex.Message);
                return null;

            }

        }

        public HospitalDTO GetHospitalsByID(int hospitalID)
        {
            try
            {
                var hospital = _hospitalRepository.GetHospitalByID(hospitalID);
                return ConvertTODTO(hospital);
            }
            catch(Exception ex)
            {
                log.ErrorFormat("Exception occured while retreiving Hospital Info Info Ex:{0}", ex.Message);
                return null;

            }
        }

        public Hospital ConvertTOModel(HospitalDTO obj)
        {

            var Hospital = new Hospital()
            {
                HospitalID = obj.HospitalID,
                Name = obj.Name,
                PhoneNumber = obj.PhoneNumber,
                EmailID = obj.EmailID,
                Address = obj.Address

            };
            return Hospital;
        }

        public HospitalDTO ConvertTODTO(Hospital obj)
        {

            var HospitalDTO = new HospitalDTO()
            {
                HospitalID = obj.HospitalID,
                Name = obj.Name,
                PhoneNumber = obj.PhoneNumber,
                EmailID = obj.EmailID,
                Address = obj.Address

            };
            return HospitalDTO;
        }
    }
}
