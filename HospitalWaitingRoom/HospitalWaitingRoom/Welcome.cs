using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace HospitalWaitingRoom
{
    public class Welcome
    {

        public static string GreetingType(DateTime currentTime)
        {
            int currentHour = currentTime.Hour;
            if (currentHour < 12) {
                Log.Information("As the current time is {Time} Hours, we can assume it is morning", currentHour);
                return "Good morning";
            } else if (currentHour >= 12 && currentHour < 16) {
                Log.Information("As the current time is {Time} Hours, we can assume it is afternoon", currentHour);
                return "Good afternoon";
            } else {
                Log.Information("As the current time is {Time} Hours, we can assume it is evening", currentHour);
                return "Good evening";
            }
        }
    
        public static void PrintWelcome()
        {
            string user = Environment.UserName;
            var greeting = GreetingType(DateTime.Now);
            Console.WriteLine("{0} {1}", greeting, user);
        }


    }
}
