using AlexaSkillsKit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaSkillsKit.Directive
{
    /// <summary>
    /// Used to display a Hint on the device
    /// </summary>
    public class HintDirective : IDirective
    {
        public string Type => "Hint";

        public HintItem Hint { get; set; }
    }
}
