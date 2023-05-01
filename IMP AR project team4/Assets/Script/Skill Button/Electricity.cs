using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Electricity : MonoBehaviour
{
    private Button electircButton;
    private Image icon; // icon
    private Color imgColor;
    public bool electricCheck;
    public Shoot shootManger;
    private AudioSource _buttonAudio;

    private void Awake()
    {
        electircButton = GetComponent<Button>();// to geT BUutton component
        electircButton.onClick.AddListener(ShootElectric);///add shooting event
        _buttonAudio = FindObjectOfType<AudioSource>();//find audioSourceComponent
        icon = GetComponent<Image>();///to get imageComponent
        imgColor = icon.color;//// to store a initial color
    }

    void Update()
    {
        ColorChange();  // if you don't have skill. then skiil ui is transparent
    }

    // to change color if you have skill
    public void ColorChange()
    {
        if (electricCheck) //if you have skill, change color
        {
            Color color = imgColor;
            icon.color = imgColor;//electric ui color exist
        }
        else    // when you don't have skill then color is transparent
        {
            Color color = icon.color;
            color.a = 0.3f;
            icon.color = color;
        }
    }

    // it is function if you clicekd button
    public void ShootElectric()
    {
        Debug.Log("electricityButton clicked");
        if (electricCheck)  // if you have electricity Skill
        {
            ElectricShooting();   //if button clicked, then shoot electricity object
            electricCheck = false;  //because you use skill
        }
    }

    //shoot electricity object
    public void ElectricShooting()
    {
        Vector3 cameraPostion_z = Camera.main.transform.forward;
        Rigidbody electricBulletObject = Instantiate(shootManger.ElectricBullet.GetComponent<Rigidbody>(), Camera.main.transform.position, Quaternion.identity);
        electricBulletObject.AddForce(cameraPostion_z * 1, ForceMode.Impulse);
        _buttonAudio.PlayOneShot(shootManger.ElectricSound);
    }
}