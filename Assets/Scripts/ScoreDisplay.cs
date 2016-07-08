using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour
{
    public Text[] rollsDisplayLabels;
    public Text[] frameDisplayLabels;

    // Use this for initialization
    void Start()
    {
        //int i = 1;
        //foreach (Text rollLabel in rollsDisplayLabels)
        //{
        //    rollLabel.text = i.ToString();
        //    i++;
        //}
        //i = 1;
        //foreach (Text frameLabel in frameDisplayLabels)
        //{
        //    frameLabel.text = i.ToString();
        //    i++;
        //}
    }


    public void FillRolls(List<int> rolls)
    {
        string scoresString = FormatRolls(rolls);
        for (int i = 0; i < scoresString.Length; i++)
        {
            rollsDisplayLabels[i].text = scoresString[i].ToString();
        }
    }

    public void FillFrames(List<int> frames)
    {
        for (int i = 0; i < frames.Count; i++)
        {
            frameDisplayLabels[i].text = frames[i].ToString();
        }
    }

    public void ClearDisplay()
    {
        foreach (Text rollLabel in rollsDisplayLabels)
        {
            rollLabel.text = "";
        }
        foreach (Text frameLabel in frameDisplayLabels)
        {
            frameLabel.text = "";
        }
    }

    public static string FormatRolls(List<int> rolls)
    {
        string output = "";

        for (int i = 0; i < rolls.Count; i++)
        {
            int box = output.Length + 1;

            if(rolls[i] == 0)
            {
                output += "-";
            }
            else if ((box % 2 == 0 || box == 21) && rolls[i-1]+rolls[i] == 10)
            {
                output += "/";
            }
            else if(rolls[i] == 10)
            {
                output += "X" + ((box < 18) ? " " : "");
            }
            else
            {
                output += rolls[i].ToString();
            }
        }

        return output;
    }
}
