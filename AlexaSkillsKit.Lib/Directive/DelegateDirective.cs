using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlexaSkillsKit.Slu;

namespace AlexaSkillsKit.Directive
{
    /// <summary>
    /// Used to return control for filling out a slot back
    /// to the DialogModel
    /// </summary>
    public class DelegateDirective : IDialogDirective
    {
        public string Type { get; set; } = "Dialog.Delegate";
        public Intent UpdatedIntent { get; set; }
    }
}
