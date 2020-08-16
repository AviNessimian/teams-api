using System;

namespace InternetTeams.Persistence.Exceptions
{
    public class PersistenceException : Exception
    {
        public PersistenceException(string msg) : base(msg)
        {

        }
    }
}
