
/** Give an input from the console or just comment the while loop below and set the TeamsCount property at the beginning.
 * 
 *  Currently only even numbers are prepared in the algorithm.
 *  
 *  The idea of the algorithm found from https://stackoverflow.com/questions/6648512/scheduling-algorithm-for-a-round-robin-tournament
 *  Remaining code is written by myself.
 * 
 *  Algorithm.BuildTournamentSchedule() is the main function in the project.
 *
**/

using MatchingAlgorithm;
using static MatchingAlgorithm.Config;

int parseint;

Console.WriteLine("Please enter the number of teams you want to make tournament:");

//Loop till an even number is given.
while (TeamsCount % 2 != 0)
{
    string readvalue = Console.ReadLine();
    
    if (!int.TryParse(readvalue, out parseint)) //Check If we can parse the number.
    {
        Console.WriteLine("Please enter a number.");
    }
    else if (parseint % 2 != 0) //Check If the number is even.
    {
        Console.WriteLine("Please enter an even number.");
    }
    else if (parseint < 0) //Check If the number is positive.
    {
        Console.WriteLine("Please enter a positive even number.");
    }
    else //Save the number.
    {
        TeamsCount = parseint;
    }
}

//Start the algorithm
int[][][] schedule3DArray = Algorithm.BuildTournamentSchedule(TeamsCount);

//Visualization of the output int[][][]
Console.WriteLine("[" + Environment.NewLine + string.Join("," + Environment.NewLine, schedule3DArray.Select(x => "[" + string.Join(", ", x.Select(y => "[" + string.Join(", ", y) + "]")) + "]")) + Environment.NewLine + "]");