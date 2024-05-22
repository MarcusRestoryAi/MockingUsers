using MockingUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MockingUsersTest
{
    public class FizzBuzzTest
    {
        FizzBuzz fizzBuzz { get; set; }

        public FizzBuzzTest()
        {
            fizzBuzz = new FizzBuzz();

        }

        [Theory]
        [InlineData(1, "1")]
        [InlineData(2, "2")]
        [InlineData(4, "4")]
        [InlineData(7, "7")]
        public void SendNumberGetNumber(int number, string expected)
        {
            string result = fizzBuzz.DetermineFizzBuzz(number);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        [InlineData(18)]
        [InlineData(33)]
        public void SendNumberGetFizz(int number)
        {
            string result = fizzBuzz.DetermineFizzBuzz(number);

            Assert.Equal("Fizz", result);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(25)]
        [InlineData(35)]
        public void SendNumberGetBuzz(int number)
        {
            string result = fizzBuzz.DetermineFizzBuzz(number);

            Assert.Equal("Buzz", result);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        [InlineData(60)]
        [InlineData(75)]
        public void SendNumberGetFizzBuzz(int number)
        {
            string result = fizzBuzz.DetermineFizzBuzz(number);

            Assert.Equal("FizzBuzz", result);
        }

    }
}
