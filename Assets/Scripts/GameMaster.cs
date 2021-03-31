using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instatiate; //���������

    [Header("��������� �������")]
    [SerializeField] private GameObject panelPause = null;

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
}
