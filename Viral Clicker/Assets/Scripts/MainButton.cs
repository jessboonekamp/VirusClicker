using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainButton : MonoBehaviour{
    public static int infectionsPerClick = 1;
    public AudioSource audioSource;

    public void OnClick(){
        GlobalVirus.peopleInfected += infectionsPerClick;
        //GlobalVirus.totalInfected += infectionsPerClick;
        audioSource.Play();
    }
}
