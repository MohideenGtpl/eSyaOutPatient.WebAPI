﻿using System;
using System.Collections.Generic;

namespace eSyaOutPatient.DL.Entities
{
    public partial class GtEcdcbn
    {
        public int BusinessKey { get; set; }
        public int FinancialYear { get; set; }
        public int DocumentId { get; set; }
        public int StartDocNumber { get; set; }
        public int CurrentDocNumber { get; set; }
        public bool UsageStatus { get; set; }
        public bool ActiveStatus { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }
    }
}
