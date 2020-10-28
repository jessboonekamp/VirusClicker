using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Rocket : MonoBehaviour{
    public Sprite rocket;
    public Sprite explosion;
    private Button button;
    private Vector3 pos;
    public float startSpeed;
    public float speed;
    public static float offset = -20000f;
    public static Boolean hasUpgrade = false;
    private float x;
    private float y;
    private float z = 1f;
    //Canvas variables
    private float w;
    private float h;
    private Canvas canvas;
    private Transform thisTransform;
    private bool hasBeenClicked = false; 
    private int rocketInfectionNumber = 20;
    private AudioSource RocketAudioSource;
    private float timer = 0.0f;

    void Start(){
        speed = startSpeed;
        RocketAudioSource = GetComponent<AudioSource>();
        canvas = FindObjectOfType<Canvas>();
        w = canvas.GetComponent<RectTransform>().rect.width;
        h = canvas.GetComponent<RectTransform>().rect.height;
        button = GetComponent<Button>();
        x = UnityEngine.Random.Range(0, w);
        pos = new Vector3(x, 2*h, z);
        thisTransform = GetComponent<Transform>();
        thisTransform.position = pos;
    }   

    void Update(){
            timer += Time.deltaTime;
            thisTransform.position += new Vector3(0f, speed, 0f);
            if (thisTransform.position.y <= h / 3 && thisTransform.position.y >= -20) {
                thisTransform.localScale += new Vector3(0.015f, 0.015f, 0.015f);
            }
            if (timer >= 0.5f) {
                timer -= 0.5f;
                if (thisTransform.position.y <= h / 3 && thisTransform.position.y >= -20) {
                    speed += 0.004f;
                }
            }
            if (thisTransform.position.y > h + 100) {
                speed = startSpeed;
                thisTransform.localScale = new Vector3(0f, 0f, 0f);
                hasBeenClicked = false;
                thisTransform.position = new Vector3(UnityEngine.Random.Range(0, w), UnityEngine.Random.Range(offset,0), z);
                button.image.overrideSprite = rocket;
            }
            if (hasBeenClicked == true) {
                thisTransform.localScale += new Vector3(0.005f, 0.005f, 0.005f);
            
            }
        
    }
    public void OnClick(){
        if (!hasBeenClicked){
            hasBeenClicked = true;
            StartCoroutine(RocketImageChange());
            GlobalVirus.totalInfected += rocketInfectionNumber;
        }
       
        
    }

    IEnumerator RocketImageChange(){
        button.image.overrideSprite = explosion;
        RocketAudioSource.Play();
        speed = 0f;
        yield return new WaitForSeconds(0.75f);
        speed= startSpeed;
        thisTransform.position = new Vector3(0, h*2, 0);
        hasBeenClicked = true;
    }

}