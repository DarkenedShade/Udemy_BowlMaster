using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class ScoreMaster
{
    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frameList = new List<int>();

        int evenOddToggle = 0;
        for (int currentRollIndex = 0; currentRollIndex < rolls.Count; currentRollIndex++)
        {
            if (currentRollIndex % 2 == evenOddToggle || frameList.Count == 10)
            {
                continue;
            }

            int currentRoll = rolls[currentRollIndex];
            int previousRoll = rolls[currentRollIndex - 1];
        
            if (previousRoll == 10)
            {
                if ((currentRollIndex + 1) < rolls.Count)//there is a next Roll
                {
                    frameList.Add(previousRoll + currentRoll + rolls[currentRollIndex + 1]);
                    evenOddToggle = (evenOddToggle == 0) ? 1 : 0; //if a strike is found altenated the odd even roll index to similate an extra bowl added
                }
                continue;
            }
            else if ((currentRoll + previousRoll) >= 10) //Spare
            {
                if ((currentRollIndex + 1) < rolls.Count)//there is a next Roll
                {
                    frameList.Add(10 + rolls[currentRollIndex + 1]);
                }
                continue;
            }
            frameList.Add(currentRoll + previousRoll);
        }

        return frameList;
    }

    public static List<int> ScoreCumulative(List<int> rolls)
    {
        List<int> cumlativeScores = new List<int>();
        int runningTotal = 0;

        foreach (int frameScore in ScoreFrames(rolls))
        {
            runningTotal += frameScore;
            cumlativeScores.Add(runningTotal);
        }

        return cumlativeScores;
    }
}
