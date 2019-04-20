using System;
using System.Collections.Generic;
using System.Text;

namespace HospitalWaitingRoom
{
    class Scenario
    {
        public static List<Scenario> Scenarios =
            new List<Scenario>() {

                new Scenario() {
                    Name = "Scenario 1",
                    Arrivals = new List<Patient>() {
                        new Patient("a", 6, 0 ),
                        new Patient("b", 3, 0),
                        new Patient("c", 5, 0),
                        new Patient("d", 1, 0)
                    }
                },

                new Scenario() {
                    Name = "Scenario 2",
                    Arrivals = new List<Patient>() {
                        new Patient("e", 7, 0 ),
                        new Patient("f", 3, 0),
                        new Patient("g", 8, 0),
                        new Patient("h", 6, 0),
                        new Patient("i", 6, 0),
                        new Patient("j", 5, 0)
                    }
                },

                new Scenario() {
                    Name = "Scenario 3",
                    Arrivals = new List<Patient>() {
                        new Patient("k", 7, 0 ),
                        new Patient("l", 6, 0),
                        new Patient("m", 2, 0),
                        new Patient("n", 7, 0),
                        new Patient("o", 6, 0),
                        new Patient("p", 6, 5),
                        new Patient("q", 9, 5)
                    }
                },

                new Scenario() {
                    Name = "Scenario 4",
                    Arrivals = new List<Patient>() {
                        new Patient("r", 6, 0 ),
                        new Patient("s", 3, 0),
                        new Patient("t", 7, 0),
                        new Patient("u", 7, 5),
                        new Patient("v", 8, 5),
                        new Patient("w", 4, 5)
                    }
                },

                new Scenario() {
                    Name = "Scenario 5",
                    Arrivals = new List<Patient>() {
                        new Patient("x", 8, 0 ),
                        new Patient("y", 6, 0),
                        new Patient("z", 4, 0),
                        new Patient("aa", 7, 5),
                        new Patient("ab", 4, 5),
                        new Patient("ac", 2, 5),
                        new Patient("ad", 8, 5),
                        new Patient("ae", 7, 12),
                        new Patient("af", 3, 12),
                        new Patient("ag", 5, 12),
                        new Patient("ah", 8, 12),
                        new Patient("ai", 2, 12)
                    }
                },
            };

        public string Name { get; private set; }
        public List<Patient> Arrivals { get; private set; }
    }
}
