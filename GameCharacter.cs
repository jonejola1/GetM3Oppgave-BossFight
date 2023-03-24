
namespace GetM3Oppgaver
{
    class GameCharacter
    {
        private string name { get; set; }
        private int Health { get; set; }
        private int Strength { get; set; }
        private int Stamina { get; set; }

        public GameCharacter(string aCharName, int aHealth, int aStrength, int aStamina)
        {
            name = aCharName;
            Health = aHealth;
            Strength = aStrength;
            Stamina = aStamina;
        }
        public static void TryAgain()
        {
            Random rnd = new Random();

            Console.WriteLine("Do you want to play? y/n");
            string tryAgain = Console.ReadLine();

            if (tryAgain == "y" || tryAgain == "Y")
            {
                GameCharacter hero = new("Hero", 100, 20, 40);
                GameCharacter boss = new("Boss", 300, 20, 20);

                GameCharacter.Fight(hero, boss);
            }
        }

        private static void Fight(GameCharacter aHero, GameCharacter aBoss)
        {
            var rnd = new Random();

            while (aHero.Health > 0 && aBoss.Health > 0)
            {
                if (aHero.Stamina <= 0)
                {
                    Recharge(aHero);
                }
                else
                {
                    aBoss.Health -= aHero.Strength;
                    Console.WriteLine($"Hero damages boss for {aHero.Strength} points. Boss now has {aBoss.Health} HP left.");
                    aHero.Stamina -= 10;
                }

                if (aBoss.Stamina <= 0)
                {
                    Recharge(aBoss);
                }
                else
                {
                    aBoss.Strength = rnd.Next(0, 30);
                    aHero.Health -= aBoss.Strength;
                    Console.WriteLine($"Enemy Boss damages Hero for {aBoss.Strength} Points. Hero now has {aHero.Health} HP left.");
                    aBoss.Stamina -= 10;
                }

            }

            if (aHero.Health > 0)
            {
                
                Console.WriteLine($"The Hero won with {aHero.Health} HP points left.");
                Console.ReadLine();
                Console.Clear();

                TryAgain();
            }
            else
            {
                Console.WriteLine($"The Enemy Boss won with {aBoss.Health} HP points left.");
                Console.ReadLine();
                Console.Clear();

                TryAgain();
            }
        }

        private static void Recharge(GameCharacter gameCharacter)
        {
            switch (gameCharacter.name)
            {
                case "Hero":
                        Console.WriteLine("Hero's stamina is empty\nHero stamina replenished");
                        gameCharacter.Stamina += 40;
                    break;
                case "Boss":
                        Console.WriteLine("Boss's stamina is empty\nBoss stamina replenished");
                        gameCharacter.Stamina += 10;
                    break;
                default:
                    throw new Exception("Invalid Character name");
                    break;
            }
        }
    }
}
