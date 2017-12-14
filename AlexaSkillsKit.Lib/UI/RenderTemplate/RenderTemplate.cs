using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaSkillsKit.UI.RenderTemplate
{
    public abstract class RenderTemplate
    {
        public virtual string Type { get; }
        public virtual string Token { get; set; }
        public virtual string BackButton => "VISIBLE";
        public virtual string BackgroundImage => null;
        public virtual string Title { get; set; }
    }
}
