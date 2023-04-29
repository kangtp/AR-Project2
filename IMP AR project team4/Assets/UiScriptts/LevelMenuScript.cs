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
        //load the first Level
        
        if(targetScene!=null)
        {
            SceneManager.LoadScene("Level1");
        }
        
   }

   public void PlayLevel2()
   {
		  //load the first Level
		  SceneManager.LoadScene("Level 2");
   }

   public void PlayLevel3()
   {
		  //load the first Level
		  SceneManager.LoadScene("Level 3");
   }
}
