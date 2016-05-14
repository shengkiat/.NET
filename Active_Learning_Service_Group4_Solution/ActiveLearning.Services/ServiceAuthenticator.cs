using System;
using System.IdentityModel.Tokens;

namespace ActiveLearning.Services
{
    public class ServiceAuthenticator: System.IdentityModel.Selectors.UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName == null || password == null)
            {
                throw new ArgumentNullException();
            }

            if (!(userName == "fayaz" && password == "soomro"))
            {
                throw new SecurityTokenException("Incorrect Username or Password");
            }
        }
    }
}
