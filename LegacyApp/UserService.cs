using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (!ValidateUserInput(firstName, lastName, email, dateOfBirth))
            {
                return false;
            }

            var user = GetUser(firstName, lastName, email, dateOfBirth, clientId);


            if (!ValidateUserCreditLimit(user, clientId))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }

        private bool ValidateUserInput(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)) return false;

            if (!email.Contains("@") && !email.Contains(".")) return false;

            var now = DateTime.Now;
            var age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month ||
                (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;

            return age >= 21;
        }

        private bool ValidateUserCreditLimit(User user, int clientId)
        {
            return new UserCreditService().ValidateUserCreditLimit(user, clientId);
        }

        private User GetUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            return new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };
        }
    }
}