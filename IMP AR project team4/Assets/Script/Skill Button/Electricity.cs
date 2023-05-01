using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Electricity : MonoBehaviour
{
    // Start is called before the first frame update

    private Button electircButton;// it is electric skill button
    private Image icon; // icon
    private Color imgColor;//icon color
    public bool electricCheck; // it is bool type if you get water skill then it is true else false
    public Shoot shootManger; //becuase to access otehr variable ex) sound , prefeb
    private AudioSource _buttonAudio;//it is play when you clicked button



    private void Awake()
    {
        electircButton = GetComponent<Button>();// to geT BUutton component
        electircButton.onClick.AddListener(ShootElectric);///add shooting event
        _buttonAudio = FindObjectOfType<AudioSource>();//find audioSourceComponent
        icon = GetComponent<Image>();///to get imageComponent
        imgColor = icon.color;//// to store a initial color
    }





    // Update is called once per frame
    void Update()
    {

        //인식처리가 true라면 fireCheck true 아니라면 false 반환

        //Debug.Log(fireCheck);
        ColorChange();// if you don't have skill. then skiil ui is transparent

    }
    public void ColorChange()//if you don't have skill. then skiil ui is transparent
    {


        if (electricCheck) //when image recognize and you get skill
        {
            //Debug.Log("Check");
            Color color = imgColor;
            icon.color = imgColor;//electric ui color exist
        }
        else
        {
            //Debug.Log("noCheck");
            Color color = icon.color;
            color.a = 0.3f;
            icon.color = color;
        }

    }
    public void ShootElectric() //it is function if you clicekd button
    {
        Debug.Log("Button cliceked");
        if (electricCheck) //if you have electricSkill
        {
            Debug.Log("Electric");
            ElectricShooting();
            electricCheck = false;
            //electric check is false 
        }
        else
        {
            //No change
        }
    }
    public void ElectricShooting()// function to fire ElectricBullet
    {
        Vector3 cameraPostion_z = Camera.main.transform.forward;// bullet z -axis direct
        Rigidbody electricBulletObject = Instantiate(shootManger.ElectricBullet.GetComponent<Rigidbody>(), Camera.main.transform.position, Quaternion.identity);// to instanciate bullet 
        electricBulletObject.AddForce(cameraPostion_z * 1, ForceMode.Impulse); //to Fire electric Shooting
        Ray ray = Camera.main.ScreenPointToRay(shootManger.ScreenCenterPoint); //to shoot from centerpointer
        RaycastHit hit;
        _buttonAudio.PlayOneShot(shootManger.ElectricSound);


        if (Physics.Raycast(ray, out hit, shootManger.range, shootManger.shootableMask))
        {
            
        }

        Destroy(electricBulletObject, 3.0f); //// after 3 seconds, then destroy bullet



    }


}