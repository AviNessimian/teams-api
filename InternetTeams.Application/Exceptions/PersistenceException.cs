using System;

namespace InternetTeams.Application.Exceptions
{
    public class PersistenceException : Exception
    {
        public PersistenceException(string msg) : base(msg)
        {

        }
    }
}
