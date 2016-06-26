using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour
{
    public GameObject pinTemplate;

    private Animator animator;
    private PinCounter pinCounter;

    private GameManager gameManager;

    void Start()
    {
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();

        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void RenewPins()
    {
        float zDistanceBetweenPins = 52.71f * 0.5f;
        float xDistanceBetweenPins = 30.48f;

        Vector3 pos = Vector3.zero;
        Vector3 raisedOffset = new Vector3(0.0f, 95.0f, 0.0f);
        int pinCount = 1;
        for (int i = 1; i <= 4; i++) // num rows
        {
            for (int j = 1; j <= i; j++)
            {
                GameObject newPin = CreatePinAt((pos + raisedOffset));
                newPin.GetComponent<Rigidbody>().useGravity = false;
                newPin.name = "Pin " + pinCount;
                pos.x += xDistanceBetweenPins;

                //print(pinCount + " in row " + i);
                pinCount++;

                if (i == 1 && j == 1)
                    break;
            }
            pos.x = -((float)i * 0.5f) * xDistanceBetweenPins;
            pos.z += zDistanceBetweenPins;
        }
    }

    void ReEnableAllPinGravity()
    {
        GameObject pinsContainer = GameObject.Find("Pins");
        Pin[] allPins = pinsContainer.GetComponentsInChildren<Pin>();
        foreach (Pin pin in allPins)
        {
            pin.GetComponent<Rigidbody>().useGravity = true;
        }
    }
    void StraightenAllStandingPins()
    {
        GameObject pinsContainer = GameObject.Find("Pins");
        Pin[] allPins = pinsContainer.GetComponentsInChildren<Pin>();
        foreach (Pin pin in allPins)
        {
            if (pin.isStanding)
            {
                pin.transform.rotation = Quaternion.identity;
            }
        }
    }

    void GrabPins()
    {
        StraightenAllStandingPins();
        Grabber[] allGrabbers = gameObject.GetComponentsInChildren<Grabber>();
        foreach (Grabber grabber in allGrabbers)
        {
            grabber.Attach();
        }
    }
    void ReleasePins()
    {
        Grabber[] allGrabbers = gameObject.GetComponentsInChildren<Grabber>();
        foreach (Grabber grabber in allGrabbers)
        {
            grabber.Dettach();
        }
    }

    void ResetAllPins()
    {
        animator.SetTrigger("resetTrigger");
        pinCounter.Reset();
    }
    void TidyAllPins()
    {
        animator.SetTrigger("tidyTrigger");
    }

    GameObject CreatePinAt(Vector3 pos)
    {
        GameObject pinsContainer = GameObject.Find("Pins");
        if (!pinsContainer)
        {
            pinsContainer = new GameObject("Pins");
            pinsContainer.transform.position = new Vector3(0, 0, 1829);
        }
        GameObject newPin = Instantiate(pinTemplate);
        newPin.transform.parent = pinsContainer.transform;
        newPin.transform.localPosition = pos;
        return newPin;
    }

    void SetterCompleteBallCanLaunch()
    {
        //Debug.Log("SetterCompleteBallCanLaunch");
        gameManager.SetBallCanLaunch();
    }

    //Public Functions
    public void TakeAction(ActionMaster.Action action)
    {
        switch (action)
        {
            case ActionMaster.Action.Reset:
                ResetAllPins();
                break;
            case ActionMaster.Action.Tidy:
                TidyAllPins();
                break;
            case ActionMaster.Action.EndTurn:
                ResetAllPins();
                break;
            case ActionMaster.Action.EndGame:
                break;
        }
    }
}
