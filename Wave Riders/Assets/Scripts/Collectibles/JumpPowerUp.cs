using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUp : MonoBehaviour, ICollectible
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    void Update()
    {

        if (this.CompareTag("Collectible"))
        {
            this.transform.Rotate(Vector3.right);
        }

    }

    public void Collect()
    {
        JumpBar.Singleton.AddPower(25);
        Destroy(this.gameObject);
    }

}
