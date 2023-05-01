using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    private Button fireButton;//it is fireSkill Button
    private Image icon; // Fireicon
    private Color imgColor;//Fireicon color
    public bool fireCheck = false; // to check wheter skill is true
    public Shoot shootManger; //becuase to access otehr variable ex) sound , prefeb,transform
    private AudioSource _buttonAudio;// play audio when you clicked button

    private void Awake()
    {
        fireButton = GetComponent<Button>();
        fireButton.onClick.AddListener(ShootFire);
        _buttonAudio = FindObjectOfType<AudioSource>();
        icon = GetComponent<Image>();
        imgColor = icon.color;//to get initial color
    }

    void Update()
    {
        ColorChange();// if you don't have skill. then skiil ui is transparent
    }

    public void ColorChange()
    {
        if (fireCheck) //if you have skill, change color
        {
            Color color = imgColor;
            icon.color = imgColor;
        }
        else  //when you don't have skill then color is transparent
        {
            Color color = icon.color; 
            color.a = 0.3f;
            icon.color = color;
        }
    }

    //it is function if you clicekd button
    public void ShootFire()
    {
        Debug.Log("FireButton clicked");
        if (fireCheck)  // if you have fireSkill
        {
            FireShooting(); //if button clicked, then shoot fire object
            fireCheck = false;//because you use skill
        }
    }

    //shoot fire object
    public void FireShooting()
    {
        Vector3 cameraPostion_z = Camera.main.transform.forward;
        Rigidbody firebulletObject = Instantiate(shootManger.FireBullet.GetComponent<Rigidbody>(), Camera.main.transform.position, Quaternion.identity);
        firebulletObject.AddForce(cameraPostion_z * 1, ForceMode.Impulse);
        _buttonAudio.PlayOneShot(shootManger.FireSound);
    }
}