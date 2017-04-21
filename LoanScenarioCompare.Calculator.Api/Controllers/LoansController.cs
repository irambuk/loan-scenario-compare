using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoanScenarioCompare.Calculator.Data;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Net.Http.Headers;

namespace LoanScenarioCompare.Calculator.Api.Controllers
{
    [Route("api/[controller]")]
    public class LoansController : Controller
    {
        private readonly ISampleLoanProvider _sampleLoanProvider;
        private readonly ILoanComparer _loanComparer;
        
        public LoansController(ILoanComparer loanComparer, ISampleLoanProvider sampleLoanProvider)
        {
            _sampleLoanProvider = sampleLoanProvider;
            _loanComparer = loanComparer;
        }

        // GET api/loans
        [HttpGet]
        public IActionResult Get()
        {
            var loans = new Loan[] { _sampleLoanProvider.GetLoan1() , _sampleLoanProvider.GetLoan2() };
            return Ok(loans);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Loan loan)
        {
            var loanResult = _loanComparer.Calculate(loan);

            return Ok(loanResult);
        }
    }
}
