using UnityEngine;
using System.Collections;

public class PitDestroyer : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        Pin pin = other.gameObject.GetComponentInParent<Pin>();
        if (pin)
            Destroy(pin.gameObject);
    }
}
