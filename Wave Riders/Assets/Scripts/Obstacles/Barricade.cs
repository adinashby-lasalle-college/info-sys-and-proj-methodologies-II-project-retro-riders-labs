using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour, IObstacle
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collide();
        }
    }

    public void Collide()
    {
        HealthSystem.Singleton.applyDamage(20);
        Destroy(this.gameObject);
        AudioManager.instance.PlaySFX("WallBreak");
    }
}
