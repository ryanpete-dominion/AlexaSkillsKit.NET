using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaSkillsKit.UI
{
    public class ImageContent
    {
        public string ContentDescription { get; set; }
        public IList<ImageItem> Sources { get; set; } = new List<ImageItem>();
    }
}
