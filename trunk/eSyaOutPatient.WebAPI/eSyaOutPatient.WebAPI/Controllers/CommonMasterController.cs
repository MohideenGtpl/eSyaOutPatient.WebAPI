using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eSyaOutPatient.IF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eSyaOutPatient.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommonMasterController : ControllerBase
    {
        private readonly ICommonMasterRepository _commonMasterRepository;

        public CommonMasterController(ICommonMasterRepository commonMasterRepository)
        {
            _commonMasterRepository = commonMasterRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetApplicationCode(int codeType)
        {
            var ds = await _commonMasterRepository.GetApplicationCode(codeType);
            return Ok(ds);
        }
    }
}