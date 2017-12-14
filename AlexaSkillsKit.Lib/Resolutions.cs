using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaSkillsKit
{
    public class Resolutions
    {
        [JsonProperty("resolutionsPerAuthority", NullValueHandling = NullValueHandling.Ignore)]
        public IList<ResolutionAuthorityResult> ResolutionsPerAuthority { get; set; } = new List<ResolutionAuthorityResult>();

        public static Resolutions FromJson(JObject json)
        {
            Resolutions resolutions = null;

            if(json != null)
            {
                resolutions = new Resolutions
                {
                    ResolutionsPerAuthority =
                        json?.Value<JArray>("resolutionsPerAuthority").ToObject<List<ResolutionAuthorityResult>>()
                };
            }

            return resolutions;
        }
    }
}
