using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaSkillsKit
{
    public class ResolutionAuthorityResult
    {
        public string Authority { get; set; }

        public ResolutionStatus Status { get; set; }
                
        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public IList<ResolutionValue> Values { get; set; } = new List<ResolutionValue>();
    }
}
