using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Domain.Post.Exceptions
{
    public class InvalidTagNameLengthException : Exception
    {
        public InvalidTagNameLengthException():base("Tag name length must be less than or equal to 20 characters.") 
        { }
    }
}
