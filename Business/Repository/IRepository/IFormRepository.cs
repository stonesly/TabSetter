using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IFormRepository
    {
        public FormDto GetForm(int formId);

        public void SaveForm(FormDto form);

        public void ResetForm(int formId);
    }
}
