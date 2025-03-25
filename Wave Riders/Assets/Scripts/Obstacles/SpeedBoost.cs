using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private int boostVal;
    private float boostPercent;

    private void Start()
    {
        boostPercent = (100 + boostVal) / 100;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Boosted");
            Vector3 playerForward = other.GetComponentInParent<PlayerController>().orientationCam.transform.forward;
            other.GetComponentInParent<Rigidbody>().AddForce(playerForward * boostPercent, ForceMode.Impulse);
        }
    }
}
