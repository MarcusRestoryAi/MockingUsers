using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockingUsers
{
    public class FizzBuzz
    {
        public string DetermineFizzBuzz(int number)
        {
            string result = "";

            if (number % 3 == 0) result += "Fizz";
            if (number % 5 == 0) result += "Buzz";
            if (result.Length == 0) return number.ToString();
            return result;
        }

        public string OldDetermineFizzBuzz(int number)
        {
            if (number % 3 == 0 && number % 5 == 0)
            {
                return "FizzBuzz";
            }

            if (number % 3 == 0) return "Fizz";
            if (number % 5 == 0) return "Buzz";
            return number.ToString();
        }
    }
}
