using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabSetter.Service.IService
{
    public interface IFormService
    {
        public Task<FormDto> GetForm(int formId);

        public Task SaveForm(FormDto form);

        public Task ResetForm(int formId);
    }
}
