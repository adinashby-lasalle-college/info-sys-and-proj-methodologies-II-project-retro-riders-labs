using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour, IObstacle
{
    [SerializeField] private GameObject BreakableBarricade;
    private Quaternion spawnQ;
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
        Transform coords = this.gameObject.transform;
        //Transform Pivot is off center so must adjust transform spawn
        coords.position = new Vector3(coords.position.x, coords.position.y - (float)12.99, coords.position.z - (float)2.24);
        Destroy(this.gameObject);
        Instantiate(BreakableBarricade, coords.position,coords.rotation);
        AudioManager.instance.PlaySFX("WallBreak");

    }
}
