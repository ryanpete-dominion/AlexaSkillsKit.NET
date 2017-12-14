using AlexaSkillsKit.Directive;
using AlexaSkillsKit.Slu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaSkillsKit.Directive
{
    interface IDialogDirective : IDirective
    {
        Intent UpdatedIntent { get; set; }
    }
}
