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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Collide()
    {
        HealthSystem.Singleton.applyDamage(15);
    }
}
