using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSyaOutPatient.DO;
using eSyaOutPatient.IF;
using Microsoft.AspNetCore.Mvc;

namespace eSyaOutPatient.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientRegistrationController : ControllerBase
    {
        private readonly IPatientRegistrationRepository _patientRegistrationRepository;

        public PatientRegistrationController(IPatientRegistrationRepository patientRegistrationRepository)
        {
            _patientRegistrationRepository = patientRegistrationRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAppointmentDetailByDate(int businessKey, DateTime startDate, DateTime endDate, string vType, string status)
        {
            var ds = await _patientRegistrationRepository.GetAppointmentDetailByDate(businessKey, startDate, endDate,vType, status);
            return Ok(ds);
        }
        [HttpGet]
        public async Task<IActionResult> GetPatientByUHID(int businessKey, int uhid)
        {
            var ds = await _patientRegistrationRepository.GetPatientByUHID(businessKey, uhid);
            return Ok(ds);
        }
        [HttpGet]
        public async Task<IActionResult> GetAppointmentDetailByUHID(int businessKey, int uhid)
        {
            var ds = await _patientRegistrationRepository.GetAppointmentDetailByUHID(businessKey, uhid);
            return Ok(ds);
        }
        [HttpPost]
        public async Task<IActionResult> AddDummyVisit(DO_PatientAppointmentDetail obj)
        {
            var ds = await _patientRegistrationRepository.AddDummyVisit(obj.BusinessKey);
            return Ok(ds);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateVisitType(DO_PatientAppointmentDetail obj)
        {
            var ds = await _patientRegistrationRepository.UpdateVisitType(obj);
            return Ok(ds);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAppointmentToCompleted(DO_PatientAppointmentDetail obj)
        {
            var ds = await _patientRegistrationRepository.UpdateAppointmentToCompleted(obj);
            return Ok(ds);
        }
        [HttpPost]
        public async Task<IActionResult> InsertPatientReceipt(DO_PatientReceiptDetail obj)
        {
            var ds = await _patientRegistrationRepository.InsertPatientReceipt(obj);
            return Ok(ds);
        }
        [HttpGet]
        public async Task<IActionResult> GetPaymentDetail(int businessKey, int appKey)
        {
            var ds = await _patientRegistrationRepository.GetPaymentDetail(businessKey, appKey);
            return Ok(ds);
        }
        [HttpGet]
        public async Task<IActionResult> GetPatientList(int businessKey)
        {
            var ds = await _patientRegistrationRepository.GetPatientList(businessKey);
            return Ok(ds);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePatientData(DO_PatientData obj)
        {
            var ds = await _patientRegistrationRepository.UpdatePatientData(obj);
            return Ok(ds);
        }
    }
}