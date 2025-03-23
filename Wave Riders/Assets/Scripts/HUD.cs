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
        FadeIn();
        Invoke("FadeOut",2);
    }

    private void FadeIn()
    {
        do
        {
            DamageEffect.alpha += TimeToFade * Time.deltaTime;

        } while (DamageEffect.alpha < 1);
    }

    private void FadeOut()
    {
        TimeToFade *= 2;

        do
        {
            DamageEffect.alpha -= TimeToFade * Time.deltaTime;

        } while (DamageEffect.alpha > 0);
    }
}
