using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Electricity : MonoBehaviour
{
    // Start is called before the first frame update

    private Button electircButton;
    private Image icon; // icon
    private Color imgColor;
    public bool electricCheck; // 이미지를 인식하면 true로 바뀜 이것은 나중에 합칠때 구현  일단은 테스트니깐 true
    public Shoot shootManger;
    private AudioSource _buttonAudio;



    private void Awake()
    {
        electircButton = GetComponent<Button>();
        electircButton.onClick.AddListener(ShootElectric);
        _buttonAudio = FindObjectOfType<AudioSource>();
        icon = GetComponent<Image>();
        imgColor = icon.color;
    }





    // Update is called once per frame
    void Update()
    {

        //인식처리가 true라면 fireCheck true 아니라면 false 반환

        //Debug.Log(fireCheck);
        ColorChange();

    }
    public void ColorChange()
    {


        if (electricCheck) //when image recognize
        {
            //Debug.Log("Check");
            Color color = imgColor;
            icon.color = imgColor;
        }
        else
        {
            //Debug.Log("noCheck");
            Color color = icon.color;
            color.a = 0.3f;
            icon.color = color;
        }

    }
    public void ShootElectric()
    {
        Debug.Log("FireButton cliceked");
        if (electricCheck)
        {
            Debug.Log("Fire");
            ElectricShooting();
            electricCheck = false;
            //Fire check is false 
        }
        else
        {
            //No change
        }
    }
    public void ElectricShooting()
    {
        Vector3 cameraPostion_z = Camera.main.transform.forward;
        Rigidbody electricBulletObject = Instantiate(shootManger.ElectricBullet.GetComponent<Rigidbody>(), Camera.main.transform.position, Quaternion.identity);
        electricBulletObject.AddForce(cameraPostion_z * 1, ForceMode.Impulse);
        Ray ray = Camera.main.ScreenPointToRay(shootManger.ScreenCenterPoint);
        RaycastHit hit;
        _buttonAudio.PlayOneShot(shootManger.ElectricSound);


        if (Physics.Raycast(ray, out hit, shootManger.range, shootManger.shootableMask))
        {
            
        }

        Destroy(electricBulletObject, 3.0f);


    }


}