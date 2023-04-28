using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water : MonoBehaviour
{
    // Start is called before the first frame update

    private Button waterButton;
    private Image icon; // icon
    private Color imgColor;
    public bool waterCheck = false; // �̹����� �ν��ϸ� true�� �ٲ� �̰��� ���߿� ��ĥ�� ����  �ϴ��� �׽�Ʈ�ϱ� true
    public Shoot shootManger;
    private AudioSource _buttonAudio;



    private void Awake()
    {
        waterButton = GetComponent<Button>();
        waterButton.onClick.AddListener(ShootWater);
        _buttonAudio = FindObjectOfType<AudioSource>();
        icon = GetComponent<Image>();
        imgColor = icon.color;
    }





    // Update is called once per frame
    void Update()
    {

        //�ν�ó���� true��� fireCheck true �ƴ϶�� false ��ȯ

        //Debug.Log(fireCheck);
        ColorChange();

    }
    public void ColorChange()
    {


        if (waterCheck) //when image recognize
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
    public void ShootWater()
    {
        Debug.Log("FireButton cliceked");
        if (waterCheck)
        {
            Debug.Log("Fire");
            WaterShooting();
            waterCheck = false;
            //Fire check is false 
        }
        else
        {
            //No change
        }
    }
    public void WaterShooting()
    {
        Vector3 cameraPostion_z = Camera.main.transform.forward;
        Rigidbody WaterbulletObject = Instantiate(shootManger.WaterBullet.GetComponent<Rigidbody>(), shootManger.transform.position, Quaternion.identity);
        WaterbulletObject.AddForce(cameraPostion_z * 1, ForceMode.Impulse);
        Ray ray = Camera.main.ScreenPointToRay(shootManger.ScreenCenterPoint);
        RaycastHit hit;
        _buttonAudio.PlayOneShot(shootManger.WaterSound);


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