using System;

namespace InternetTeams.Domain.Exceptions
{
    public class PersistenceException : Exception
    {
        public PersistenceException(string msg) : base(msg)
        {

        }
    }
}
