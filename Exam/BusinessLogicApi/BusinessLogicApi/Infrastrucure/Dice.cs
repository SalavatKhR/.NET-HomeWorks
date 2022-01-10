using System;
using System.Text.RegularExpressions;

namespace BusinessLogicApi.Infrastructure
{
    public class Dice
    {
        public static int DiceRoll(string damage)
        {
            var asd = DamageParser(damage);
            var dice = asd[1];
            var count = asd[0];
            var rnd = new Random();
            int result = 0;
            for(int i = 1; i < count+1; i++)
            {
                result += rnd.Next(1, dice + 1);
            }
            return result;
        }

        public static int[] DamageParser(string dice)
        {
            var diceRegex = new Regex("\\d[d](4|6|8|20)");
            if (!diceRegex.IsMatch(dice))
            {
                return new int[]{-1};
            }
            var diceDataStrings = dice.Split('d', StringSplitOptions.RemoveEmptyEntries);
            var diceDataInt = new int[2] {int.Parse(diceDataStrings[0]), int.Parse(diceDataStrings[1])};
            return diceDataInt;
        }
    }
}