using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateDeath : MonoBehaviour{
    
    public bool checkingDeaths = false;

    void Update(){
        if (!checkingDeaths){
            checkingDeaths = true;
            StartCoroutine(Die());
        }
    }

    IEnumerator Die(){
        //GlobalVirus.peopleDead = (long)((float)GlobalVirus.totalInfected * GlobalVirus.mortalityRate);
        yield return new WaitForSeconds(GlobalVirus.killTime);
        checkingDeaths = false;

        //long curDeaths = GlobalVirus.peopleDead;
        //yield return new WaitForSeconds(GlobalVirus.killTime);
        //curDeaths = GlobalVirus.peopleDead - curDeaths;
        //if (Random.Range(0, 100) < (GlobalVirus.mortalityRate * 100))
        //{
        //    GlobalVirus.peopleDead += (long)((float)(curDeaths) * GlobalVirus.mortalityRate);
        //}
        
    }
}
