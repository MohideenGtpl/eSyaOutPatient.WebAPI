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
    public class AppointmentBookingController : ControllerBase
    {
        private readonly IAppointmentBookingRepository _appointmentBookingRepository;

        public AppointmentBookingController(IAppointmentBookingRepository appointmentBookingRepository)
        {
            _appointmentBookingRepository = appointmentBookingRepository;
        }

        [HttpPost]
        public async Task<IActionResult> InsertIntoDoctorSlotBooking(DO_PatientAppointmentDetail obj)
        {
            var ds = await _appointmentBookingRepository.InsertIntoDoctorSlotBooking(obj);
            return Ok(ds);
        }

        [HttpPost]
        public async Task<IActionResult> InsertIntoPatientAppointmentDetail(DO_PatientAppointmentDetail obj)
        {
            var ds = await _appointmentBookingRepository.InsertIntoPatientAppointmentDetail(obj);
            return Ok(ds);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePatientAppointmentDetail(DO_PatientAppointmentDetail obj)
        {
            var ds = await _appointmentBookingRepository.UpdatePatientAppointmentDetail(obj);
            return Ok(ds);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePatientAppointmentCancellation(DO_PatientAppointmentDetail obj)
        {
            var ds = await _appointmentBookingRepository.UpdatePatientAppointmentCancellation(obj);
            return Ok(ds);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePatientAppointmentReschedule(DO_PatientAppointmentDetail obj)
        {
            var ds = await _appointmentBookingRepository.UpdatePatientAppointmentReschedule(obj);
            return Ok(ds);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePatientAppointmentToUnScheduleWorkOrder(DO_PatientAppointmentDetail obj)
        {
            var ds = await _appointmentBookingRepository.UpdatePatientAppointmentToUnScheduleWorkOrder(obj);
            return Ok(ds);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDoctorAppointmentToUnScheduleWorkOrder(DO_PatientAppointmentDetail obj)
        {
            var ds = await _appointmentBookingRepository.UpdateDoctorAppointmentToUnScheduleWorkOrder(obj);
            return Ok(ds);
        }

        [HttpGet]
        public async Task<IActionResult> GetPatientAppointmentByDoctorDate(int businessKey, int specialtyId,
            int doctorId, DateTime fromDate, DateTime toDate)
        {
            var ds = await _appointmentBookingRepository.GetPatientAppointmentByDoctorDate(businessKey, specialtyId, doctorId, fromDate, toDate);
            return Ok(ds);
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctorUnScheduleWorkOrder(int businessKey, int specialtyId,
         int doctorId)
        {
            var ds = await _appointmentBookingRepository.GetDoctorUnScheduleWorkOrder(businessKey, specialtyId, doctorId, System.DateTime.Now);
            return Ok(ds);
        }

        [HttpGet]
        public async Task<IActionResult> GetPatientAppointmentDetailByAppkey(int businessKey, decimal appointmentKey)
        {
            var ds = await _appointmentBookingRepository.GetPatientAppointmentDetailByAppkey(businessKey, appointmentKey);
            return Ok(ds);
        }

        


    }
}