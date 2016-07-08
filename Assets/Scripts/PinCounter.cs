using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour
{
    public Text pinCountLabel;


    private GameManager gameManager;

    private const float STANDING_TIME = 3.0f;

    private bool _ballOutOfPlay = false;
    private int _lastStandingCount = -1;
    private int lastSettledCount = 10;
    private float lastChangeTime;

    void Start()
    {
        pinCountLabel.text = PinCounter.standingPinCount.ToString();
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    void Update()
    {   
        if (ballOutOfPlay)
        {
            UdpateStandingCountAndSettle();
        }
    }

    public void Reset()
    {
        lastSettledCount = 10;
    }

    void UdpateStandingCountAndSettle()
    {
        int currentStandingCount = PinCounter.standingPinCount;
        pinCountLabel.text = PinCounter.standingPinCount.ToString();

        if (currentStandingCount != _lastStandingCount)
        {
            _lastStandingCount = currentStandingCount;
            lastChangeTime = Time.time;
            return;
        }
        else
        {
            if ((Time.time - lastChangeTime) >= STANDING_TIME)
            {
                PinsHaveSettled();
            }
        }
    }
    void PinsHaveSettled()
    {
        int currentStanding = PinCounter.standingPinCount;
        int fallenPinCount = lastSettledCount - currentStanding;
        lastSettledCount = currentStanding;

        gameManager.Bowl(fallenPinCount);
        
        _lastStandingCount = -1;
        ballOutOfPlay = false;
    }

    #region Triggers
    void OnTriggerExit(Collider other)
    {
        Ball ball = other.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            ballOutOfPlay = true;
        }
    }
    #endregion

    public bool ballOutOfPlay
    {
        get
        {
            return _ballOutOfPlay;
        }
        set
        {
            _ballOutOfPlay = value;
            if (_ballOutOfPlay)
            {
                pinCountLabel.color = Color.red;
            }
            else
            {
                pinCountLabel.color = Color.green;
            }
        }
    }

    public static int standingPinCount
    {
        get
        {
            int counter = 0;
            foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
            {
                if (pin.isStanding)
                    counter++;
            }
            return counter;
        }
    }
}
