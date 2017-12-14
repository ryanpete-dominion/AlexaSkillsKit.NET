using AlexaSkillsKit.Directive;
using AlexaSkillsKit.Json;
using AlexaSkillsKit.Speechlet;
using AlexaSkillsKit.UI;
using AlexaSkillsKit.UI.RenderTemplate;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace AlexaSkillsKit.Tests.Directives
{
    public class DirectiveTests
    {
        [Fact]
        public void HintDirective()
        {
            const string TestDataFile = @"TestData\ResponseWithHintDirective.json";
            var expectedJSONObject = JObject.Parse(File.ReadAllText(TestDataFile));

            var hintDirective = new HintDirective();
            hintDirective.Hint = new HintItem { Text = "your hint text" };

            var testResponse = new SpeechletResponse();
            testResponse.Directives.Add(hintDirective);

            var responseEnvelope = new SpeechletResponseEnvelope();
            responseEnvelope.Response = testResponse;
            var jsonResponse = responseEnvelope.ToJson();

            Assert.Equal(JsonConvert.SerializeObject(expectedJSONObject), jsonResponse);
        }

        [Fact]
        public void RenderTemplateDirective_BodyTemplate1()
        {
            const string TestDataFile = @"TestData\ResponseWithRenderTemplateDirectiveAndBodyTemplate1.json";
            var expectedJSONObject = JObject.Parse(File.ReadAllText(TestDataFile));

            var renderTemplateDirective = new RenderTemplateDirective();
            renderTemplateDirective.Template = new BodyTemplate1
            {
                Title = "Body Template Title",
                TextContent = new TextContent
                {
                    PrimaryText = new TextContentItem
                    {
                        Text = "Hello world"
                    }
                }
            };

            var testResponse = new SpeechletResponse();
            testResponse.Directives.Add(renderTemplateDirective);

            var responseEnvelope = new SpeechletResponseEnvelope();
            responseEnvelope.Response = testResponse;
            var jsonResponse = responseEnvelope.ToJson();
            
            Assert.Equal(JsonConvert.SerializeObject(expectedJSONObject), jsonResponse);
        }

        [Fact]
        public void RenderTemplateDirective_BodyTemplate3()
        {
            const string TestDataFile = @"TestData\ResponseWithRenderTemplateDirectiveAndBodyTemplate3.json";
            var expectedJSONObject = JObject.Parse(File.ReadAllText(TestDataFile));

            var renderTemplateDirective = new RenderTemplateDirective();
            renderTemplateDirective.Template = new BodyTemplate3
            {
                Title = "Body Template Title",
                TextContent = new TextContent
                {
                    PrimaryText = new TextContentItem
                    {
                        Text = "Hello world"
                    }
                },
                Image = new ImageContent
                {
                    ContentDescription = "TestImageBodyTemplate3",
                    Sources = new List<ImageItem>
                    {
                        new ImageItem
                        {
                           HeightPixels = 100,
                           WidthPixels = 200,
                           Url = "urlplaceholder"
                        }
                    }
                },
                Token = "bodytemplate3token"
            };

            var testResponse = new SpeechletResponse();
            testResponse.Directives.Add(renderTemplateDirective);

            var responseEnvelope = new SpeechletResponseEnvelope();
            responseEnvelope.Response = testResponse;
            var jsonResponse = responseEnvelope.ToJson();

            Assert.Equal(JsonConvert.SerializeObject(expectedJSONObject), jsonResponse);
        }

        [Fact]
        public void RenderTemplateDirective_BodyTemplate6()
        {
            const string TestDataFile = @"TestData\ResponseWithRenderTemplateDirectiveAndBodyTemplate6.json";
            var expectedJSONObject = JObject.Parse(File.ReadAllText(TestDataFile));

            var renderTemplateDirective = new RenderTemplateDirective();
            renderTemplateDirective.Template = new BodyTemplate6
            {
                Title = "Body Template 6 Title",
                TextContent = new TextContent
                {
                    PrimaryText = new TextContentItem
                    {
                        Text = "Hello world"
                    }
                },
                Token = "bodytemplate6token"
            };

            var testResponse = new SpeechletResponse();
            testResponse.Directives.Add(renderTemplateDirective);

            var responseEnvelope = new SpeechletResponseEnvelope();
            responseEnvelope.Response = testResponse;
            var jsonResponse = responseEnvelope.ToJson();

            Assert.Equal(JsonConvert.SerializeObject(expectedJSONObject), jsonResponse);
        }

        [Fact]
        public void RenderTemplateDirective_ListTemplate1()
        {
            const string TestDataFile = @"TestData\ResponseWithRenderTemplateDirectiveAndListTemplate1.json";
            var expectedJSONObject = JObject.Parse(File.ReadAllText(TestDataFile));

            var renderTemplateDirective = new RenderTemplateDirective();
            var listTemplate = new ListTemplate1
            {
                Title = "List Template 1 Title",
                Token = "listtemplate1token"
            };

            AddListItemPlaceHolder(listTemplate, 1);
            AddListItemPlaceHolder(listTemplate, 2);
            AddListItemPlaceHolder(listTemplate, 3);
            renderTemplateDirective.Template = listTemplate;

            var testResponse = new SpeechletResponse();
            testResponse.Directives.Add(renderTemplateDirective);

            var responseEnvelope = new SpeechletResponseEnvelope();
            responseEnvelope.Response = testResponse;
            var jsonResponse = responseEnvelope.ToJson();

            Assert.Equal(JsonConvert.SerializeObject(expectedJSONObject), jsonResponse);
        }

        private static void AddListItemPlaceHolder(ListTemplate1 listTemplate, int indexId)
        {
            listTemplate.ListItems.Add(new ListItem
            {
                Token = $"item{indexId}",
                TextContent = new TextContent { PrimaryText = new TextContentItem { Type = "PlainText", Text = $"Item {indexId}" } },
                Image = new ImageContent { Sources = new List<ImageItem> { new ImageItem { Url = $"placeholder{indexId}" } } }
            });
        }
    }
}
