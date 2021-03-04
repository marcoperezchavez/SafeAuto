using BEApi.Models;
using BEApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BEApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SafeAutoController : ControllerBase
    {
        private ISafeAuto _safeAuto;

        public SafeAutoController(ISafeAuto safeAuto)
        {
            _safeAuto = safeAuto;

        }

        // GET: api/SafeAuto
        [Route("getAllSafeAutos")]
        [HttpGet]
        public async Task<IEnumerable<Models.SafeAuto>> GetAllSafeAutos()
        {
            return await _safeAuto.GetAllSafeAutos();
        }

        // GET: api/SafeAuto
        [Route("getAllInformationSafeAutos")]
        [HttpGet]
        public async Task<IEnumerable<InformationSafeAuto>> GetAllInformationSafeAutos()
        {
            return await _safeAuto.GetAllInformationSafeAutos();
        }

        // POST: api/SafeAuto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("newDriver")]
        [HttpPost]
        public async Task<ActionResult<Models.SafeAuto>> PostSafeAuto(Models.SafeAuto safeAuto)
        {
            return Ok(await _safeAuto.PostSafeAuto(safeAuto));
        }

        // POST: api/SafeAuto/AddInformation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Route("addInformation")]
        [HttpPost]
        public async Task<ActionResult<Models.SafeAuto>> PostSafeAutoInformation(InformationSafeAuto informationSafeAuto)
        {
            return Ok(await _safeAuto.PostSafeAutoInformation(informationSafeAuto));
        }

    }
}
