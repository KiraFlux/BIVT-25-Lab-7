namespace Lab7.Blue
{
    public class Task3
    {
        namespace Lab7.Blue
    {
        public class Task3
        {
            public struct Participant
            {
                readonly string name, surname;
                int[] penalty_times;
                int matches_played;

                public string Name => name;
                public string Surname => surname;
                public int[] PenaltyTimes => penalty_times == null ? null : (int[])penalty_times.Clone();

                public int TotalTime
                {
                    get
                    {
                        if (penalty_times == null) return 0;
                        int sum = 0;
                        for (int i = 0; i < matches_played; i++) sum += penalty_times[i];
                        return sum;
                    }
                }

                public bool IsExpelled
                {
                    get
                    {
                        if (penalty_times == null) return false;
                        for (int i = 0; i < matches_played; i++)
                            if (penalty_times[i] == 10) return true;
                        return false;
                    }
                }

                public Participant(string name, string surname)
                {
                    this.name = name;
                    this.surname = surname;
                    penalty_times = new int[30]; // максимально 30 матчей как в условии
                    matches_played = 0;
                }

                public void PlayMatch(int time)
                {
                    if (time < 0 || penalty_times == null || matches_played >= penalty_times.Length)
                        return;

                    penalty_times[matches_played] = time;
                    matches_played++;
                }

                public static void Sort(Participant[] array)
                {
                    if (array != null)
                    {
                        Array.Sort(array, (l, r) =>
                        {
                            // Сортировка по возрастанию TotalTime, но исключенные игроки в конец
                            if (l.IsExpelled && !r.IsExpelled) return 1;
                            if (!l.IsExpelled && r.IsExpelled) return -1;
                            return l.TotalTime.CompareTo(r.TotalTime);
                        });
                    }
                }

                public void Print() =>
                    System.Console.WriteLine($"Participant{{name: \"{name}\", surname: \"{surname}\", totalTime: {TotalTime}, isExpelled: {IsExpelled}}}");
            }
        }
    }
}
}