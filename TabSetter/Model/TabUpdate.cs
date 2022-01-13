using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabSetter.Model
{
    public class TabUpdate
    {
        public int InputId { get; set; }
        public int TabIndex { get; set; }

        public TabUpdate(int inputId, int tabIndex)
        {
            InputId = inputId;
            TabIndex = tabIndex;
        }
    }
}
