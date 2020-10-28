using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Plane : MonoBehaviour{
    public Sprite plane;
    public Sprite explosion;
    private Button button;
    private Vector3 pos;
    public float startSpeed;
    public float speed;
    public static float offset = -10000f;
    private float x;
    private float y;
    private float z = 1f;
    //Canvas variables
    private float w;
    private float h;
    private Canvas canvas;
    private Transform thisTransform;
    private bool hasBeenClicked = false; 
    private int planeInfectionNumber = 50;
    private AudioSource RocketAudioSource;
    private float timer = 0.0f;

    void Start(){
        speed = startSpeed;
        RocketAudioSource = GetComponent<AudioSource>();
        canvas = FindObjectOfType<Canvas>();
        w = canvas.GetComponent<RectTransform>().rect.width;
        h = canvas.GetComponent<RectTransform>().rect.height;
        button = GetComponent<Button>();
        y = Random.Range(0, h/5);
        pos = new Vector3(2*w, y, z);
        thisTransform = GetComponent<Transform>();
        thisTransform.position = pos;
        thisTransform.Rotate(0, 0, -90);
    }

    void Update(){
        timer += Time.deltaTime;
        thisTransform.position += new Vector3(speed, 0f, 0f);
        if(thisTransform.position.x <= w/4 && thisTransform.position.x >=0){
                thisTransform.localScale += new Vector3(0.02f, 0.02f, 0.02f);
            }
        else if(thisTransform.position.x >= w*(0.75) && thisTransform.position.x <= w+100){
            thisTransform.localScale += new Vector3(-0.02f, -0.02f, -0.02f);
        }
        if(thisTransform.position.x > w+100){
            speed = startSpeed;
            thisTransform.localScale = new Vector3(0f, 0f, 0f);
            hasBeenClicked = false;
            thisTransform.position = new Vector3(Random.Range(0, offset), Random.Range(0, h/4) , z);
            button.image.overrideSprite = plane;
        }
        if(hasBeenClicked == true){
            thisTransform.localScale += new Vector3(0.005f, 0.005f, 0.005f);
        }
        
    }
    public void OnClick(){
        if (!hasBeenClicked){
            hasBeenClicked = true;
            StartCoroutine(RocketImageChange());
            GlobalVirus.peopleInfected += planeInfectionNumber;
        }
    }

    IEnumerator RocketImageChange(){
        thisTransform.Rotate(0, 0, 90);
        button.image.overrideSprite = explosion;
        RocketAudioSource.Play();
        hasBeenClicked = true;
        speed = 0f;
        yield return new WaitForSeconds(0.75f);
        speed = startSpeed;
        thisTransform.position = new Vector3(w*2, 0, 0);
        thisTransform.Rotate(0, 0, -90);
        hasBeenClicked = false;
    }
}