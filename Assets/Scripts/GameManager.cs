using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private PinSetter pinSetter;
    private Ball ball;
    private ScoreDisplay scoreDisplay;

    private bool gameOver = false;
    public bool GameOver
    {
        get { return gameOver; }
    }

    private List<int> rolls = new List<int>();

    private GameObject touchPanel;
    //private GameObject resetPanel;
    private ResetPanel resetPanel;

    void Start()
    {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        ball = GameObject.FindObjectOfType<Ball>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();

        touchPanel = GameObject.Find("Touch Input");
        resetPanel = GameObject.FindObjectOfType<ResetPanel>();

        touchPanel.SetActive(true);
        resetPanel.gameObject.SetActive(false);
    }

    public void Bowl(int pinFall)
    {
        rolls.Add(pinFall);
        ball.Reset();

        ActionMaster.Action nextAction = ActionMaster.NextAction(rolls);
        pinSetter.TakeAction(nextAction);

        scoreDisplay.FillRolls(rolls);
        scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));

        if (ScoreMaster.ScoreCumulative(rolls).Count >= 10)
        {
            gameOver = true;
            touchPanel.SetActive(false);
            resetPanel.gameObject.SetActive(true);
            resetPanel.SetFinalScore(ScoreMaster.ScoreCumulative(rolls)[9]);
        }
    }

    public void ResetAndReplay()
    {
        gameOver = false;
        pinSetter.TakeAction(ActionMaster.Action.Reset);
        ball.Reset();
        rolls.Clear();
        scoreDisplay.ClearDisplay();

        touchPanel.SetActive(true);
        resetPanel.gameObject.SetActive(false);
    }

    public void SetBallCanLaunch()
    {
        ball.CanLaunch();
    }
}
