using System;
using System.Collections.Generic;
using System.Text;

namespace eSyaOutPatient.DO
{
    public class DO_PreOperativeInformation
    {
        public int BusinessKey { get; set; }
        public int UHID { get; set; }
        public int VisitNumber { get; set; }
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; }
        public TimeSpan TransactionTime { get; set; }
        public int ChartNumber { get; set; }

        public string CLType { get; set; }
        public string CLControlID { get; set; }
        public string ValueType { get; set; }
        public string Value { get; set; }

        public List<DO_ControlValue> l_ControlValue { get; set; }

        public string StrCreatedBy { get; set; }

        public bool ActiveStatus { get; set; }
        public string FormID { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
    }

    public class DO_ControlValue
    {
        public string CLType { get; set; }
        public string CLControlID { get; set; }
        public string ValueType { get; set; }
        public string Value { get; set; }
        public DateTime TransactionDate { get; set; }
        public long VisitNumber { get; set; }
    }

}
