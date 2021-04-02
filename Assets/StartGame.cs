using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject panelStart;
    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void GameStarter()
    {
        panelStart.SetActive(false);
        Time.timeScale = 1;
    }
}
