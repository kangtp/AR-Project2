using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water : MonoBehaviour
{
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

    void Update()
    {
        ColorChange(); // if you don't have skill. then skiil ui is transparent
    }

    // to change color if you have skill
    public void ColorChange()
    {
        if (waterCheck) //if you have skill, change color
        {
            Color color = imgColor; 
            icon.color = imgColor;
        }
        else // when you don't have skill then color is transparent
        {
            Color color = icon.color;
            color.a = 0.3f;
            icon.color = color;
        }
    }

    // it is function if you clicekd button
    public void ShootWater()
    {
        Debug.Log("WaterButton clicked");
        if (waterCheck) // if you have waterSkill
        {
            WaterShooting();    //if button clicked, then shoot water object
            waterCheck = false; //because you use skill
        }
    }

    //shoot water object
    public void WaterShooting()
    {
        Vector3 cameraPostion_z = Camera.main.transform.forward;
        Rigidbody WaterbulletObject = Instantiate(shootManger.WaterBullet.GetComponent<Rigidbody>(), Camera.main.transform.position, Quaternion.identity);
        WaterbulletObject.AddForce(cameraPostion_z * 1, ForceMode.Impulse);
        _buttonAudio.PlayOneShot(shootManger.WaterSound);//play sound
    }
}