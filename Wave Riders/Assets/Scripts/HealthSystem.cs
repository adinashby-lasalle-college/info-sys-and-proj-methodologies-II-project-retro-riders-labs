using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    #region Singleton
    public static HealthSystem Singleton;
    
    public void Awake()
    {
        if (Singleton == null)
        {
            Singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    [SerializeField] private int maxHealth;
    public static int health;
    
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //update health UI
    }

    public void applyDamage(int damage)
    {
        health -= damage;
        if(health < 0)
        {
            //Call death function;
        }
    }
}
