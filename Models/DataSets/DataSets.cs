using System;
using System.Collections.Generic;
using DataBaseWebAPI.Models;
using DataBaseWebAPI.Models.DataSets;

namespace DataBaseWebAPI
{
    public static class DataSets
    {
        public static User[] GetRandomUsers(int count = 5)
        {
            Random random = new();
            List<User> users = new(count);

            for (int i = 0; i < count; i++)
                users.Add(GetRandomUser());

            return users.ToArray();

            User GetRandomUser() => new() { Id = 0, Name = $"{GetRandomUserName()} {GetRandomUserSurname()}", Age = GetRandomUserAge() };

            string GetRandomUserName() => GetRandomValueFromEnum<UsersName>();
            string GetRandomUserSurname() => GetRandomValueFromEnum<UsersSurname>();
            int GetRandomUserAge() => random.Next(19, 42);

            string GetRandomValueFromEnum<T>() where T : Enum
                => Enum.GetName(typeof(T), random.Next(0, Enum.GetNames(typeof(T)).Length));
        }
    }
}
