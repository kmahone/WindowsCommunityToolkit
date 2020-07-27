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
    // This is marked as a test class to make sure our AssemblyInitialize and AssemblyCleanup
    // fixtures get executed.  It won't actually host any tests.
    [TestClass]
    public class TestAssembly
    {
        [AssemblyInitialize]
        [TestProperty("CoreClrProfile", ".NETCoreApp2.1")]
        [TestProperty("RunFixtureAs:Assembly", "ElevatedUserOrSystem")]
        public static void AssemblyInitialize(TestContext testContext)
        {
            TestEnvironment.AssemblyInitialize(testContext);
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            TestEnvironment.AssemblyCleanup();
        }
    }
}
