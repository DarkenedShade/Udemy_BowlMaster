using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public float launchSpeed;

	public bool inPlay
	{
		get
		{
			return _inPlay;
		}
	}
	private bool _inPlay = false;
    private bool canLaunch = true;

    private Rigidbody rigidBody;
	private AudioSource audioSource;
    private Vector3 startPos;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();

        startPos = transform.position;
		rigidBody.useGravity = false;
		_inPlay = false;
        canLaunch = true;

//		Launch(Vector3.forward * launchSpeed);
	}

	public void Launch(Vector3 velocity)
	{
        if (_inPlay || !canLaunch)
            return;

        Vector3 adjustedVel = velocity;

        //Debug.Log("Launch Vector " + adjustedVel);
		rigidBody.useGravity = true;
		rigidBody.velocity = adjustedVel;
		audioSource.Play ();
		_inPlay = true;
	}

    public void Reset()
    {
        transform.position = startPos;
        transform.transform.rotation = Quaternion.identity;
        rigidBody.angularVelocity = Vector3.zero;
        rigidBody.velocity = Vector3.zero;
        rigidBody.useGravity = false;
        _inPlay = false;
        canLaunch = false;
    }

    public void CanLaunch()
    {
        canLaunch = true;
    }
}
