using DI_Home;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests_DI.Subtitute
{
    [TestFixture]
    public class EventRelatedTests
    {
        [Test]
        public void ctor_WhenViewIsLoaded_CallsViewRender()
        {
            var mockView = Substitute.For<IView>();
            var logger = Substitute.For<ILogger>();
            Presenter p = new Presenter(mockView, logger);
            mockView.Loaded += Raise.Event<Action>();

            mockView.Received().Render(Arg.Is<string>(s => s.Contains("Hello World")));
        }

        [Test]
        public void ctor_WhenViewhasError_CallsLogger()
        {
            var stubView = Substitute.For<IView>();
            var mockLogger = Substitute.For<ILogger>();

            Presenter p = new Presenter(stubView, mockLogger);
            stubView.ErrorOccured += Raise.Event<Action<string>>("fake error");

            mockLogger.Received().LogError(Arg.Is<string>(s => s.Contains("fake error")));
        }

        //[Test]
        //public void EventFiringManual()
        //{
        //    bool loadFired = false;
        //    SomeView view = new SomeView();
        //    view.Load += delegate
        //    {
        //        loadFired = true;
        //    };
        //    view.DoSomethingThatEventuallyFiresThisEvent();
        //    Assert.IsTrue(loadFired);
        //}
    }
}
