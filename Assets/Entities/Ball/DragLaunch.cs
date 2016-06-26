using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Ball))]
public class DragLaunch : MonoBehaviour {

    //Remove Later
    public bool isDEBUG = false;
    public Vector3 DebugVectorDirection = Vector3.zero;



    private Ball ball;

	private Vector3 startDragPosition;
	private float startDragTime;

	void Start () {
		ball = GetComponent<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DragStart()
	{
//		Debug.Log("Drag Start");
		startDragPosition = Input.mousePosition;
		startDragTime = Time.time;
	}

	public void DragEnd()
	{
		Vector3 endDragPosition = Input.mousePosition;
		float endDragTime = Time.time;

		float dragDuration = endDragTime - startDragTime;
		Vector3 dragVector = endDragPosition - startDragPosition;
		dragVector.z = dragVector.y;
		dragVector.y = 0.0f;

        if(isDEBUG)
        {
            //ball.Launch((DebugVectorDirection * dragVector.magnitude) / dragDuration);
            ball.Launch((DebugVectorDirection) / dragDuration);
        }
        else
        {
            Vector3 adjustedVel = dragVector;
            adjustedVel.x *= 0.25f;
            ball.Launch(adjustedVel / dragDuration);
        }
    }

	public void MoveStart (float xNudge)
	{
		if (!ball.inPlay) {
			transform.Translate (new Vector3 (xNudge, 0, 0));
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -35, 35), transform.position.y, transform.position.z);
        }
	}
}
