using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSyaOutPatient.IF;
using Microsoft.AspNetCore.Mvc;

namespace eSyaOutPatient.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorClinicController : ControllerBase
    {
        private readonly IDoctorClinicRepository _doctorClinicRepository;

        public DoctorClinicController(IDoctorClinicRepository doctorClinicRepository)
        {
            _doctorClinicRepository = doctorClinicRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetClinicConsultationTypeByBKey(int businessKey)
        {
            var ds = await _doctorClinicRepository.GetClinicConsultationTypeByBKey(businessKey);
            return Ok(ds);
        }


        [HttpGet]
        public async Task<IActionResult> GetSpecialtyListByBKey(int businessKey)
        {
            var ds = await _doctorClinicRepository.GetSpecialtyListByBKey(businessKey);
            return Ok(ds);
        }


        [HttpGet]
        public async Task<IActionResult> GetDoctorScheduleListByClinicTypeSpecialtyDate(int businessKey,
            int clinicType, int consultationType,
            int specialtyID, DateTime scheduleDate)
        {
            var ds = await _doctorClinicRepository.GetDoctorScheduleListByClinicTypeSpecialtyDate(businessKey, 
                clinicType, consultationType, specialtyID, scheduleDate);
            return Ok(ds);
        }


        [HttpGet]
        public async Task<IActionResult> GetDoctorScheduleListForDoctorDateRange(int businessKey,
         int clinicType, int consultationType,
         int specialtyID, int doctorID, DateTime fromDate, DateTime toDate)
        {
            var ds = await _doctorClinicRepository.GetDoctorScheduleListForDoctorDateRange(businessKey,
                clinicType, consultationType, specialtyID, doctorID, fromDate, toDate);
            return Ok(ds);
        }


        [HttpGet]
        public async Task<IActionResult> GetDoctorScheduleListByClinicType(int businessKey,
          int clinicType, int consultationType,
          int specialtyID, int doctorID)
        {
            var ds = await _doctorClinicRepository.GetDoctorScheduleListByClinicType(businessKey,
                 clinicType, consultationType, specialtyID, doctorID);
            return Ok(ds);
        }
    }
}