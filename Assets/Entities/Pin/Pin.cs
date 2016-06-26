using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour 
{
	public float standingThreshold = 5.0f;

	//void Update () {
 //       print(name + " " + isStanding);
	//}

	public bool isStanding
	{
		get 
		{	
			float rotX = transform.rotation.eulerAngles.x;
			float rotZ = transform.rotation.eulerAngles.z;

			bool standingRotX = (Mathf.Abs(rotX) <= standingThreshold) || (Mathf.Abs(360.0f - rotX) <= standingThreshold);
			bool standingRotZ = (Mathf.Abs(rotZ) <= standingThreshold) || (Mathf.Abs(360.0f - rotZ) <= standingThreshold);

			return standingRotX && standingRotZ;
		}
	}
}
