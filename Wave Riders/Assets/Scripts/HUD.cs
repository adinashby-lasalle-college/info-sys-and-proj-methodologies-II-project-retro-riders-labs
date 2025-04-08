using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour, IChannel
{
    [SerializeField] private CanvasGroup DamageEffect;

    #region Singleton
    public static HUD Singleton;

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

    // Start is called before the first frame update
    void Start()
    {
        HealthSystem.Singleton.AddObserver(this);
        DamageEffect.alpha = 0;
    }

    public void Updates(int newHealth)
    {
        DamageEffect.GetComponent<Animator>().Play("DamageEffect");
    }

}
