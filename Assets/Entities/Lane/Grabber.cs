using UnityEngine;
using System.Collections;

[RequireComponent (typeof(FixedJoint))]
public class Grabber : MonoBehaviour {

    // Use this for initialization
    private GameObject grabbedObject;
    private FixedJoint fixedJoint;

	void Start () {
        fixedJoint = GetComponent<FixedJoint>();
	}

    public void OnTriggerEnter(Collider col)
    {
        Pin pin = col.GetComponentInParent<Pin>();
        if (!pin)
            return;
        if(pin.isStanding)
            grabbedObject = pin.gameObject;
    }
    public void OnTriggerExit(Collider col)
    {
        Pin pin = col.GetComponent<Pin>();
        if (!pin)
            return;
        grabbedObject = null;
    }

    public void Attach()
    {
        if (!grabbedObject)
            return;

        Rigidbody grabbedRigidBody = grabbedObject.GetComponent<Rigidbody>();
        Pin grabbedPin = grabbedObject.GetComponent<Pin>();
        if(grabbedObject && grabbedRigidBody && grabbedPin.isStanding)
        {
            fixedJoint.connectedBody = grabbedRigidBody;
        }
    }
    public void Dettach()
    {
        fixedJoint.connectedBody = null;
    }
}
