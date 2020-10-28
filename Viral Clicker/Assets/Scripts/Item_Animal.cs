using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Animal: MonoBehaviour{
    public GameObject textBox;
    public GameObject costText;
    public GameObject numText;

    public int cost = 80;
    public int num = 0;
    private int AnimalInfectionsPerSecond = 1;


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
            cost = (int)((float)cost * 1.4f);

            //The upgrade
            Autoclicker.infectionIncrement += AnimalInfectionsPerSecond;
            Autoclicker.infectionsPerSecond *= 1.1f;
        }
    }

    




    public void OnEnter(){
        textBox.SetActive(true);
    }

    public void OnExit(){
        textBox.SetActive(false);
    }
}
