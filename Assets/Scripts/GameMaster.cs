using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instatiate; //���������
    public bool isGo = false;

    [SerializeField] private GameObject panelStart;
    [Header("��������� �������")]
    [SerializeField] private GameObject panelPause = null;
    [SerializeField] private PanelTools panelTools = null;

    private void Awake()
    {
        if(instatiate != null) { Debug.LogError("singleton is build!");}

        instatiate = this;
    }

    public void SetPause(bool isPause)
    {
        if(panelPause == null) { return;}

        if (isPause) 
        { 
            panelPause.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            panelPause.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void GameStarter()
    {
        panelStart.SetActive(false);
        Time.timeScale = 1;
        isGo = true;

        if(panelTools != null)
        {
            panelTools.ShowHidePanel();
        }
    }
}
