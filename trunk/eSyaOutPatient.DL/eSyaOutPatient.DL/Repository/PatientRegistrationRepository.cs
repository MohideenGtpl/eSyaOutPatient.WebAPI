﻿using eSyaOutPatient.DL.Entities;
using eSyaOutPatient.DO;
using eSyaOutPatient.DO.StaticVariables;
using eSyaOutPatient.IF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSyaOutPatient.DL.Repository
{
    public class PatientRegistrationRepository : IPatientRegistrationRepository
    {
        public async Task<List<DO_PatientAppointmentDetail>> GetAppointmentDetailByDate(int businessKey, DateTime startDate, DateTime endDate, string vType, string status)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = await db.GtEopaph
                      .Join(db.GtEopapd,
                          h => new { h.BusinessKey, h.AppointmentKey },
                          d => new { d.BusinessKey, d.AppointmentKey },
                          (h, d) => new { h, d })
                         .Where(w =>
                                     w.h.BusinessKey == businessKey
                                     && w.h.AppointmentDate.Date >= startDate.Date
                                     && w.h.AppointmentDate.Date <= endDate.Date
                                     && (w.h.EpisodeType == vType || vType == "A")
                                     && (w.h.AppointmentStatus == status || status == "A")
                                     && !w.h.UnScheduleWorkOrder
                                     && w.h.ActiveStatus && w.d.ActiveStatus
                                     )
                         .AsNoTracking()
                         .Select(r => new DO_PatientAppointmentDetail
                         {
                             AppointmentKey = r.h.AppointmentKey,
                             UHID = r.d.Uhid,
                             AppointmentDate = r.h.AppointmentDate,
                             AppointmentFromTime = r.h.AppointmentFromTime,
                             Duration = r.h.Duration,
                             StartDate = r.h.AppointmentDate.Date.Add(r.h.AppointmentFromTime),
                             EndDate = r.h.AppointmentDate.Date.Add(r.h.AppointmentFromTime).AddMinutes(r.h.Duration),
                             PatientName = r.d.PatientFirstName + " " + r.d.PatientMiddleName + " " + r.d.PatientLastName,
                             PatientFirstName = r.d.PatientFirstName,
                             PatientLastName = r.d.PatientLastName,
                             Gender = r.d.Gender,
                             DateOfBirth = r.d.DateOfBirth,
                             PatientMobileNumber = r.d.MobileNumber,
                             PatientEmailID = r.d.EmailId,
                             EpisodeType = r.h.EpisodeType,
                             IsSponsored = r.d.IsSponsored,
                             AppointmentStatus = r.h.AppointmentStatus,
                             RequestChannel = r.h.RequestChannel,
                             PaymentReceived = r.h.PaymentReceived,
                             VisitType = r.h.VisitType,
                             StrCreatedBy = db.GtEuusms.Where(x => x.UserId == r.h.CreatedBy).FirstOrDefault().LoginId,
                             PatientID = db.GtEfoppr.Where(w => w.RUhid == r.d.Uhid).Select(s => s.PatientId).FirstOrDefault()

                         }).ToListAsync();

                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<DO_PatientAppointmentDetail>> GetPatientByUHID(int businessKey, int uhid)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = await db.GtEfoppr

                         .Where(w =>
                                     w.BusinessKey == businessKey
                                     && w.RUhid == uhid
                                     && w.ActiveStatus
                                     )
                         .AsNoTracking()
                         .Select(r => new DO_PatientAppointmentDetail
                         {
                             UHID = Convert.ToInt32(r.RUhid),
                             PatientName = r.FirstName + " " + r.LastName,
                             PatientFirstName = r.FirstName,
                             PatientLastName = r.LastName,
                             Gender = r.Gender,
                             DateOfBirth = r.DateOfBirth,
                             PatientMobileNumber = r.MobileNumber,
                             PatientEmailID = r.EMailId,
                             PatientID = r.PatientId
                         }).ToListAsync();
                    var Age = Convert.ToInt32((DateTime.Today.Subtract(Convert.ToDateTime(ds[0].DateOfBirth)).TotalDays) / 365.25);
                    ds[0].Age = Age;

                    

                    //Get Last Hieght
                    var _height = db.GtOpclin
                        .Where(w => w.BusinessKey == businessKey && w.Uhid == uhid && w.ClcontrolId == "BM-2" && w.ActiveStatus)
                        .Select(s => new DO_ControlValue
                        {
                            Value = s.Value,
                            TransactionDate = s.TransactionDate
                        }
                        )
                        .OrderByDescending(o => o.TransactionDate).FirstOrDefault();
                    if (_height != null)
                    {
                        ds[0].Height = _height.Value;
                    }
                    
                    //Caculate Duration from Last Surgery
                    var adm_date = db.GtOpclin
                        //.Where(w => w.BusinessKey == businessKey && w.Uhid == uhid && (w.ClcontrolId == "FS1-1" || w.ClcontrolId == "FS3-1" || w.ClcontrolId == "FS4-1"))
                        .Where(w => w.BusinessKey == businessKey && w.Uhid == uhid && (w.ClcontrolId == "FS3-1" || w.ClcontrolId == "FS4-1"))
                        .Select(s => new DO_ControlValue
                        {
                            Value = s.Value,
                            TransactionDate = s.TransactionDate
                        }
                        )
                        .OrderByDescending(o => o.Value).FirstOrDefault();
                    var dur = 0;
                    if (adm_date != null)
                    {
                        dur = Convert.ToInt32((DateTime.Today.Subtract(Convert.ToDateTime(adm_date.Value)).TotalDays));

                        //Get Surgery Name
                        var _type = "";
                        var sur = db.GtOpclin
                            .Where(w => w.BusinessKey == businessKey && w.Uhid == uhid && (w.ClcontrolId == "FS4-5-18" || w.ClcontrolId == "FS3-5") && w.TransactionDate == adm_date.TransactionDate)
                            .Select(s => new DO_ControlValue
                            {
                                CLControlID = s.ClcontrolId,
                                Value = s.Value,
                                TransactionDate = s.TransactionDate
                            }
                            )
                            .OrderByDescending(o => o.TransactionDate).FirstOrDefault();

                        var sur_type = db.GtOpclin
                                                        .Where(w => w.BusinessKey == businessKey && w.Uhid == uhid && w.ClcontrolId == "FS0-1" && (w.Value == "FS3" || w.Value == "FS4") && w.TransactionDate == adm_date.TransactionDate)
                                                        .Select(s => new DO_ControlValue
                                                        {
                                                            CLControlID = s.ClcontrolId,
                                                            Value = s.Value,
                                                            TransactionDate = s.TransactionDate
                                                        }
                                                        )

                                                        .OrderByDescending(o => o.TransactionDate).FirstOrDefault();
                        if (sur_type != null)
                        {
                            if (sur_type.Value == "FS3")
                            {
                                _type = "Primary";

                                // Get Approach
                                var _approach = db.GtOpclin
                                    .Where(w => w.BusinessKey == businessKey && w.Uhid == uhid && w.ClcontrolId == "FS3-2" && w.TransactionDate == adm_date.TransactionDate)
                                    .Select(s => new DO_ControlValue
                                    {
                                       CLControlID = s.ClcontrolId,
                                       Value = s.Value,
                                       TransactionDate = s.TransactionDate
                                    }
                                    )
                                    .OrderByDescending(o => o.TransactionDate).FirstOrDefault();
                                ds[0].Approach = _approach.Value;

                                // Get Anesthesia
                                var _anesthesia = db.GtOpclin
                                    .Where(w => w.BusinessKey == businessKey && w.Uhid == uhid && w.ClcontrolId == "FS3-3" && w.TransactionDate == adm_date.TransactionDate)
                                    .Select(s => new DO_ControlValue
                                    {
                                       CLControlID = s.ClcontrolId,
                                       Value = s.Value,
                                       TransactionDate = s.TransactionDate
                                    }
                                    )
                                    .OrderByDescending(o => o.TransactionDate).FirstOrDefault();
                                ds[0].Anesthesia = _anesthesia.Value;

                            }
                            else if (sur_type.Value == "FS4")
                            {
                                _type = "Revisional";

                                // Get Approach
                                var _approach = db.GtOpclin
                                    .Where(w => w.BusinessKey == businessKey && w.Uhid == uhid && w.ClcontrolId == "FS4-2" && w.TransactionDate == adm_date.TransactionDate)
                                    .Select(s => new DO_ControlValue
                                    {
                                        CLControlID = s.ClcontrolId,
                                        Value = s.Value,
                                        TransactionDate = s.TransactionDate
                                    }
                                    )
                                    .OrderByDescending(o => o.TransactionDate).FirstOrDefault();
                                ds[0].Approach = _approach.Value;

                                // Get Anesthesia
                                var _anesthesia = db.GtOpclin
                                    .Where(w => w.BusinessKey == businessKey && w.Uhid == uhid && w.ClcontrolId == "FS4-3" && w.TransactionDate == adm_date.TransactionDate)
                                    .Select(s => new DO_ControlValue
                                    {
                                        CLControlID = s.ClcontrolId,
                                        Value = s.Value,
                                        TransactionDate = s.TransactionDate
                                    }
                                    )
                                    .OrderByDescending(o => o.TransactionDate).FirstOrDefault();
                                ds[0].Anesthesia = _anesthesia.Value;
                            }
                        }
                        if (sur != null && sur.Value == "12")
                        {
                            var sur_name = new DO_ControlValue();
                            if (sur.CLControlID == "FS4-5-18")
                            {
                                sur_name = db.GtOpclin
                                                        .Where(w => w.BusinessKey == businessKey && w.Uhid == uhid && w.ClcontrolId == "FS4-16-1" && w.TransactionDate == adm_date.TransactionDate)
                                                        .Select(s => new DO_ControlValue
                                                        {
                                                            CLControlID = s.ClcontrolId,
                                                            Value = s.Value,
                                                            TransactionDate = s.TransactionDate
                                                        }
                                                        )
                                                        .OrderByDescending(o => o.TransactionDate).FirstOrDefault();
                            }
                            else if (sur.CLControlID == "FS3-5")
                            {
                                sur_name = db.GtOpclin
                                                       .Where(w => w.BusinessKey == businessKey && w.Uhid == uhid && w.ClcontrolId == "FS3-8-1" && w.TransactionDate == adm_date.TransactionDate)
                                                       .Select(s => new DO_ControlValue
                                                       {
                                                           CLControlID = s.ClcontrolId,
                                                           Value = s.Value,
                                                           TransactionDate = s.TransactionDate
                                                       }
                                                       )
                                                       .OrderByDescending(o => o.TransactionDate).FirstOrDefault();
                            }
                            ds[0].SurgeryCode = "12";
                            ds[0].SurgeryName = sur_name.Value + " - " + _type;
                            //ds[0].SurgeryDate = sur.TransactionDate;
                            ds[0].SurgeryDate = Convert.ToDateTime(adm_date.Value);
                        }
                        else if (sur != null)
                        {
                            ds[0].SurgeryCode = sur.Value;
                            ds[0].SurgeryName = " - " + _type;
                            ds[0].SurgeryDate = Convert.ToDateTime(adm_date.Value);
                        }
                        else
                        {
                            ds[0].SurgeryCode = "0";
                            ds[0].SurgeryName = "";
                        }
                    }
                    ds[0].Duration = dur;



                    ////Get BMI
                    //var bmi = db.GtOpclin
                    //   .Where(w => w.BusinessKey == businessKey && w.Uhid == uhid && w.ClcontrolId == "BM-3" && w.ActiveStatus)
                    //   .Select(s => new DO_ControlValue
                    //   {
                    //       Value = s.Value,
                    //       TransactionDate = s.TransactionDate
                    //   }
                    //   )
                    //   //.OrderByDescending(o => o.TransactionDate).FirstOrDefault();
                    //   .OrderByDescending(o => o.TransactionDate).ToList();
                    //if (bmi.Count != 0)
                    //{
                    //    ds[0].BMI = bmi.LastOrDefault().Value + " - " + bmi.First().Value;
                    //}


                    //Get Weight
                    var bmi = db.GtOpclin
                       .Where(w => w.BusinessKey == businessKey && w.Uhid == uhid && w.ClcontrolId == "BM-1" && w.ActiveStatus)
                       .Select(s => new DO_ControlValue
                       {
                           Value = s.Value,
                           TransactionDate = s.TransactionDate,
                           VisitNumber=s.Vnumber
                       }
                       )
                       //.OrderByDescending(o => o.TransactionDate).FirstOrDefault();
                       .OrderByDescending(o => o.TransactionDate).ToList();
                    if (bmi.Count != 0)
                    {
                        var PO_w = bmi.FindAll(w => w.VisitNumber == 0).LastOrDefault();
                        if(PO_w != null)
                        {
                            ds[0].BMI = bmi.FindAll(w=> w.VisitNumber==0).LastOrDefault().Value + " - " + bmi.FindAll(w => w.VisitNumber != 0).First().Value;
                        }
                        else
                        {
                            ds[0].BMI = bmi.LastOrDefault().Value + " - " + bmi.First().Value;
                        }
                        
                    }


                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<DO_PatientAppointmentDetail>> GetAppointmentDetailByUHID(int businessKey, int uhid)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = await db.GtEopaph
                      .Join(db.GtEopapd,
                          h => new { h.BusinessKey, h.AppointmentKey },
                          d => new { d.BusinessKey, d.AppointmentKey },
                          (h, d) => new { h, d })
                         .Where(w =>
                                     w.h.BusinessKey == businessKey
                                     && w.d.Uhid == uhid
                                     && w.h.AppointmentStatus != "AP"
                                     && w.h.AppointmentStatus != "CN"
                                     && !w.h.UnScheduleWorkOrder
                                     && w.h.ActiveStatus && w.d.ActiveStatus
                                     )
                         .AsNoTracking()
                         .Select(r => new DO_PatientAppointmentDetail
                         {
                             AppointmentKey = r.h.AppointmentKey,
                             UHID = r.d.Uhid,
                             AppointmentDate = r.h.AppointmentDate,
                             AppointmentFromTime = r.h.AppointmentFromTime,
                             Duration = r.h.Duration,
                             StartDate = r.h.AppointmentDate.Date.Add(r.h.AppointmentFromTime),
                             EndDate = r.h.AppointmentDate.Date.Add(r.h.AppointmentFromTime).AddMinutes(r.h.Duration),
                             PatientName = r.d.PatientFirstName + " " + r.d.PatientMiddleName + " " + r.d.PatientLastName,
                             PatientFirstName = r.d.PatientFirstName,
                             PatientLastName = r.d.PatientLastName,
                             Gender = r.d.Gender,
                             DateOfBirth = r.d.DateOfBirth,
                             PatientMobileNumber = r.d.MobileNumber,
                             PatientEmailID = r.d.EmailId,
                             EpisodeType = r.h.EpisodeType,
                             IsSponsored = r.d.IsSponsored,
                             AppointmentStatus = r.h.AppointmentStatus

                         }).OrderByDescending(o => o.AppointmentDate).ThenByDescending(o => o.AppointmentKey).ToListAsync();

                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<DO_ReturnParameter> AddDummyVisit(int businessKey)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var financialYear = db.GtEcclco.Where(w =>
                                                             w.BusinessKey == businessKey
                                                        && System.DateTime.Now.Date >= w.FromDate.Date
                                                        && System.DateTime.Now.Date <= w.TillDate.Date)
                                            .First().FinancialYear;
                        var ap_no = await db.GtEcdcbn
                                        .Where(w => w.BusinessKey == businessKey
                                            && w.FinancialYear == financialYear
                                            && w.DocumentId == 101).FirstOrDefaultAsync();
                        ap_no.CurrentDocNumber = ap_no.CurrentDocNumber + 1;

                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = ap_no.CurrentDocNumber.ToString() };
                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }
        public async Task<DO_ReturnParameter> UpdateVisitType(DO_PatientAppointmentDetail obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var app = db.GtEopaph.Where(w => w.AppointmentKey == obj.AppointmentKey && w.ActiveStatus).FirstOrDefault();
                        if (app != null)
                        {
                            if (app.AppointmentStatus != "AP")
                            {
                                return new DO_ReturnParameter() { Status = false, Message = "Only non-registered appointments can be edited" };
                            }
                            else
                            {
                                app.EpisodeType = obj.EpisodeType;
                                app.ModifiedBy = obj.UserID;
                                app.ModifiedOn = System.DateTime.Now;
                                app.ModifiedTerminal = obj.TerminalID;

                                //get new consultation id
                                var cons = await db.GtEsopcl
                                    .Where(w => w.BusinessKey == obj.BusinessKey && w.ActiveStatus && w.ClinicId == app.ClinicId)
                                    .Select(x => new DO_ClinicConsultationType
                                    {
                                        ConsultationType = x.ConsultationId,
                                        ConsultationTypeCode = db.GtEcapcd.Where(a => a.ApplicationCode == x.ConsultationId).FirstOrDefault().ShortCode,
                                    }).OrderBy(o => o.ClinicDesc).ThenBy(o => o.ConsultationDesc).ToListAsync();
                                cons = cons.FindAll(f => f.ConsultationTypeCode == obj.EpisodeType);
                                app.ConsultationId = cons[0].ConsultationType;

                                var app_sr = db.GtEopasr.Where(w => w.AppointmentKey == obj.AppointmentKey).FirstOrDefault();
                                if (app_sr != null)
                                {
                                    // var app_h = db.GtEopaph.Where(w => w.AppointmentKey == obj.AppointmentKey).FirstOrDefault();


                                    var sr = db.GtEsclst.Where(w => w.BusinessKey == obj.BusinessKey && w.ClinicId == app.ClinicId && w.ConsultationId == app.ConsultationId
                                    && w.RateType == 620004 && w.CurrencyCode == "EGP" && w.EffectiveTill == null && w.ActiveStatus).FirstOrDefault();

                                    //var sr = db.GtEsclst.Where(w => w.BusinessKey == obj.BusinessKey && w.ConsultationId == app.ConsultationId
                                    //&& w.RateType == 620004 && w.CurrencyCode == "EGP" && w.EffectiveTill == null && w.ActiveStatus).FirstOrDefault();
                                    if (sr != null)
                                    {
                                        app_sr.ServiceId = sr.ServiceId;
                                        app_sr.Rate = sr.Tariff;
                                        app_sr.NetAmount = sr.Tariff;
                                        app_sr.ModifiedBy = obj.UserID;
                                        app_sr.ModifiedOn = System.DateTime.Now;
                                        app_sr.ModifiedTerminal = obj.TerminalID;
                                    };
                                    //db.GtEopasr.Add(app_sr);
                                }
                            }

                            await db.SaveChangesAsync();
                            dbContext.Commit();
                            return new DO_ReturnParameter() { Status = true, Message = "Visit Updated" };
                        }


                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Invalid appointment" };
                        }



                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }
        public async Task<DO_ReturnParameter> UpdateAppointmentToCompleted(DO_PatientAppointmentDetail obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var app = db.GtEopaph.Where(w => w.AppointmentKey == obj.AppointmentKey && w.ActiveStatus).FirstOrDefault();
                        if (app != null)
                        {
                            if (app.PaymentReceived)
                            {
                                app.AppointmentStatus = "CM";
                                app.ModifiedBy = obj.UserID;
                                app.ModifiedOn = System.DateTime.Now;
                                app.ModifiedTerminal = obj.TerminalID;
                                await db.SaveChangesAsync();
                                dbContext.Commit();
                                return new DO_ReturnParameter() { Status = true, Message = "Visit Completed" };
                            }
                            else
                            {
                                return new DO_ReturnParameter() { Status = false, Message = "Please do a payment first" };
                            }

                        }
                        else
                        {
                            return new DO_ReturnParameter() { Status = false, Message = "Invalid appointment" };
                        }



                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }
        public async Task<DO_ReturnParameter> InsertPatientReceipt(DO_PatientReceiptDetail obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        obj.FinancialYear = System.DateTime.Now.Year;
                        obj.VoucherDate = System.DateTime.Now;

                        int DocID_Receipt = DocumentIdValues.opc_ReceiptId;
                        obj.FinancialYear = System.DateTime.Now.Year;
                        var dc_pr = db.GtEcdcbn
                                        .Where(w => w.BusinessKey == obj.BusinessKey && w.FinancialYear == obj.FinancialYear
                                            && w.DocumentId == DocID_Receipt).FirstOrDefault();
                        dc_pr.CurrentDocNumber++;
                        obj.VoucherDate = System.DateTime.Now;

                        obj.VoucherKey = decimal.Parse(obj.FinancialYear.ToString().Substring(2, 2) + obj.BusinessKey.ToString() + dc_pr.CurrentDocNumber);


                        GtEfprdt obj_PR = new GtEfprdt
                        {
                            BusinessKey = obj.BusinessKey,
                            FinancialYear = obj.FinancialYear,
                            BookTypeId = DocID_Receipt,
                            VoucherNumber = dc_pr.CurrentDocNumber,
                            VoucherKey = obj.VoucherKey,
                            VoucherType = obj.VoucherType,
                            VoucherDate = obj.VoucherDate,
                            VoucherAmount = obj.VoucherAmount,
                            //PaidorCollectedBy = obj.PaidorCollectedBy,
                            //DiscountAmount = obj.DiscountAmount,
                            //ConcessionAmount = obj.ConcessionAmount,
                            //TotalNetAmount = obj.TotalNetAmount,
                            CollectedAmount = obj.CollectedAmount,
                            RefundAmount = obj.RefundAmount,
                            CancelledAmount = obj.CancelledAmount,
                            Narration = obj.Narration,
                            BillDocumentKey = obj.BillDocumentKey,
                            ActiveStatus = true,
                            FormId = "0",
                            CreatedBy = 1,
                            CreatedOn = DateTime.Now,
                            CreatedTerminal = System.Environment.MachineName,
                        };
                        db.GtEfprdt.Add(obj_PR);

                        GtEfprpm gt_PM = new GtEfprpm
                        {
                            BusinessKey = obj_PR.BusinessKey,
                            VoucherKey = obj_PR.VoucherKey,
                            PaymentMode = 800001,

                            ActiveStatus = true,
                            CreatedBy = 0,
                            CreatedOn = DateTime.Now,
                            CreatedTerminal = System.Environment.MachineName
                        };
                        db.GtEfprpm.Add(gt_PM);

                        var ah = await db.GtEopaph.Where(w => w.AppointmentKey == obj.BillDocumentKey).FirstOrDefaultAsync();
                        if (obj.VoucherType == "R")
                            if (ah != null)
                                ah.PaymentReceived = true;

                        await db.SaveChangesAsync();
                        dbContext.Commit();

                        return new DO_ReturnParameter { Status = true };

                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw;
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw;
                    }
                }
            }



        }
        public async Task<DO_PatientReceiptDetail> GetPaymentDetail(int businessKey, int appKey)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var r = new DO_PatientReceiptDetail();
                    var p = await db.GtEfprdt
                        .Where(w => w.ActiveStatus && w.BusinessKey == businessKey && w.BillDocumentKey == appKey && w.VoucherType == "R")
                        .Select(s => s.VoucherAmount).SumAsync();
                    var f = await db.GtEfprdt
                        .Where(w => w.ActiveStatus && w.BusinessKey == businessKey && w.BillDocumentKey == appKey && w.VoucherType == "P")
                        .Select(s => s.VoucherAmount).SumAsync();
                    r.CollectedAmount = p;
                    r.RefundAmount = f;
                    r.TotalNetAmount = p - f;
                    return r;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<DO_PatientData>> GetPatientList(int businessKey)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ds = await db.GtEfoppr
                        .GroupJoin(db.GtMaptrg,
                        p=> p.Isdcode.ToString() +p.MobileNumber.ToString(),
                        u=> u.Isdcode.ToString() + u.MobileNumber.ToString(),
                        (p,u) => new { p,u=u.FirstOrDefault()})
                         .Where(w => w.p.BusinessKey == businessKey)
                         .AsNoTracking()
                         .Select(r => new DO_PatientData
                         {
                             PatientId = r.p.PatientId,
                             RUhid = r.p.RUhid,
                             FirstName = r.p.FirstName,
                             LastName = r.p.LastName,
                             PatientName = r.p.FirstName + " " + r.p.LastName,
                             DateOfBirth = r.p.DateOfBirth,
                             Gender = r.p.Gender,
                             Isdcode = r.p.Isdcode,
                             MobileNumber = r.p.MobileNumber,
                             EMailId = r.p.EMailId,
                             IsChatApplicable = r.p.IsChatApplicable,
                             IsGuideApplicable = r.p.IsGuideApplicable,
                             AppSignIn= r.u !=null ? r.u.AppSignIn : false
                         }).ToListAsync();

                    return ds;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<DO_ReturnParameter> UpdatePatientData(DO_PatientData obj)
        {
            using (var db = new eSyaEnterprise())
            {
                using (var dbContext = db.Database.BeginTransaction())
                {
                    try
                    {
                        var pat = db.GtEfoppr.Where(w => w.RUhid == obj.RUhid && w.BusinessKey == obj.BusinessKey).FirstOrDefault();
                        if (obj.MobileNumber != pat.MobileNumber)
                        {
                            var pa = db.GtEfoppr.Where(w => w.Isdcode == obj.Isdcode && w.MobileNumber == obj.MobileNumber && w.BusinessKey == obj.BusinessKey).FirstOrDefault();
                            if (pa != null)
                            {
                                return new DO_ReturnParameter() { Status = false, Message = "Mobile number already exists for MRN# " + pa.PatientId };
                            }
                        }

                        pat.FirstName = obj.FirstName;
                        pat.LastName = obj.LastName;
                        pat.DateOfBirth = obj.DateOfBirth;
                        pat.Isdcode = obj.Isdcode;
                        pat.MobileNumber = obj.MobileNumber;
                        pat.EMailId = obj.EMailId;
                        pat.IsChatApplicable = obj.IsChatApplicable;
                        pat.IsGuideApplicable = obj.IsGuideApplicable;

                        pat.ModifiedBy = obj.UserID;
                        pat.ModifiedOn = System.DateTime.Now;
                        pat.ModifiedTerminal = obj.TerminalID;

                        var _user = db.GtMaptrg.Where(w => w.Isdcode==obj.Isdcode && w.MobileNumber == obj.MobileNumber).FirstOrDefault();
                        if(_user != null)
                        {
                            _user.AppSignIn = obj.AppSignIn;
                            _user.ModifiedBy = obj.UserID;
                            _user.ModifiedOn = System.DateTime.Now;
                            _user.ModifiedTerminal = obj.TerminalID;
                        }
                        


                        await db.SaveChangesAsync();
                        dbContext.Commit();
                        return new DO_ReturnParameter() { Status = true, Message = "Patient Data Updated" };






                    }
                    catch (DbUpdateException ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        dbContext.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}
