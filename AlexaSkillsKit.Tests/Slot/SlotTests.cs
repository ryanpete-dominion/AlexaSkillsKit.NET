using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using Xunit;
using sut=AlexaSkillsKit;

namespace AlexaSkillsKit.Tests.Slot
{
    public class SlotTests
    {
        [Fact]
        public void FromJson_AllProps()
        {
            const string TestDataFile = @"TestData\Slot_FromJson_AllProps.json";
            var expectedObject = new sut.Slu.Slot
            {
                Name = "TestSlot",
                Value = "TestSlotValue",
                Resolutions = new sut.Resolutions
                {
                    ResolutionsPerAuthority = new List<ResolutionAuthorityResult>
                    {
                        new ResolutionAuthorityResult
                        {
                            Authority = "test.resolutionAuthority",
                            Status = new ResolutionStatus
                            {
                                Code = "TEST_STATUSCODE"
                            },
                            Values = new List<ResolutionValue>
                            {
                                new ResolutionValue
                                {
                                    Value = new ResolutionValueEntry
                                    {
                                        Id="Test.ResolutionValueId",
                                        Name="Test.ResolutionValueName"
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var inputJson = File.ReadAllText(TestDataFile);
            var inputJObject = JObject.Parse(inputJson);
            
            var actualResult = sut.Slu.Slot.FromJson(inputJObject);

            Assert.Equal(expectedObject.Name, actualResult.Name);
            Assert.Equal(expectedObject.Value, actualResult.Value);

            // keeping this to just verifying the count as a more detailed
            // test is provided specifically addressing is this hydrated correctly
            Assert.Equal(expectedObject.Resolutions.ResolutionsPerAuthority.Count, actualResult.Resolutions.ResolutionsPerAuthority.Count);
        }

        [Fact]
        public void FromJson_NoResolutions()
        {
            const string TestDataFile = @"TestData\Slot_FromJson_NoResolutions.json";

            var inputJson = File.ReadAllText(TestDataFile);
            var inputJObject = JObject.Parse(inputJson);

            var actualResult = sut.Slu.Slot.FromJson(inputJObject);

            Assert.Null(actualResult.Resolutions);
        }
    }
}
