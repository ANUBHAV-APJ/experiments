using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SyncActivity;
using System.Activities;
using AsyncActivity;

namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestSyncActivity()
        {
            SampleSyncActivity syncActivity = new SampleSyncActivity();

            var x = WorkflowInvoker.Invoke(syncActivity);

        }

        [TestMethod]
        public void TestAsyncActivity()
        {
            SampleAsyncActivity asyncActivity = new SampleAsyncActivity();

            var x = WorkflowInvoker.Invoke(asyncActivity);
            Console.WriteLine(x.ToString());
        }
    }
}
