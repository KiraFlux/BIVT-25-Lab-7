namespace Lab7.Blue
{
    public class Task1
    {
        public struct Response
        {
            // Война и мир в 7 словах: Зачем писать private, если он по умолчанию?

            string name, surname;
            int votes = 0; // Имеют ли смысл отрицательные голоса?

            public readonly string Name => name;
            public readonly string Surname => surname;
            public readonly int Votes => votes;

            public Response(string name, string surname)
            {
                this.name = name;
                this.surname = surname;
            }

            public int CountVotes(Response[] responses)
            {
                this.votes = responses.Count(Same);

                for (int i = 0; i < responses.Length; i += 1)
                {
                    ref var r = ref responses[i];
                    if (Same(r)) { r.votes = this.votes; }
                }

                return this.votes;
            }

            public void Print() => Console.WriteLine($"Response{{name: \"{name}\", surname: \"{surname}\", votes: {votes}}}");
            bool Same(Response other) => this.name == other.name && this.surname == other.surname;
        }
    }
}