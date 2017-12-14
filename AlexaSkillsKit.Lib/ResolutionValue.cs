using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaSkillsKit
{
    public class ResolutionValue
    { 
        public ResolutionValueEntry Value { get; set; }
    }

    public class ResolutionValueEntry
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
