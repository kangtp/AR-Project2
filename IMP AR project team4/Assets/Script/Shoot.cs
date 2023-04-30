using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bullet; // it is buller prefeb
    public GameObject FireBullet; // it is fire Prefeb
    public GameObject WaterBullet;// it is Water Prefeb
    public GameObject ElectricBullet;// it is Ground Prefeb
    public Texture2D crosshair; // crosshair prefeb

    public EventSystem _eventSystem;
    

    public AudioClip shootingSound;
    public AudioClip FireSound;
    public AudioClip WaterSound;
    public AudioClip ElectricSound;
    private AudioSource _audioSource;

    public Vector3 cameraPostion_z;


    private bool touchPressed = false; // it is system touch on/off
    public float crosshairSize;
    public int range;
    public LayerMask shootableMask;
    public Vector2 ScreenCenterPoint;// it is center of phone
    public float speed; //bullet speed






    void Start()
    {
        ScreenCenterPoint = new Vector2(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);
        _audioSource = GetComponent<AudioSource>();
        cameraPostion_z = Camera.main.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)// when touch screen
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) && Input.touchCount==1)// if touch ui
            {
                Debug.Log("button");
                
            }
            else // if not touch ui, then shooting 
            {
               
                Shooting();
            }

        }
        cameraPostion_z = Camera.main.transform.forward; // because it is exist to fire bullet 
        ScreenCenterPoint = new Vector2(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2); // crosshair position

    }

    public void Shooting()
    {

        cameraPostion_z = Camera.main.transform.forward; // it is exist to shooting 

        Ray ray = Camera.main.ScreenPointToRay(ScreenCenterPoint);// ray
        RaycastHit hit;// hit 
        _audioSource.PlayOneShot(shootingSound);// when fire bullet, play sound 
        if (Physics.Raycast(ray, out hit, range, shootableMask))// raycast about skill
        {
            
            // because it is exist to depend skill item , when skillitem on, you dont throw cunai
            
            if (hit.collider.tag == "fireObject")
            {
                //get fire skill and turn on the fire UI light
                Debug.Log("Fire Skil Get!");
                hit.collider.GetComponent<FireObject>().getFireSkill(); //FireSkill get 
                return;
            }

            if (hit.collider.tag == "waterObject")
            {
                Debug.Log("Water Skill Get!");
                hit.collider.GetComponent<waterObject>().getWaterSkill();//WaterSkill get
                return;
            }


            if (hit.collider.tag == "electricityObject")
            {
                Debug.Log("Electricity Skill Get!");
                hit.collider.GetComponent<ElectricityObject>().getElectricitySkill();//when recognize electirc img 
                return;
            }

        }
        Rigidbody bulletObject = Instantiate(bullet.GetComponent<Rigidbody>(), Camera.main.transform.position, bullet.transform.rotation); //if dont recoginized img , then just shooting
        bulletObject.AddForce(cameraPostion_z * speed, ForceMode.Impulse); // addforce for bullet
    }



  
   



    private void OnGUI() // it is exist to visulaize croosshair to screenCenter 
    {
        float xmin = (Screen.width / 2) - (crosshairSize / 2);
        float ymin = (Screen.height / 2) - (crosshairSize / 2);
        GUI.DrawTexture(new Rect(xmin, ymin, crosshairSize, crosshairSize), crosshair);
    }
}