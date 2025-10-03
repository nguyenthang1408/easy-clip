using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class ComboboxModel
    {
        public string Display { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return Display;
        }
    }
    public class ComboboxCmodeModel
    {
        public string Display { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }

        public override string ToString()
        {
            return Display;
        }
    }
    public class ComboboxVbeeModel
    {
        public string Display { get; set; }
        public string Value { get; set; }
        public string Language { get; set; }

        public override string ToString()
        {
            return Display;
        }
    }
}
