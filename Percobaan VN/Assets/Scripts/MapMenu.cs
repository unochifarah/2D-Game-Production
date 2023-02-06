using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapMenu : MonoBehaviour
{
    public static bool isGamePaused = false;

    [SerializeField] public GameObject mapMenu;

    public void ResumeGame()
    {
        mapMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        mapMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
