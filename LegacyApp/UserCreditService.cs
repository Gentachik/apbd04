using System;
using System.Collections.Generic;
using System.Threading;

namespace LegacyApp
{
    public class UserCreditService : IDisposable
    {
        /// <summary>
        /// Simulating database
        /// </summary>
        private readonly Dictionary<string, int> _database =
            new Dictionary<string, int>()
            {
                {"Kowalski", 200},
                {"Malewski", 20000},
                {"Smith", 10000},
                {"Doe", 3000},
                {"Kwiatkowski", 1000}
            };
        
        public void Dispose()
        {
            //Simulating disposing of resources
        }

        /// <summary>
        /// This method is simulating contact with remote service which is used to get info about someone's credit limit
        /// </summary>
        /// <returns>Client's credit limit</returns>
        internal int GetCreditLimit(string lastName, DateTime dateOfBirth)
        {
            int randomWaitingTime = new Random().Next(3000);
            Thread.Sleep(randomWaitingTime);

            if (_database.ContainsKey(lastName))
                return _database[lastName];

            throw new ArgumentException($"Client {lastName} does not exist");
        }

        public bool ValidateUserCreditLimit(User user, int clientId)
        {
            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            switch (client.Type)
            {
                case "VeryImportantClient":
                    user.HasCreditLimit = false;
                    break;
                case "ImportantClient":
                {
                    var creditLimit = GetCreditLimit(user.LastName, user.DateOfBirth);
                    creditLimit *= 2;
                    user.CreditLimit = creditLimit;
                    break;
                }
                default:
                {
                    user.HasCreditLimit = true;
                    int creditLimit = GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
                    break;
                }
            }

            return !user.HasCreditLimit || user.CreditLimit >= 500;
        }
    }
}