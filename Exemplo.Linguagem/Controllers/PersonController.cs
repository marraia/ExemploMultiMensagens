using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FR.Localizations.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exemplo.Linguagem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IStringLocalization _localization;

        public PersonController(IStringLocalization localization)
        {
            _localization = localization;
        }

        [HttpGet]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Get()
        {
            var message = _localization[KeyMessage.MandatoryData].Value;
            var message2 = _localization[KeyMessage.UserUnder, "Fernando"].Value;

            return Ok($"{message}\n{message2}");
        }
    }
}
