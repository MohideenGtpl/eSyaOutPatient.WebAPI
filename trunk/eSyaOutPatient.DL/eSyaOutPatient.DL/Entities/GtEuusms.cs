﻿using System;
using System.Collections.Generic;

namespace eSyaOutPatient.DL.Entities
{
    public partial class GtEuusms
    {
        public int UserId { get; set; }
        public string LoginId { get; set; }
        public string LoginDesc { get; set; }
        public bool EnforcePasswdPolicy { get; set; }
        public bool EnforcePasswdExpiration { get; set; }
        public string Password { get; set; }
        public int Isdcode { get; set; }
        public string MobileNumber { get; set; }
        public bool? AllowMobileLogin { get; set; }
        public string EMailId { get; set; }
        public byte[] Photo { get; set; }
        public string PhotoUrl { get; set; }
        public byte[] DigitalSignature { get; set; }
        public DateTime? LastPasswordChangeDate { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public string Otpnumber { get; set; }
        public DateTime? OtpgeneratedDate { get; set; }
        public string PreferredLanguage { get; set; }
        public DateTime? UserCreatedDate { get; set; }
        public bool IsUserAuthenticated { get; set; }
        public DateTime? UserAuthenticatedDate { get; set; }
        public bool IsUserDeactivated { get; set; }
        public DateTime? UserDeactivatedOn { get; set; }
        public string DeactivationReason { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }
    }
}
