using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instatiate;

    [SerializeField] private int myMoney = 1000;

    [SerializeField] private GameObject archer = null;
    [SerializeField] private int archerPrice = 30;

    [SerializeField] private GameObject big = null;
    [SerializeField] private int bigPrice = 20;

    [SerializeField] private GameObject bomj = null;
    [SerializeField] private int bomjPrice = 10;

    [SerializeField] private TextMeshProUGUI textMyMoney;

    private GameObject mob = null;
    private int price = 1000;

    private void Awake()
    {
        if(instatiate != null) { Debug.LogError("BuildManaget is instatiate");}
        instatiate = this;
    }
    private void Start()
    {
        textMyMoney.text = myMoney+"$";
    }

    public void SelectedMob(string name)
    {
        switch (name)
        {
            case "bomj": { mob = bomj; price = bomjPrice;  break;}
            case "big": { mob = big; price = bigPrice; break;}
            case "archer": { mob = bomj; price = archerPrice;  break;}
            default:
                break;
        }
    }

    public GameObject GetMob()
    {
        if (myMoney < price || mob == null) { return null;}

        myMoney-=price;
        textMyMoney.text = myMoney+"$";
        
        return mob;
    }
}
