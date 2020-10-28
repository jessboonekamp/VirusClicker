using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Water: MonoBehaviour{
    public GameObject textBox;
    public GameObject costText;
    public GameObject numText;

    public int cost = 500;
    public int num = 0;
    private int WaterInfectionsPerSecond = 5;


    void Update()
    {
        costText.GetComponent<Text>().text = "Cost: " + cost;
        numText.GetComponent<Text>().text = "" + num;
    }

    public void OnClick()
    {
        if (GlobalVirus.peopleInfected >= cost)
        {
            //Adjusting infected and cost of item
            GlobalVirus.peopleInfected -= cost;
            num += 1;
            cost *= 2;

            //The upgrade
            Autoclicker.infectionIncrement += WaterInfectionsPerSecond;
            Autoclicker.infectionsPerSecond *= 1.3f;
        }
    }


    public void OnEnter(){
        textBox.SetActive(true);
    }

    public void OnExit(){
        textBox.SetActive(false);
    }
}
