namespace MatchingAlgorithm
{
    internal static class Config
    {
        private static int teamsCount = 1;
        public static int totalMatchesCount;
        public static int totalNumberOfRounds;

        //Whenever the team count is set, the total matches and number of rounds are calculated.
        public static int TeamsCount
        {
            get { return teamsCount; }
            set
            {
                teamsCount = value;
                totalMatchesCount = (value * (value - 1)) / 2;
                totalNumberOfRounds = value - 1;
            }
        }
    }
}
