using System;
using System.Collections.Generic;
using System.Text;
using Serilog;

namespace HospitalWaitingRoom
{
    public interface IUserCommand { }

    public class Exit : IUserCommand { }
    public class RunScenario : IUserCommand {
        public RunScenario(int senario)
        {
            Senario = senario;
        }
        public int Senario { get; }
    }
    public class BuildScenario : IUserCommand {}


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

        public static IUserCommand ScenarioOptions()
        {
            Console.WriteLine("Please input the corresponding key to enter a scenario, of Q to quit.");
            int i = 1;
            foreach (var scenario in Scenario.Scenarios ) {
                Console.WriteLine("\t{0}:\t{1}", i++, scenario.Name);
            }
            Console.WriteLine("\tn:\tBuild your own scenario");

            var selection = Console.ReadLine().ToLower();

            if (selection == "q") {
                return new Exit();
            } else if (int.TryParse(selection, out var num)) {
                return new RunScenario(num);
            } else if (selection == "n") {
                return new BuildScenario();
            } else {
                Console.WriteLine("\nUnfortunately your selection was not valid, please try again.");
                return ScenarioOptions();
            }
        }


    }
}
