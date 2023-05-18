using SocialMedia.Domain.Common.Models;
using SocialMedia.Domain.User.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SocialMedia.Domain.User.ValueObjets
{
    public class Email : ValueObject
    {
        private Email() { }
        private Email(string value) 
        {
            Value = value;
        }

        public string Value { get;}

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        public static Email Create(string value)
        {
            if (Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$") is false)
                throw new InvalidEmailException(value);

            return new Email(value);
        }

    }
}
