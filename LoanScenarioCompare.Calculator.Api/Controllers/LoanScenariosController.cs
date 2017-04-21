﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoanScenarioCompare.Calculator.Data;

namespace LoanScenarioCompare.Calculator.Api.Controllers
{
    [Route("api/[controller]")]
    public class LoanScenariosController : Controller
    {
        private readonly ISampleLoanProvider _sampleLoanProvider;


        public LoanScenariosController(ISampleLoanProvider sampleLoanProvider)
        {
            _sampleLoanProvider = sampleLoanProvider;
        }

        // GET api/loanscenarios
        [HttpGet]
        public IEnumerable<LoanScenario> Get()
        {
            return new LoanScenario[] { _sampleLoanProvider.GetLoanScenario() };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private Loan GetSampleLoan()
        {
            var loan = new Loan();

            return loan;
        }
    }
}
