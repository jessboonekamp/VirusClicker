using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Rocket: MonoBehaviour{
    public GameObject textBox;
    public GameObject costText;
    public GameObject numText;

    public int cost = 50;
    public int num = 0;


    void Update()
    {
        costText.GetComponent<Text>().text = "Cost: " + cost;
        numText.GetComponent<Text>().text = "" + num;
    }


    public void OnClick(){
        if (GlobalVirus.peopleInfected >= cost)
        {
            //Adjusting infected and cost of item
            GlobalVirus.peopleInfected -= cost;
            num += 1;
            cost = (int)((float)cost * 1.2f);

            //The upgrade
            float temp = Rocket.offset;
            Rocket.offset = (float)temp / 1.5f;
        }
    }

    


    public void OnEnter(){
        textBox.SetActive(true);
    }

    public void OnExit(){
        textBox.SetActive(false);
    }
}
