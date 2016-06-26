using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResetPanel : MonoBehaviour
{
    private Text finalScore;

    void Start()
    {
        finalScore = GameObject.Find("ScoreText").GetComponent<Text>();
    }

    public void SetFinalScore(int score)
    {
        finalScore.text = score.ToString();
    }
}
