using HmsAPI.DataAccess;
using HmsAPI.DataAccess.Interface;
using HmsAPI.Dto;
using HmsAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HmsAPI.Services
{
    public class UserAppointmentService
    {
        public readonly IUserTableRepository _userTableRepository;
        public readonly IAppointmentRepository _appointmentRepository;
        public readonly IHospitalRepository _hospitalRepository;
        
      

        public UserAppointmentService(IUserTableRepository userTableRepository, IAppointmentRepository appointmentRepository, IHospitalRepository hospitalRepository)
        {
            _userTableRepository = userTableRepository;
            _appointmentRepository = appointmentRepository;
            _hospitalRepository = hospitalRepository;
        }

       
        public List<UserAppointmentDTO> GetUserAppointments(int userID)
        {
            var objUserAppoinytmentList = new List<UserAppointmentDTO>();
            var objAppointmnet = _appointmentRepository.GetAppointmentByUserID(userID);
            foreach (var objApp in objAppointmnet)
            {
                var objuser = _userTableRepository.GetUsersByDoctorID(objApp.DoctorID);
                var objhospital = _hospitalRepository.GetHospitalByDoctorID(objApp.DoctorID);
                UserAppointmentDTO userAppointmnetDTO = new UserAppointmentDTO
                {
                    AppointmentID = objApp.AppointmentID,
                    UserID = objApp.UserID,
                    DoctorID = objApp.DoctorID,
                    DoctorName = objuser.FirstName + " " + objuser.LastName,
                    StartTime = objApp.StartTime,
                    EndTime = objApp.EndTime,
                    HospitalName = objhospital.Name
                };
                objUserAppoinytmentList.Add(userAppointmnetDTO);

            }

            return objUserAppoinytmentList;

        }
}
}
