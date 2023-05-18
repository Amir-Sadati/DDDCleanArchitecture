using SocialMedia.Domain.User.ValueObjets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.User.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string email) : base($"Invalid email address: '{email}'")
        {

        }
    }
}
