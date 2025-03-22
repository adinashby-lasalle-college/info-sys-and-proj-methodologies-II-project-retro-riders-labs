using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInAndOut : MonoBehaviour
{
    public static void Fade(GameObject canvas, int TimeToFade)
    {
        CanvasGroup tempCanvas = canvas.GetComponent<CanvasGroup>();
        /*
        Debug.Log(tempCanvas.gameObject.name);

        do
        {
            tempCanvas.alpha += TimeToFade * Time.deltaTime;
            Debug.Log(tempCanvas.alpha);

        } while (tempCanvas.alpha < 1);

        TimeToFade *= 2;

        do
        {
            tempCanvas.alpha -= TimeToFade * Time.deltaTime;

        } while (tempCanvas.alpha > 0);*/
    }

}
