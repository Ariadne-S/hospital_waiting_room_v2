using Serilog;
using System;
using System.Collections.Generic;

namespace HospitalWaitingRoom
{
    public interface IScenarioBuilderOption {}
    public class AddAnotherPatient : IScenarioBuilderOption { }
    public class RunScenarioFromBuilder : IScenarioBuilderOption { }
    public class ReturnToMainMenu : IScenarioBuilderOption { }
    public class ExitFromBuilder : IScenarioBuilderOption { }
    public class InvalidOption : IScenarioBuilderOption { }

    public interface IScenarioBuilderResult { }
    public class ExitApp : IScenarioBuilderResult { }
    public class AddScenario : IScenarioBuilderResult {
        public AddScenario(Scenario newScenario)
        {
            NewScenario = newScenario;
        }
        public Scenario NewScenario { get; set; }
    }

    public static class ScenarioBuilder
    {
        public static IScenarioBuilderResult BuildScenario(ILogger log)
        {
            log.Information("Stating BuildScenario");
            Console.WriteLine("\nThank you for choosing to create a new scenario");
            Console.WriteLine("To begin, please type your scenario's name...");
            var name = Console.ReadLine();
            Console.WriteLine("Thank you\nFollow the prompts to add your first patient");
            var arrivals = new List<Patient>();
            arrivals.Add(AddNewPatient(arrivals.Count));
            
            while (true) {
                var command = RunOrSelectOption();
                if (command is ExitFromBuilder) {
                    return new ExitApp();
                } else if (command is AddAnotherPatient) {
                    arrivals.Add(AddNewPatient(arrivals.Count));
                } else if (command is ReturnToMainMenu) {
                    return new AddScenario(
                        new Scenario(name, arrivals)
                    );
                } else if (command is RunScenarioFromBuilder) {
                    App.RunScenario(log, new Scenario(name, arrivals));
                } else if (command is InvalidOption) {
                    Console.WriteLine("Your selection was not valid, please try again.");
                }
            }
        }

        public static Patient AddNewPatient(int patientCount)
        {
            var nextNumber = patientCount + 1;
            var patientId = GetNewPatientId(nextNumber);
            var patientSeverity = GetNewPatientSeverity(nextNumber);
            var patientArrivalTime = GetNewPatientArrivalTime(nextNumber);

            return new Patient(patientId, patientSeverity, patientArrivalTime);
        }

       
        private static string GetNewPatientId(int patientCount)
        {
            Console.WriteLine("{0}.1:\tWhat is the id or name for this patient?", patientCount);
            var retrievePatientId = Console.ReadLine().ToString();
            return retrievePatientId;
        }


        private static int GetNewPatientSeverity(int patientCount)
        {
            Console.WriteLine("{0}.2:\tWhat is the patient's severity? [1 - 10]", patientCount);
            var retrieveSeverityInput = Console.ReadLine();

            var severityInt = -1;
            while (
                !(int.TryParse(retrieveSeverityInput, out severityInt)
                && (severityInt > 0 && severityInt <= 10))
            ) {
                Console.WriteLine("Your input must be a number between 1 and 10, please try again.");
            }

            return severityInt;
    }

        private static int GetNewPatientArrivalTime(int patientCount)
        {
            Console.WriteLine("{0}.3:\tWhat time does this patient arrive> [0 - 1440]", patientCount);
            var retrieveArrivalTimeInput = Console.ReadLine();

            var arrivalInt = -1;
            while (
                !(int.TryParse(retrieveArrivalTimeInput, out arrivalInt)
                && (arrivalInt >= 0 && arrivalInt <= 1440))
            ) {
                Console.WriteLine("Your input must be a number between 0 and 1440, please try again.");
            }

            return arrivalInt;
        }


        private static IScenarioBuilderOption RunOrSelectOption()
        {
            Console.WriteLine("What would you like to do next?\n" +
                "\tA:\tAdd Another patient\n" +
                "\tR:\tRun scenario\n" +
                "\tE:\tSave and exit to main menu");
            var selection = Console.ReadLine().ToLower();

            if (selection == "q") {
                return new ExitFromBuilder();
            } else if (selection == "a") {
                return new AddAnotherPatient();
            } else if (selection == "r") {
                return new RunScenarioFromBuilder(); 
            } else if (selection == "e") {
                return new ReturnToMainMenu();
            } else return new InvalidOption();
        }

    }

}

