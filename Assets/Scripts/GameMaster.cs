using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instatiate; //Синголтон
    public bool isGo = false;

    [SerializeField] private GameObject panelStart;
    [Header("Связующие объекты")]
    [SerializeField] private GameObject panelPause = null;
    [SerializeField] private PanelTools panelTools = null;
    [Space(3)]
    [SerializeField] private GameObject panelWin = null;
    [SerializeField] private GameObject panelOver = null;
    [Space(3)]
    [SerializeField] private GameObject[] nods = null;

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

        foreach (var nod in nods)
        {
            nod.SetActive(false);
        }
    }

    public void GameOver()
    {
        panelOver.SetActive(true);

    }

    public void GameWin()
    {
        panelWin.SetActive(true);
    }
}
