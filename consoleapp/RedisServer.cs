using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Text;

namespace consoleapp
{
    public class RedisServer
    {
        private readonly Lazy<ConnectionMultiplexer> Connection;
        private readonly IDatabase _database;

        public RedisServer()
        {
            var options = ConfigurationOptions.Parse("localhost:6379");
            Connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(options));
            _database = Connection.Value.GetDatabase();
        }

        public void CallMe()
        {
            while(true)
            {
                Console.WriteLine("Enter Key");
                var key = Console.ReadLine();
                Console.WriteLine("Enter value");
                var value = Console.ReadLine();

                _database.StringSet(key,value);
                Console.WriteLine("type c to add more key:value");
                // var ans = Console.ReadLine();
                if (Console.ReadLine() != "c")
                    break;
            }
        }

    }
}
