﻿using eSyaOutPatient.DO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eSyaOutPatient.IF
{
    public interface IOPRegistrationRepository
    {
        Task<DO_ReturnParameter> InsertInToPatientOPRegistration(DO_OPVisit obj);
        Task<DO_ReturnParameter> InsertInToPatientMaster(DO_PatientData obj);
        Task<List<DO_PatientProfile>> GetPatientSearch(string searchText);
    }
}
