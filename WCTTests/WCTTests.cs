using Windows.UI.Xaml.Tests.MUXControls.InteractionTests.Infra;
using Windows.UI.Xaml.Tests.MUXControls.InteractionTests.Common;
using Microsoft.Windows.Apps.Test.Foundation.Controls;
using System;
using System.Numerics;
using Common;
using System.Threading.Tasks;
using Microsoft.Windows.Apps.Test.Foundation;
using System.Threading;
using System.Runtime.InteropServices;
using Microsoft.Windows.Apps.Test.Foundation.Patterns;

using WEX.TestExecution;
using WEX.TestExecution.Markup;
using WEX.Logging.Interop;


namespace WCTTests
{

    [TestClass]
    public class WCTTests
    {
        public static TestApplicationInfo WinUICsUWPSampleApp
        {
            get
            {
                var arch = RuntimeInformation.ProcessArchitecture.ToString();
                return new TestApplicationInfo(
                    "52b9212c-97a9-4639-9426-3e1ea9c1569e",
                    "52b9212c-97a9-4639-9426-3e1ea9c1569e_vpw621za47p9m!App",
                    "52b9212c-97a9-4639-9426-3e1ea9c1569e_vpw621za47p9m",
                    "[Debug] Windows Community Toolkit Sample App",
                    "Microsoft.Toolkit.Uwp.SampleApp.exe",
                    "Microsoft.Toolkit.Uwp.SampleApp_6.1.2.0_" + arch + "_Debug" // Installer name
                );
            }
        }

        public static TestSetupHelper.TestSetupHelperOptions TestSetupHelperOptions
        {
            get
            {
                return new TestSetupHelper.TestSetupHelperOptions()
                {
                    AutomationIdOfSafeItemToClick = ""
                };
            }
        }

        [ClassInitialize]
        [TestProperty("RunAs", "User")]
        [TestProperty("Classification", "ScenarioTestSuite")]
        [TestProperty("Platform", "Any")]
        public static void ClassInitialize(TestContext testContext)
        {
            TestEnvironment.Initialize(testContext, WinUICsUWPSampleApp);
        }

        [TestCleanup]
        public void TestCleanup()
        {

        }

        [ClassCleanupAttribute]
        public static void ClassCleanup()
        {
            TestEnvironment.AssemblyCleanupWorker(WinUICsUWPSampleApp);
        }

        [TestMethod]
        public void SimpleLaunchTest()
        {
            var textBlock = new TextBlock(FindElement.ByName("Get Started"));
            Verify.IsNotNull(textBlock);
            Verify.AreEqual(textBlock.DocumentText, "Get Started");

            Log.Comment("Wait For Idle");
            Wait.ForIdle();
            Log.Comment("Done Waiting For Idle");
        }

        [TestMethod]
        public void NavigateTest1()
        {
            using (var setup = new TestSetupHelper(new string[] { }, TestSetupHelperOptions))
            {
                var controls = FindElement.ByName("Controls");

                controls.Click();

                Wait.ForIdle();

                var alignmentGrid = FindElement.ByName("AlignmentGrid");
                var scrollItem = new ScrollItemImplementation(alignmentGrid);
                scrollItem.ScrollIntoView();
                Wait.ForIdle();

                alignmentGrid.Click();

                Wait.ForIdle();

                var textOnPage = "You can use the AlignmentGrid to check if your UI elements are corrected aligned";
                var textBlock = new TextBlock(FindElement.ByName(textOnPage));
                Verify.IsNotNull(textBlock);
                Verify.AreEqual(textBlock.DocumentText, textOnPage);
            }
        }

        [TestMethod]
        public void NavigateTest2()
        {
            using (var setup = new TestSetupHelper(new string[] { }, TestSetupHelperOptions))
            {
                var controls = FindElement.ByName("Controls");

                controls.Click();

                Wait.ForIdle();

                var item = FindElement.ByName("InAppNotification");
                var scrollItem = new ScrollItemImplementation(item);
                scrollItem.ScrollIntoView();
                Wait.ForIdle();

                item.Click();

                Wait.ForIdle();

                var textOnPage = "*if duration is less or equal 0, the notification will never be dismissed";
                var textBlock = new TextBlock(FindElement.ByName(textOnPage));
                Verify.IsNotNull(textBlock);
                Verify.AreEqual(textBlock.DocumentText, textOnPage);
            }
        }
    }
}
