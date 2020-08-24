using MyAPI.DataBase;
using System;
using System.Collections.Generic;


namespace MyAPI
{
    public static class TestDataFrame
    {
        public static List<User> GetDataFrame()
        {
            string[] Names = new string[] { "Prescott", "Grover", "Oberon", "Regis", "Thelonious" };
            Random random = new Random();

            List<User> Users = new List<User>()
            {
                new User(){ Name = Names[random.Next(0,4)], Age = random.Next(18,60) },
                new User(){ Name = Names[random.Next(0,4)], Age = random.Next(18,60) },
                new User(){ Name = Names[random.Next(0,4)], Age = random.Next(18,60) },
                new User(){ Name = Names[random.Next(0,4)], Age = random.Next(18,60) },
                new User(){ Name = Names[random.Next(0,4)], Age = random.Next(18,60) },
                new User(){ Name = Names[random.Next(0,4)], Age = random.Next(18,60) },
                new User(){ Name = Names[random.Next(0,4)], Age = random.Next(18,60) },
                new User(){ Name = Names[random.Next(0,4)], Age = random.Next(18,60) }
            };

            return Users;
        }
    }
}
