using System.Collections.Generic;
using System.Web.UI;
using BrightcoveMapiWrapper.Model;
using BrightcoveMapiWrapper.Model.Containers;
using BrightcoveMapiWrapper.Model.Items;
using BrightcoveMapiWrapper.Serialization;
using System.Web.Script.Serialization;
using BrightcoveMapiWrapper.Util.Extensions;
using NUnit.Framework;

namespace BrightcoveOS.NET_MAPI_Wrapper.Tests.IntegrationTests.VideoWrite
{
    [TestFixture]
    public class VideoWriteCoreTests : VideoWriteTestBase
    {
        [Test]
        public void Deserialize_Video_Test_Basic()
        {
            JavaScriptSerializer serializer = BrightcoveSerializerFactory.GetSerializer();
            IDictionary<string, object> dictionary = new Dictionary<string, object>();
            var testrenditionCollection = new BrightcoveItemCollection<BrightcoveRendition>();
            var testrendition = new BrightcoveRendition();
            testrendition.ControllerType = ControllerType.AkamaiHd;
            testrenditionCollection.Add(testrendition);
            dictionary.Add("renditions", testrenditionCollection);

            var renditions =
                serializer.ConvertToType<BrightcoveItemCollection<BrightcoveRendition>>(dictionary["renditions"]);
            Assert.That(renditions[0].ControllerType, Is.EqualTo(ControllerType.AkamaiHd));
        }

        [Test]
        public void EnumExtension_ToBrightcoveName_Test()
        {
           var testrendition = new BrightcoveRendition();
           testrendition.ControllerType = ControllerType.AkamaiHd;
           var brightcoveName = testrendition.ControllerType.ToBrightcoveName();
           Assert.That(brightcoveName, Is.EqualTo("AKAMAI_HD"));
        }

        [Test]
        public void EnumExtension_ToBrightcoveEnum_Test()
        {
            const string brightcoveName = "AKAMAI_HD2";
            var testrendition = new BrightcoveRendition();
            testrendition.ControllerType = (brightcoveName).ToBrightcoveEnum<ControllerType>();
            Assert.That(testrendition.ControllerType, Is.EqualTo(ControllerType.AkamaiHd2));
        }

        [Test]
        public void EnumExtension_ToBrightcoveEnum_Test_InvalidValue()
        {
            const string brightcoveName = "BAD-CONTROLLERTYPE-NAME";
            var testrendition = new BrightcoveRendition();
            testrendition.ControllerType = (brightcoveName).ToBrightcoveEnum<ControllerType>();
            Assert.That(testrendition.ControllerType, Is.EqualTo(ControllerType.None));
        }
    }
}
