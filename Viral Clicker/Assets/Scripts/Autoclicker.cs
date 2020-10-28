using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Numerics;


public class Autoclicker : MonoBehaviour
{
    public static float infectionsPerSecond = 1f;
    public static BigInteger infectionIncrement = 0;
    public bool checkingInfections = false;

    public Autoclicker() { 

    }

    void Update()
    {
        if (!checkingInfections)
        {
            checkingInfections = true;
            StartCoroutine(Infect());
        }
    }

    IEnumerator Infect()
    {
        GlobalVirus.peopleInfected += infectionIncrement;
        GlobalVirus.totalInfected += infectionIncrement;
        yield return new WaitForSeconds(1 / infectionsPerSecond);
        checkingInfections = false;
    }
}
