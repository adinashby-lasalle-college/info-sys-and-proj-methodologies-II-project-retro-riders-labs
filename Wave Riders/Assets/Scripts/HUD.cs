using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour, IChannel
{
    [SerializeField] private CanvasGroup DamageEffect;
    [SerializeField] private float TimeToFade;

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
