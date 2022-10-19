using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject memupanel;

    private PinSpawner pinspawner;

    private void Awake()
    {
        memupanel.SetActive(false);
    }

    public void Pause_button()
    {
        Time.timeScale = 0;
        memupanel.SetActive(true);
    }
    public void Play_button()
    {
        Time.timeScale = 1;
        memupanel.SetActive(false);
    }
    public void RePlay_button()
    {
        Time.timeScale = 1;
        memupanel.SetActive(false);
        SceneManager.LoadScene(0);
    }
}
