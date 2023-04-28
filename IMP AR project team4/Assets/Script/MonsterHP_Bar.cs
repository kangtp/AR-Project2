using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHP_Bar : MonoBehaviour
{
   [SerializeField] private Image hpBarsprite;

   private Camera _cam;

   private bool Canshow = false;

   private void Awake() {
    _cam = Camera.main;
   }

   public void UpdateHpbar(float maxHp, float currentHp)
   {
     hpBarsprite.fillAmount = currentHp / maxHp;
     Canshow = true;
   }

   private void Update() {


    
   }
}
