using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private int boostVal;
    private float boostPercent;
    private float BoostDuration = 3f;
    private Vector3 OriginalPlayerForwardVelocity;
    private Collider playerCollider;

    private void Start()
    {
        boostPercent = (100 + boostVal) / 100;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponentInParent<PlayerController>().boostActive == false)
        {
            PlayerController playerController = other.GetComponentInParent<PlayerController>();
            Debug.Log("Boosted");
            playerController.boostActive = true;
            playerCollider = other;
            Vector3 playerForward = other.GetComponentInParent<PlayerController>().orientationCam.transform.forward;
            OriginalPlayerForwardVelocity = other.GetComponentInParent<Rigidbody>().velocity;
            other.GetComponentInParent<Rigidbody>().AddForce(playerForward * boostPercent, ForceMode.Impulse);
            StartCoroutine(BoostTimer(playerController));
        }
    }

    private IEnumerator BoostTimer(PlayerController playerController)
    {
        Debug.Log("Boost Timer Started");
        yield return new WaitForSeconds(BoostDuration);
        playerCollider.GetComponentInParent<Rigidbody>().velocity = OriginalPlayerForwardVelocity;
        playerController.boostActive = false; // Deactivate the boost
        Debug.Log("Boost Ended");
    }
}