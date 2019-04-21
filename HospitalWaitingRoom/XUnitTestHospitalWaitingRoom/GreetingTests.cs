using System;
using System.Linq;
using Xunit;
using HospitalWaitingRoom;
using Serilog;
using System.Collections.Generic;

namespace XUnitTestHospitalWaitingRoom
{
    public class GreetingTests
    {
        private readonly ILogger _log;

        public GreetingTests(Xunit.Abstractions.ITestOutputHelper output)
        {
            _log = new LoggerConfiguration()
                .MinimumLevel.Information()
                .Enrich.FromLogContext()
                .WriteTo.Sink(new TestSink(output))
                .CreateLogger();
        }

        [Fact]
        public void WelcomeTestsMorning()
        {
            _log.Information("WelcomeTestsMorning started");
            var testDate = new DateTime(2000, 12, 1, 2, 30, 0);
            var results = Welcome.GreetingType(testDate);

            var expectations = "Good morning";

            Assert.Equal(expectations, results);
        }

        [Fact]
        public void WelcomeTestsMorning2()
        {
            _log.Information("WelcomeTestsMorning started");
            var testDate = new DateTime(2000, 12, 1, 11, 59, 0);
            var results = Welcome.GreetingType(testDate);

            var expectations = "Good morning";

            Assert.Equal(expectations, results);
        }

        [Fact]
        public void WelcomeTestsafternoon2()
        {
            _log.Information("WelcomeTestsafternoon2 started");
            var testDate = new DateTime(2000, 12, 1, 12, 00, 0);
            var results = Welcome.GreetingType(testDate);

            var expectations = "Good afternoon";

            Assert.Equal(expectations, results);
        }

        [Fact]
        public void WelcomeTestsafternoon()
        {
            _log.Information("WelcomeTestsafternoon started");
            var testDate = new DateTime(2000, 12, 1, 14, 45, 0);
            var results = Welcome.GreetingType(testDate);

            var expectations = "Good afternoon";

            Assert.Equal(expectations, results);
        }

        [Fact]
        public void WelcomeTestsevening()
        {
            _log.Information("WelcomeTestsevening started");
            var testDate = new DateTime(2000, 12, 1, 19, 02, 0);
            var results = Welcome.GreetingType(testDate);

            var expectations = "Good evening";

            Assert.Equal(expectations, results);
        }

        [Fact]
        public void WelcomeTestsevening2()
        {
            _log.Information("WelcomeTestsevening2 started");
            var testDate = new DateTime(2000, 12, 1, 23, 59, 0);
            var results = Welcome.GreetingType(testDate);

            var expectations = "Good evening";

            Assert.Equal(expectations, results);
        }


    }
}
