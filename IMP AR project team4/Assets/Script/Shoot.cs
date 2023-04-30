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
    public Button FireButton;
    public Button WaterButton;
    public Button ElectricButton;

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




    public Camera _ArCamera; // because to do Phycis.raycast


    void Start()
    {
        ScreenCenterPoint = new Vector2(Camera.main.pixelWidth / 2, _ArCamera.pixelHeight / 2);
        _audioSource = GetComponent<AudioSource>();
        cameraPostion_z = Camera.main.transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId) && Input.touchCount==1)
            {
                Debug.Log("button");
                
            }
            else
            {
               
                Shooting();
            }

        }
        cameraPostion_z = Camera.main.transform.forward;
        ScreenCenterPoint = new Vector2(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2);

    }

    public void Shooting()
    {

        cameraPostion_z = Camera.main.transform.forward;

        Ray ray = Camera.main.ScreenPointToRay(ScreenCenterPoint);
        RaycastHit hit;
        _audioSource.PlayOneShot(shootingSound);
        if (Physics.Raycast(ray, out hit, range, shootableMask))
        {
            

            
            if (hit.collider.tag == "fireObject")
            {
                //get fire skill and turn on the fire UI light
                Debug.Log("Fire Skil Get!");
                //경덕이가 만든 스킬 유아이 온
                hit.collider.GetComponent<FireObject>().getFireSkill();
                return;
            }

            if (hit.collider.tag == "waterObject")
            {
                Debug.Log("Water Skill Get!");
                hit.collider.GetComponent<waterObject>().getWaterSkill();
                return;
            }

            if (hit.collider.tag == "electricityObject")
            {
                Debug.Log("Electricity Skill Get!");
                hit.collider.GetComponent<ElectricityObject>().getElectricitySkill();
                return;
            }

        }
        Rigidbody bulletObject = Instantiate(bullet.GetComponent<Rigidbody>(), Camera.main.transform.position, bullet.transform.rotation);
        bulletObject.AddForce(cameraPostion_z * speed, ForceMode.Impulse);
    }



  
   



    private void OnGUI()
    {
        float xmin = (Screen.width / 2) - (crosshairSize / 2);
        float ymin = (Screen.height / 2) - (crosshairSize / 2);
        GUI.DrawTexture(new Rect(xmin, ymin, crosshairSize, crosshairSize), crosshair);
    }
}