using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Air: MonoBehaviour{
    public GameObject textBox;
    public GameObject costText;
    public GameObject numText;

    public int cost = 1500;
    public int num = 0;

    void Update()
    {
        costText.GetComponent<Text>().text = "Cost: " + cost;
        numText.GetComponent<Text>().text = "" + num;
    }

    public void OnClick()
    {
        if (GlobalVirus.peopleInfected >= cost && num < 6)
        {
            //Adjusting infected and cost of item
            GlobalVirus.peopleInfected -= cost;
            num += 1;
            cost = (int)((float)cost * 1.2f);

            //The upgrade
            Autoclicker.infectionIncrement += 1;
            Autoclicker.infectionIncrement *= Autoclicker.infectionIncrement;
            Autoclicker.infectionsPerSecond *= 2f;
        }
    }



    public void OnEnter(){
        textBox.SetActive(true);
    }

    public void OnExit(){
        textBox.SetActive(false);
    }
}
