using Business.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class MemoryFormRepository : IFormRepository
    {
        private static List<FormDto> _forms = new List<FormDto> { new FormDto(1, 
            new List<InputDto>
            {
                new InputDto(1,"Account Number", InputType.Text, 1, true, placeHolder: "0000000"),
                new InputDto(2, "Account Description", InputType.Text, 2),
                new InputDto(3, "Customer Number", InputType.Text, 3, placeHolder: "000000"),
                new InputDto(4, "Customer Name", InputType.Text, 4),
                new InputDto(5, "Transaction Date", InputType.Date, 5, true, placeHolder: DateTime.Now.ToString("MM/dd/yyyy")),
                new InputDto(6, "Due Date", InputType.Date, 6, true),
                new InputDto(7, "Reference Number", InputType.Text, 7),
                new InputDto(8, "Account Balance", InputType.Currency, 8, placeHolder: "$0.00"),
                new InputDto(9, "Outstanding Credits", InputType.Currency, 9, placeHolder: "$0.00")
            }) };

        public FormDto GetForm(int formId)
        {
            var form = _forms.FirstOrDefault(f => f.FormId == formId);
            form.Fields = form.Fields.OrderBy(f => f.DefaultOrder).ToList();
            return form;
        }

        public void ResetForm(int formId)
        {
            var form = _forms.Single(f => f.FormId == formId);
            form.Fields.ForEach(f => f.TabIndex = null);
        }

        public void SaveForm(FormDto form)
        {
            var formToReplace = _forms.Single(f => f.FormId == form.FormId);
            var index = _forms.IndexOf(formToReplace);

            _forms[index] = form;
        }
    }
}
