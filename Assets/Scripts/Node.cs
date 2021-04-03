using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color choiseColor = Color.gray;

    private Color startColor;
    private Renderer rend;

    private GameObject mob = null;
    private GameObject model = null;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseOver()
    {
        if (GameMaster.instatiate.isGo) { return; }
        if (Input.GetMouseButtonDown(1))
        {
            if(mob == null) { return;}
            int price = mob.GetComponent<MobsAI>().GetPrice();
            Destroy(model);
            BuildManager.instatiate.ChangeMoney(price);
            mob = null;
            rend.enabled = true;
        }
    }

    private void OnMouseEnter()
    {
        rend.material.color = choiseColor;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    private void OnMouseDown()
    {
        if (GameMaster.instatiate.isGo) { return;}
        if (mob != null)
        {
            Debug.Log("Can't build on this place!");
            return;
        }
        mob = BuildManager.instatiate.GetMob();
        if (mob == null) { return;}

        model = Instantiate(mob,transform.position,transform.rotation);

        rend.enabled = false;

    }
}
