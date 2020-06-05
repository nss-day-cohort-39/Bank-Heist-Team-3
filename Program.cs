using System;
using System.Collections.Generic;
using System.Linq;

namespace Bank_Heist {
    class Program {
        static void Main (string[] args) {
            Hacker hacker = new Hacker ();
            Muscle muscle = new Muscle ();
            LockSpecialist lockSpecialist = new LockSpecialist ();
            Hacker hacker1 = new Hacker ();
            Muscle muscle1 = new Muscle ();

            hacker.Name = "Parker";
            hacker.PercentageCut = 50;
            hacker.SkillLevel = 78;

            muscle.Name = "steve";
            muscle.PercentageCut = 23;
            muscle.SkillLevel = 99;

            lockSpecialist.Name = "Michael";
            lockSpecialist.PercentageCut = 97;
            lockSpecialist.SkillLevel = 89;

            hacker1.Name = "Calvin";
            hacker1.PercentageCut = 11;
            hacker1.SkillLevel = 93;

            muscle1.Name = "Calvin";
            muscle1.PercentageCut = 96;
            muscle1.SkillLevel = 93;

            List<IRobber> rolodex = new List<IRobber> ();
            rolodex.Add (hacker);
            rolodex.Add (lockSpecialist);
            rolodex.Add (muscle);
            rolodex.Add (muscle1);
            rolodex.Add (hacker1);

            System.Console.WriteLine ($"Current operatives {rolodex.Count}");
            while (true) {
                System.Console.WriteLine ("Enter your crew member");
                string newCrewName = Console.ReadLine ();
                if (newCrewName == "") {
                    break;
                } else {
                    string speciality;
                    while (true) {
                        System.Console.WriteLine ("Pick speciality: Hacker, Muscle, Lock Specialist");
                        speciality = Console.ReadLine ().ToLower ();
                        if (speciality == "hacker" || speciality == "muscle" || speciality == "lock specialist") {
                            break;
                        } else {
                            System.Console.WriteLine ("You must choose hacker, muscle or lock specialist");
                        }
                    }
                    int num = -1;
                    while (true) {
                        System.Console.WriteLine ("Enter skill level");
                        bool newSkillLevel = int.TryParse (Console.ReadLine (), out num);

                        if (newSkillLevel == true && num > 0 && num <= 100) {
                            break;
                        } else {
                            System.Console.WriteLine ("Value must be between 1 and 100");

                        }
                    }
                    int val = -1;
                    while (true) {
                        System.Console.WriteLine ("Enter percent cut");
                        bool newPercentCut = int.TryParse (Console.ReadLine (), out val);

                        if (newPercentCut == true && val > 0 && val <= 100) {
                            break;
                        } else {
                            System.Console.WriteLine ("Value must be between 1 and 100");

                        }
                    }

                    switch (speciality) {
                        case "Hacker":
                            rolodex.Add (new Hacker () {
                                Name = newCrewName,
                                    SkillLevel = num,
                                    PercentageCut = val
                            });
                            break;
                        case "Muscle":
                            rolodex.Add (new Muscle () {
                                Name = newCrewName,
                                    SkillLevel = num,
                                    PercentageCut = val
                            });
                            break;
                        case "Lock Specialist":
                            rolodex.Add (new LockSpecialist () {
                                Name = newCrewName,
                                    SkillLevel = num,
                                    PercentageCut = val
                            });
                            break;
                    }
                }
            }

            Bank bank = new Bank ();
            Random alarm = new Random ();
            bank.AlarmScore = alarm.Next (0, 101);
            Random vault = new Random ();
            bank.VaultScore = vault.Next (0, 101);
            Random security = new Random ();
            bank.SecurityGuardScore = security.Next (0, 101);
            Random cash = new Random ();
            bank.CashOnHand = cash.Next (50_000, 1_000_001);

            // List<int> scores = new List<int> {
            //     bank.AlarmScore,
            //     bank.VaultScore,
            //     bank.SecurityGuardScore
            // };

            // int mostSecure = scores.Max ();
            // if (mostSecure == bank.SecurityGuardScore) {
            //     Console.WriteLine ("Security is most secure.");
            // } else if (mostSecure == bank.AlarmScore) {
            //     Console.WriteLine ("Alarm is most secure");
            // } else if (mostSecure == bank.VaultScore) {
            //     Console.WriteLine ("Vault is most secure.");
            // }

            // int leastSecure = scores.Min ();
            // if (leastSecure == bank.SecurityGuardScore) {
            //     Console.WriteLine ("Security is least secure.");
            // } else if (leastSecure == bank.AlarmScore) {
            //     Console.WriteLine ("Alarm is least secure.");
            // } else if (leastSecure == bank.VaultScore) {
            //     Console.WriteLine ("Vault is least secure.");
            // }

            Dictionary<string, int> scores = new Dictionary<string, int> ();
            scores.Add ("alarm", bank.AlarmScore);
            scores.Add ("vault", bank.VaultScore);
            scores.Add ("security", bank.SecurityGuardScore);

            scores.OrderByDescending ((v) => v.Value);
            string mostSecure = scores.First ().Key;
            string leastSecure = scores.Last ().Key;

            Console.WriteLine ($@"
                Recon Report:
                ------------
                Most Secure: {mostSecure}
                Least Secure: {leastSecure}
            ");
            
            foreach (IRobber robber in rolodex)
            {
                System.Console.WriteLine($@"
                    {rolodex.IndexOf(robber)}
                    Name:{robber.Name} 
                    Speciality: {robber.GetType().ToString().Split(".")[1]}
                    Skill Level: {robber.SkillLevel} 
                    PercentCut: {robber.PercentageCut} ");
            }
            // int testNum = -1;
            // bool test = int.TryParse(Console.ReadLine(), out testNum);
            // if(testNum == true && testNum)
            // List<IRobber> crew = new List<IRobber>(){
                

            // }
        }

    }
}