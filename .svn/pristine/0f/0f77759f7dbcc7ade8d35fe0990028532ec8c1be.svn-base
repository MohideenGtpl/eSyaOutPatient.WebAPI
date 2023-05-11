using eSyaOutPatient.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaOutPatient.IF
{
    public interface IAppointmentBookingRepository
    {
        Task<DO_ReturnParameter> InsertIntoDoctorSlotBooking(DO_PatientAppointmentDetail obj);

        Task<DO_ReturnParameter> InsertIntoPatientAppointmentDetail(DO_PatientAppointmentDetail obj);

        Task<DO_ReturnParameter> UpdatePatientAppointmentDetail(DO_PatientAppointmentDetail obj);

        Task<DO_ReturnParameter> UpdatePatientAppointmentCancellation(DO_PatientAppointmentDetail obj);

        Task<DO_ReturnParameter> UpdatePatientAppointmentReschedule(DO_PatientAppointmentDetail obj);

        Task<DO_ReturnParameter> UpdatePatientAppointmentToUnScheduleWorkOrder(DO_PatientAppointmentDetail obj);

        Task<DO_ReturnParameter> UpdateDoctorAppointmentToUnScheduleWorkOrder(DO_PatientAppointmentDetail obj);

        Task<List<DO_PatientAppointmentDetail>> GetPatientAppointmentByDoctorDate(int businessKey, int specialtyId,
            int doctorId, DateTime startDate, DateTime endDate);

        Task<List<DO_PatientAppointmentDetail>> GetDoctorUnScheduleWorkOrder(int businessKey, int specialtyId,
        int doctorId, DateTime fromDate);

        Task<DO_PatientAppointmentDetail> GetPatientAppointmentDetailByAppkey(int businessKey, decimal appointmentKey);

    }
}
