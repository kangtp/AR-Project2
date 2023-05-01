using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update

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





    // Update is called once per frame
    void Update()
    {

      

        //Debug.Log(fireCheck);
        ColorChange();// if you don't have skill. then skiil ui is transparent

    }
    public void ColorChange()
    {


        if (fireCheck) //to change color if you have skill
        {
            //Debug.Log("Check");
            Color color = imgColor;
            icon.color = imgColor;//fire ui color exist
        }
        else
        {
            //Debug.Log("noCheck");
            Color color = icon.color; //when you don't have skill then color is transparent
            color.a = 0.3f;
            icon.color = color;
        }

    }
    public void ShootFire()//it is function if you clicekd button
    {
        Debug.Log("FireButton cliceked");
        if (fireCheck)
        {
            Debug.Log("Fire");
            FireShooting();
            fireCheck = false;
            
        }
        else
        {
            //No change
        }
    }
    public void FireShooting()
    {
        Vector3 cameraPostion_z = Camera.main.transform.forward;
        Rigidbody firebulletObject = Instantiate(shootManger.FireBullet.GetComponent<Rigidbody>(), Camera.main.transform.position, Quaternion.identity);
        firebulletObject.AddForce(cameraPostion_z * 1, ForceMode.Impulse);
        Ray ray = Camera.main.ScreenPointToRay(shootManger.ScreenCenterPoint);
        RaycastHit hit;
        _buttonAudio.PlayOneShot(shootManger.FireSound);


        if (Physics.Raycast(ray, out hit, shootManger.range, shootManger.shootableMask))
        {
            
        }

        Destroy(firebulletObject, 3.0f);


    }


}