using System;

namespace Models
{
    public class InputDto
    {
        public int InputId { get; set; }
        public string Name { get; set; }

        public InputType DataType { get; set; }

        public string Placeholder { get; set; }

        public bool Required { get; set; }

        public int? TabIndex { get; set; }

        public int DefaultOrder { get; set; }

        public InputDto(int inputId, string name, InputType dataType, int defaultOrder, bool required = false, int? tabIndex = null, string placeHolder = null)
        {
            InputId = inputId;
            Name = name;
            DataType = dataType;
            Required = required;
            TabIndex = tabIndex;
            Placeholder = placeHolder;
            DefaultOrder = defaultOrder;
        }
    }


}
