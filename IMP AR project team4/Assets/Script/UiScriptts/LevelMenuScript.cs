using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuScript : MonoBehaviour
{
    private Scene targetScene;
    private void Start()
    {
        targetScene = SceneManager.GetSceneByName("Level1");
    }
    public void PlayLevel1()
    {
        //load the Level 1
        if(targetScene!=null)
        {
            SceneManager.LoadScene("Level1");
        }
    }

   public void PlayLevel2()
   {
		//load the Level 2
		SceneManager.LoadScene("Level2");
   }

   public void PlayLevel3()
   {
		//load the Level 3
		SceneManager.LoadScene("Level3");
   }
}
