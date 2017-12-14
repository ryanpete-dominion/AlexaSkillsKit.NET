using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaSkillsKit.UI.RenderTemplate
{
    public class ListTemplate1 : RenderTemplate
    {
        public override string Type => "ListTemplate1";
        public IList<ListItem> ListItems { get; } = new List<ListItem>();
    }
}
