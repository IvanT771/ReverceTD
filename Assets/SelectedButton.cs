using UnityEngine;
using UnityEngine.UI;

public class SelectedButton : MonoBehaviour
{
    public Image[] buttons;
    private void Start()
    {
       
        foreach (var item in buttons)
        {
            item.color = new Color(255,255,255,0.5f);
        }
    }

    public void Selected(int i)
    {
        if(i>= buttons.Length || i < 0) { return;}

        buttons[i].color = new Color(255, 255, 255, 1f);

        for (int j = 0; j < buttons.Length; j++)
        {
            if(j != i)
            {
                buttons[j].color = new Color(255, 255, 255, 0.5f);
            }
        }
    }
}
