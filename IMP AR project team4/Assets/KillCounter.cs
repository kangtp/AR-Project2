using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KillCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    private Text killCountText;

    private void Start()
    {
        killCountText = GetComponent<Text>();
    }

    public void UpdateKillCount(int killCount)
    {
        killCountText.text = "Kill Count: " + killCount;
    }
}

