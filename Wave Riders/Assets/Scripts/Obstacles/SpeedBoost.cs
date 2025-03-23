using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float forceMultiplier;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 playerForward = other.GetComponent<PlayerController>().orientationCam.transform.forward;
            other.GetComponentInParent<Rigidbody>().AddForce(playerForward * forceMultiplier, ForceMode.Impulse);
            Debug.Log(other.GetComponentInParent<Rigidbody>().gameObject.name);
        }
    }
}
