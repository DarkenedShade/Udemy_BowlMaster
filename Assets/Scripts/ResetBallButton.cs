using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResetBallButton : MonoBehaviour
{

    // Use this for initialization
    private Ball ball;
    private GameManager gameManager;

    private GameObject resetText;
    private Image circleImage;
    private Button button;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
        gameManager = GameObject.FindObjectOfType<GameManager>();

        resetText = GetComponentInChildren<Text>().gameObject;
        circleImage = GetComponentInChildren<Image>();
        button = GetComponent<Button>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GameOver || !ball.inPlay)
        {
            enableReset(); 
        }
        else
        {
            disableReset();
        }

    }

    private void enableReset()
    {
        button.enabled = false;
        resetText.SetActive(false);
        circleImage.color = Color.green;
    }
    private void disableReset()
    {
        button.enabled = true;
        resetText.SetActive(true);
        circleImage.color = Color.red;
    }

    public void ResetBallButtonHandler()
    {
        Debug.Log("Reset Button Pressed");
        ball.Reset();
        gameManager.Bowl(0);
    }



}
