using MachineTuring;

HashSet<string> states = new HashSet<string> { "q0", "q1", "q2" };

HashSet<char> alphabet = new HashSet<char> { '0', '1' };

var transitionFunction = new Dictionary<Tuple<string, char>, List<Tuple<string, char, char>>>
{
            { Tuple.Create("q0", '0'), new List<Tuple<string, char, char>> { Tuple.Create("q0", '0', 'R') } },
            { Tuple.Create("q0", '1'), new List<Tuple<string, char, char>> { Tuple.Create("q0", '1', 'R'), Tuple.Create("q1", '1', 'R') } },
            { Tuple.Create("q1", '1'), new List<Tuple<string, char, char>> { Tuple.Create("q2", '1', 'R') } }
};

string startState = "q0";

HashSet<string> acceptStates = new HashSet<string> { "q2" };

MTND mtnd = new MTND(states, alphabet, transitionFunction, startState, acceptStates);

string[] inputStrings = { "0111", "0011", "111", "110" };

foreach (var inputString in inputStrings)
{
    var result = mtnd.Simulate(inputString);
    Console.WriteLine("Entrada: " + inputString);
    Console.WriteLine("Estado Final: " + result.Item1);
    Console.WriteLine("Fita Final: " + result.Item2);
    Console.WriteLine("Posição da Cabeça de Leitura: " + result.Item3);
    Console.WriteLine("---");
}