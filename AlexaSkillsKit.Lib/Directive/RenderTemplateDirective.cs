using AlexaSkillsKit.UI.RenderTemplate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaSkillsKit.Directive
{
    public class RenderTemplateDirective : IDirective
    {
        public string Type => "Display.RenderTemplate";

        public RenderTemplate Template { get; set; }
    }
}
