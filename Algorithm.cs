using static MatchingAlgorithm.Config;

namespace MatchingAlgorithm
{
    internal class Algorithm
    {
        //Main Function to get the tournament schedule.
        public static int[][][] BuildTournamentSchedule(int numberOfTeams)
        {
            //Create a list to use it inside the loop.
            List<int> loopArray = new(Enumerable.Range(1, numberOfTeams));

            //Create output list.
            List<int[][]> scheduleArray = new();

            //For each rounds, array will be sorted and then sent to the MatchMaker function to create match schedule for all teams.
            for (int i = 0; i < totalNumberOfRounds; i++)
            {
                //Get the teams array.
                loopArray = ArrayItemsSorter(loopArray);

                //Send teams array to MatchMaker and add the round to the scheduleArray.
                scheduleArray.Add(MatchMaker(loopArray));
            }

            return scheduleArray.ToArray();
        }

        //Reduce the indexOfOne of the first team (1) to get next week's schedule.
        private static List<int> ArrayItemsSorter(List<int> teamsArray)
        {
            //Save indexOfOne of 1.
            int index = teamsArray.IndexOf(1);

            teamsArray.Remove(1);

            if (index == 0) //If the indexOfOne is 0, we should insert it to the end.
            {
                teamsArray.Insert(TeamsCount - 2, 1);
            }
            else //Reduce indexOfOne by 1.
            {
                teamsArray.Insert(index - 1, 1);
            }

            return teamsArray;
        }

        //Create current week's schedule by the ordered teamsArray
        private static int[][] MatchMaker(List<int> teamsArray)
        {
            //Save indexOfOne of 1.
            int indexOfOne = teamsArray.IndexOf(1);
            int hometeamsindex;
            List<int[]> matchesList = new();

            for (int i = 0; i < TeamsCount / 2; i++)
            {
                hometeamsindex = (indexOfOne - i) % TeamsCount;

                if (hometeamsindex < 0) //If the index is negative, add it directly to the count.
                {
                    hometeamsindex = TeamsCount + hometeamsindex;
                }

                //Prepare the two item array (single match) and add it to this round's list.
                matchesList.Add(new int[] { teamsArray[hometeamsindex], teamsArray[(indexOfOne + i + 1) % TeamsCount] });
            }

            return matchesList.ToArray();
        }
    }
}
