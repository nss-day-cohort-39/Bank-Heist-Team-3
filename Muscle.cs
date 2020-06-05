using System;

namespace Bank_Heist
{
    public class Muscle : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(Bank bank)
        {
            bank.SecurityGuardScore = bank.SecurityGuardScore - SkillLevel;
            System.Console.WriteLine($"{Name} is disabling the security guards. Decreased security {SkillLevel} points.");
            if (bank.SecurityGuardScore < 0)
            {
                Console.WriteLine($"{Name} has disabled the security guards!");
            }
        }
    }
}