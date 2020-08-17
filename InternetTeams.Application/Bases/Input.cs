namespace InternetTeams.Application.Bases
{
    public class Input<T> where T : AbstractInput
    {
        public T Data { get; private set; }

        private Input(T input)
        {
            Data = input;
        }

        public static Input<T> Set(T input)
        {
            if (!input.IsValid)
            {
                input.Validate();
            }
            return new Input<T>(input);
        }
    }
}
