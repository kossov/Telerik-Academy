namespace CreateHuman
{
    using System;

    internal class Generator
    {
        public Human CreateHuman(int humanAge)
        {
            Human human = new Human();
            human.age = humanAge;
            if (humanAge % 2 == 0)
            {
                human.name = "LeDuud";
                human.gender = Gender.Male;
            }
            else
            {
                human.name = "LeDudess";
                human.gender = Gender.Female;
            }

            return human;
        }
    }
}