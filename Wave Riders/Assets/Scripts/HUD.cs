using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour, IChannel
{
    [SerializeField] private GameObject DamageEffect;
    [SerializeField] private int TimeToFade;

    // Start is called before the first frame update
    void Start()
    {
        HealthSystem.Singleton.AddObserver(this);
        DamageEffect.GetComponent<CanvasGroup>().alpha = 0;
    }

    public void Updates(int newHealth)
    {
        FadeInAndOut.Fade(DamageEffect, TimeToFade);
    }
}
