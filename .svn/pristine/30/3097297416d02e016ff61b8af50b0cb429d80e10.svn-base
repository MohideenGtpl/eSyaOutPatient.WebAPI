using eSyaOutPatient.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaOutPatient.IF
{
    public interface IDoctorClinicRepository
    {

        Task<List<DO_ClinicConsultationType>> GetClinicConsultationTypeByBKey(int businessKey);

        Task<List<DO_Specialty>> GetSpecialtyListByBKey(int businessKey);

        Task<List<DO_DoctorClinicSchedule>> GetDoctorScheduleListByClinicTypeSpecialtyDate(int businessKey,
            int clinicType, int consultationType,
            int specialtyID, DateTime scheduleDate);

        Task<List<DO_DoctorClinicSchedule>> GetDoctorScheduleListForDoctorDateRange(int businessKey,
            int clinicType, int consultationType,
            int specialtyID, int doctorID, DateTime fromDate, DateTime toDate);

        Task<List<DO_DoctorClinicSchedule>> GetDoctorScheduleListByClinicType(int businessKey,
             int clinicType, int consultationType,
             int specialtyId, int doctorId);
    }
}
