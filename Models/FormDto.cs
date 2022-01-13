using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class FormDto
    {
        public int FormId { get; set; }

        public List<InputDto> Fields { get; set; } = new List<InputDto>();

        public FormDto(int formId, List<InputDto> fields)
        {
            FormId = formId;
            Fields = fields;
        }
    }
}
