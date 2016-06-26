using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	// Use this for initialization
	public GameObject target;
	public float stopAtZ = 1829;

	private Vector3 offset;
	private float totalZDistance;

	void Start () {
		offset = transform.position - target.transform.position;

		totalZDistance = stopAtZ - transform.position.z;
	}
	
	// Update is called once per frame
	void Update () 
	{
		

		Vector3 camPosWithOffset = target.transform.position + offset;
		camPosWithOffset.y = ((camPosWithOffset.y <= 43.45f)?43.45f:camPosWithOffset.y);

		float deltaY = Mathf.Lerp(0,-20,transform.position.z/totalZDistance);
		Vector3 newCamPos = camPosWithOffset + new Vector3(0,deltaY,0);
		if(newCamPos.z <= stopAtZ)
		{
			newCamPos.x = 0.0f;
			transform.position = newCamPos;

		}

	}
}
