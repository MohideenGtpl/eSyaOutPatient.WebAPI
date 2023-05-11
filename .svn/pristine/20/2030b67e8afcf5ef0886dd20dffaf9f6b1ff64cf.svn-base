using eSyaOutPatient.DL.Entities;
using eSyaOutPatient.DO;
using eSyaOutPatient.IF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSyaOutPatient.DL.Repository
{
    public class CommonMasterRepository: ICommonMasterRepository
    {
        public async Task<List<DO_ApplicationCodes>> GetApplicationCode(int codeType)
        {
            try
            {
                using (var db = new eSyaEnterprise())
                {
                    var ac = await db.GtEcapcd
                        .Where(w => w.CodeType == codeType
                           && w.ActiveStatus)
                        .Select(x => new DO_ApplicationCodes
                        {
                            ApplicationCode = x.ApplicationCode,
                            CodeDesc = x.CodeDesc,
                        }).OrderBy(o => o.CodeDesc).ToListAsync();

                    return ac;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
