using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaSkillsKit.UI.RenderTemplate
{
    public class BodyTemplate3 : RenderTemplate
    {
        public override string Type => "BodyTemplate3";
        public TextContent TextContent { get; set; }
        public ImageContent Image { get; set; }
    }
}
