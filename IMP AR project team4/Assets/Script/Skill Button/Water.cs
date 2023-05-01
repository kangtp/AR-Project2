using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water : MonoBehaviour
{
    // Start is called before the first frame update

    private Button waterButton; // it is water skill button
    private Image icon; // icon
    private Color imgColor;// icon color
    public bool waterCheck = false; // it is bool type if you get water skill then it is true else false
    public Shoot shootManger;// becuase to access otehr variable ex) sound , prefeb
    private AudioSource _buttonAudio;// it is play when you clicked button



    private void Awake()
    {
        waterButton = GetComponent<Button>();
        waterButton.onClick.AddListener(ShootWater);
        _buttonAudio = FindObjectOfType<AudioSource>();
        icon = GetComponent<Image>();
        imgColor = icon.color; // to store a initial color
    }





    // Update is called once per frame
    void Update()
    {

        
        
        ColorChange(); // if you don't have skill. then skiil ui is transparent

    }
    public void ColorChange()// to change color if you have skill
    {


        if (waterCheck) //when image recognize and you get skill
        {
            
            Color color = imgColor; 
            icon.color = imgColor;//water ui color exist
        }
        else // when you don't have skill then color is transparent
        {
            //Debug.Log("noCheck");
            Color color = icon.color;
            color.a = 0.3f;
            icon.color = color;
        }

    }
    public void ShootWater()// it is function if you clicekd button
    {
        Debug.Log("WaterButton cliceked");
        if (waterCheck)// if you have waterSkill
        {
            Debug.Log("Water");
            WaterShooting();//if button clicked, then fire waterbullet
            waterCheck = false;//because you use skill waterskillstate is false;
            
        }
        else
        {
            //No change
        }
    }
    public void WaterShooting()// function to fire WaterBullet
    {
        Vector3 cameraPostion_z = Camera.main.transform.forward;
        Rigidbody WaterbulletObject = Instantiate(shootManger.WaterBullet.GetComponent<Rigidbody>(), Camera.main.transform.position, Quaternion.identity);
        WaterbulletObject.AddForce(cameraPostion_z * 1, ForceMode.Impulse);
        Ray ray = Camera.main.ScreenPointToRay(shootManger.ScreenCenterPoint);
        RaycastHit hit;
        _buttonAudio.PlayOneShot(shootManger.WaterSound);//play sound


        if (Physics.Raycast(ray, out hit, shootManger.range, shootManger.shootableMask))
        {
           
        }

        Destroy(WaterbulletObject, 3.0f); // after 3 seconds, then destroy bullet


    }


}