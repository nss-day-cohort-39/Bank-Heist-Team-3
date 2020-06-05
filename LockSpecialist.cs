using System;

namespace Bank_Heist
{
    public class LockSpecialist : IRobber
    {
        public string Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }

        public void PerformSkill(Bank bank)
        {
            bank.VaultScore = bank.VaultScore - SkillLevel;
            System.Console.WriteLine($"{Name} is hacking the vault. Decreased security {SkillLevel} points.");
            if (bank.VaultScore < 0)
            {
                Console.WriteLine($"{Name} has disabled the vault!");
            }
        }
    }
}