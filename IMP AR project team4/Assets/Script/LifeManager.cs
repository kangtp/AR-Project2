using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Image[] hearts; // it is player Hp

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void reloadLife(int hp) //Function that changes the color of the heart as much as the remaining hp
    {

        for (int i = 0; i < 5; i++) 
        {


            hearts[i].color = new Color(1, 1, 1, 0); // first heart image is transparent

        }

        for (int i = 0; i < hp; i++) 
        {
            if (hearts[i] == null) // if heart image null then break
            {
                break;
            }
            else
            {
                hearts[i].color = new Color(1, 1, 1, 1); // color change as the remain hp 
            }
        }

    }
}
