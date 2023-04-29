using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Image[] hearts;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void reloadLife(int hp)
    {

        for (int i = 0; i < 5; i++)
        {


            hearts[i].color = new Color(1, 1, 1, 0);

        }

        for (int i = 0; i < hp; i++)
        {
            if (hearts[i] == null)
            {
                break;
            }
            else
            {
                hearts[i].color = new Color(1, 1, 1, 1);
            }
        }

    }
}
