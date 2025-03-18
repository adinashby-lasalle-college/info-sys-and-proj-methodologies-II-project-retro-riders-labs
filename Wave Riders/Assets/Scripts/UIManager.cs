using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject HUDCanvas;

    #region Singleton
    public static UIManager Singleton;

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

    public void PauseGame()
    {
        Time.timeScale = 0f;
        HUDCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        AudioManager.instance.PauseMusic(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        HUDCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        AudioManager.instance.PauseMusic(false);
    }
}
