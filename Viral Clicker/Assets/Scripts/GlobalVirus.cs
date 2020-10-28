using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GlobalVirus : MonoBehaviour{

    public static BigInteger totalInfected;
    public static BigInteger peopleInfected;
    //public static BigInteger peopleDead;
    public static BigInteger population;
    public static BigInteger totalPopulation = 761300000000;
    public GameObject infectedDisplay;
    public GameObject deadDisplay;
    public GameObject populationDisplay;
    public GameObject clouds;
    public static float mortalityRate = 0.3f;
    public static float killTime = 2f;

    void start(){
    }


    void Update(){
        Transform cloudTrans = clouds.GetComponent<Transform>();
        cloudTrans.Rotate(0, 0, 0.01f);
        if (peopleInfected > population) peopleInfected = population;
        population = totalPopulation;// - peopleDead;
        infectedDisplay.GetComponent<Text>().text = "People infected: " + peopleInfected;
        //deadDisplay.GetComponent<Text>().text = "People deceased: " + peopleDead;
        populationDisplay.GetComponent<Text>().text = "Population: " + population;

        if (population <= 0) {
            wonGame();
        }
    }

    public void wonGame() {
        population = 0;
        infectedDisplay.GetComponent<Text>().text = "Lol you win cuzzie";
        deadDisplay.GetComponent<Text>().text = "Well done";
        populationDisplay.GetComponent<Text>().text = "Population: 0";
        SceneManager.LoadScene("EndScene");
    }
}
