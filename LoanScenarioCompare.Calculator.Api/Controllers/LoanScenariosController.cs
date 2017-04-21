using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoanScenarioCompare.Calculator.Data;
using System.Net.Http;
using Newtonsoft.Json;

namespace LoanScenarioCompare.Calculator.Api.Controllers
{
    [Route("api/[controller]")]
    public class LoanScenariosController : Controller
    {
        private readonly ISampleLoanProvider _sampleLoanProvider;
        private readonly ILoanComparer _loanComparer;

        public LoanScenariosController(ILoanComparer loanComparer, ISampleLoanProvider sampleLoanProvider)
        {
            _sampleLoanProvider = sampleLoanProvider;
            _loanComparer = loanComparer;
        }

        // GET api/loanscenarios
        [HttpGet]
        public IActionResult Get()
        {
            var loanScenarios = new LoanScenario[] { _sampleLoanProvider.GetLoanScenario() };
            return Ok(loanScenarios);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]LoanScenario loanScenario)
        {
            var loanResults = _loanComparer.Compare(loanScenario.Loans);
            return Ok(loanResults);
        }
    }
}
