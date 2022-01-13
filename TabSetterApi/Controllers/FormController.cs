using Business.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabSetterApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormRepository _formRepository;

        public FormController(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        [HttpGet("{formId}")]
        public async Task<IActionResult> Get(int formId)
        {
            var form = _formRepository.GetForm(formId);
            return Ok(form);
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] FormDto form)
        {
            _formRepository.SaveForm(form);
            return Ok();
        }

        [HttpPost("{formId}")]
        public async Task<IActionResult> Reset(int formId)
        {
            _formRepository.ResetForm(formId);
            return Ok();
        }
    }
}
