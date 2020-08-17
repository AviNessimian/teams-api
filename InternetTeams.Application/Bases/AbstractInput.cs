namespace InternetTeams.Application.Bases
{
    public abstract class AbstractInput
    {
        public virtual void Validate()
        {
            IsValid = true;
        }

        public bool IsValid { get; private set; } = false;
    }
}
