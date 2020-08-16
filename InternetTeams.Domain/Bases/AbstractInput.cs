namespace InternetTeams.Domain.Bases
{

    public class Input<T> where T : AbstractInput
    {
        
        public Input(T input)
        {
            if (!input.IsValid)
            {
                input.Validate();
            }

            Data = input;

        }

        public T Data { get; private set; }
    }

    public abstract class AbstractInput
    {
        public virtual void Validate()
        {
            IsValid = true;
        }


        public bool IsValid { get; private set; } = false;
    }
}
