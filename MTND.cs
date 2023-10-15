namespace MachineTuring
{
    public class MTND
    {
        private HashSet<string> States { get; set; }

        private HashSet<char> Alphabet { get; set; }

        private Dictionary<Tuple<string, char>, List<Tuple<string, char, char>>> TransitionFunction;

        private string StartState { get; set; }

        private HashSet<string> AcceptStates { get; set; }

        public MTND(HashSet<string> states, HashSet<char> alphabet, Dictionary<Tuple<string, char>, List<Tuple<string, char, char>>> transitionFunction, string startState, HashSet<string> acceptStates)
        {
            States = states;
            
            Alphabet = alphabet;
            
            TransitionFunction = transitionFunction;
            
            StartState = startState;
            
            AcceptStates = acceptStates;
        }

        public Tuple<string, string, int> Simulate(string inputString)
        {
            string currentState = StartState;
            
            char[] tape = new char[inputString.Length + 2];
            
            int headPosition = 1;

            for (int i = 0; i < tape.Length; i++)
            {
                tape[i] = ' ';
            }

            inputString.CopyTo(0, tape, 1, inputString.Length);

            while (!AcceptStates.Contains(currentState))
            {
                char currentSymbol = tape[headPosition];

                if (TransitionFunction.TryGetValue(Tuple.Create(currentState, currentSymbol), out var transitions))
                {
                    foreach (var transition in transitions)
                    {
                        tape[headPosition] = transition.Item2;

                        if (transition.Item3 == 'R')
                            headPosition++;

                        else if (transition.Item3 == 'L')
                            headPosition--;

                        currentState = transition.Item1;

                        if (AcceptStates.Contains(currentState))
                            break;
                    }
                }
                else
                    break; 

            }

            return Tuple.Create(currentState, new string(tape), headPosition);
        }
    }

}
