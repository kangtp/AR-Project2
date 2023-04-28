using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update

    private Button fireButton;
    private Image icon; // icon
    private Color imgColor;
    public bool fireCheck = false; // 이미지를 인식하면 true로 바뀜 이것은 나중에 합칠때 구현  일단은 테스트니깐 true
    public Shoot shootManger;
    private AudioSource _buttonAudio;



    private void Awake()
    {
        fireButton = GetComponent<Button>();
        fireButton.onClick.AddListener(ShootFire);
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


        if (fireCheck) //when image recognize
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
    public void ShootFire()
    {
        Debug.Log("FireButton cliceked");
        if (fireCheck)
        {
            Debug.Log("Fire");
            FireShooting();
            fireCheck = false;
            //Fire check is false 
        }
        else
        {
            //No change
        }
    }
    public void FireShooting()
    {
        Vector3 cameraPostion_z = Camera.main.transform.forward;
        Rigidbody FirebulletObject = Instantiate(shootManger.FireBullet.GetComponent<Rigidbody>(), shootManger.transform.position, Quaternion.identity);
        FirebulletObject.AddForce(cameraPostion_z * 1, ForceMode.Impulse);
        Ray ray = Camera.main.ScreenPointToRay(shootManger.ScreenCenterPoint);
        RaycastHit hit;
        _buttonAudio.PlayOneShot(shootManger.FireSound);


        if (Physics.Raycast(ray, out hit, shootManger.range, shootManger.shootableMask))
        {
            //if (hit.collider.CompareTag("Boss"))
            //{

            //}
            //else if (hit.collider.CompareTag("FireEnemy"))
            //{

            //}
            //else if (hit.collider.CompareTag("WaterEnemy"))
            //{

            //}
            //else if (hit.collider.CompareTag("GroundEnemy"))
            //{


            //}
            //else
            //{

            //}
        }




    }


}