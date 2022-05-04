using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{

    public int[,] shopItems = new int[4,4];
    public Text PointsTXT;


    void Start()
    {
        PointsTXT.text = "Points Available: " + PlayerHealth.score.ToString();

        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;

        //Cost 
        shopItems[2, 1] = 430; 
        shopItems[2, 2] = 870;
        shopItems[2, 3] = 550;

        //Quantity 
        shopItems[3, 1] = 0;
        shopItems[3, 2]  = 0;
        shopItems[3, 3] = 0;
    }

    // Update is called once per frame
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        float points = PlayerHealth.score;

        if (points >= shopItems[2,ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            points -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            PointsTXT.text = "Points: " + points.ToString();
            ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
            if (ButtonRef.GetComponent<ButtonInfo>().ItemID == 1)
                PlayerHealth.health_normal = 100;
            else if (ButtonRef.GetComponent<ButtonInfo>().ItemID == 2)
                PlayerHealth.health_ear = 100;
            else
                PlayerHealth.health_wrist = 100;

        }
    }
}
