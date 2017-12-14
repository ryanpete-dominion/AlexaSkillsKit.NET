using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using Xunit;
using sut = AlexaSkillsKit;

namespace AlexaSkillsKit.Tests.Resolutions
{
    public class ResolutionsTests
    {
        /// <summary>
        /// A test with values for all properties/collections in the
        /// Resolutions object.
        /// </summary>
        [Fact]
        public void FromJsonTest1()
        {
            const string TestDataFile = @"TestData\ResolutionsTest1.json";
            var inputJson = File.ReadAllText(TestDataFile);
            var inputJObject = JObject.Parse(inputJson);

            sut::Resolutions expectedResult = new sut::Resolutions
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
            };
            sut::Resolutions actualResult = sut::Resolutions.FromJson(inputJObject);

            Assert.Equal(expectedResult.ResolutionsPerAuthority.Count, actualResult.ResolutionsPerAuthority.Count);
            Assert.Equal(expectedResult.ResolutionsPerAuthority[0].Authority, actualResult.ResolutionsPerAuthority[0].Authority);
            Assert.Equal(expectedResult.ResolutionsPerAuthority[0].Status.Code, actualResult.ResolutionsPerAuthority[0].Status.Code);
            Assert.Equal(expectedResult.ResolutionsPerAuthority[0].Values.Count, actualResult.ResolutionsPerAuthority[0].Values.Count);
            Assert.Equal(expectedResult.ResolutionsPerAuthority[0].Values[0].Value.Id, actualResult.ResolutionsPerAuthority[0].Values[0].Value.Id);
            Assert.Equal(expectedResult.ResolutionsPerAuthority[0].Values[0].Value.Name, actualResult.ResolutionsPerAuthority[0].Values[0].Value.Name);
        }

        /// <summary>
        /// Insures that if NULL is supplied to FromJson that
        /// null is the returned result
        /// </summary>
        [Fact]
        public void FromJsonTest2()
        {
            JObject inputJObject = null;

            sut::Resolutions actualResult = sut::Resolutions.FromJson(inputJObject);

            Assert.Null(actualResult);
        }

        /// <summary>
        /// Insures that if the JObject doesn't have any
        /// Values for the resolution defined that the Values
        /// collection is still properly initialized
        /// </summary>
        [Fact]
        public void FromJsonTest3()
        {
            const string TestDataFile = @"TestData\ResolutionsTest3.json";
            var inputJson = File.ReadAllText(TestDataFile);
            var inputJObject = JObject.Parse(inputJson);

            sut::Resolutions expectedResult = new sut::Resolutions
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
                        Values = new List<ResolutionValue>{ }
                    }
                }
            };
            sut::Resolutions actualResult = sut::Resolutions.FromJson(inputJObject);

            Assert.Equal(expectedResult.ResolutionsPerAuthority.Count, actualResult.ResolutionsPerAuthority.Count);
            Assert.Equal(expectedResult.ResolutionsPerAuthority[0].Authority, actualResult.ResolutionsPerAuthority[0].Authority);
            Assert.Equal(expectedResult.ResolutionsPerAuthority[0].Status.Code, actualResult.ResolutionsPerAuthority[0].Status.Code);
            Assert.Equal(expectedResult.ResolutionsPerAuthority[0].Values.Count, actualResult.ResolutionsPerAuthority[0].Values.Count);
        }
    }
}
