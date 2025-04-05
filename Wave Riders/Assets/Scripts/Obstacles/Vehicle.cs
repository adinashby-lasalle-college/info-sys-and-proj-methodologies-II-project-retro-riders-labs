using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour, IObstacle
{
    private Vector3 playerForward;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerForward = other.GetComponentInParent<PlayerController>().orientationCam.transform.forward;
            Collide();
        }
    }

    public void Collide()
    {
        HealthSystem.Singleton.applyDamage(15);
        AudioManager.instance.PlaySFX("CarCrash");
    }
}
