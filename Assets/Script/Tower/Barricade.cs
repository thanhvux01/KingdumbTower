using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Barricade : MonoBehaviour
{
   [SerializeField] float HP = 100f;

   [SerializeField] float currentHP;

   [SerializeField] GameObject HPObject;
   [SerializeField] Tile whereBeBuilt;
   Barricades barricades;
   Image HPBar;

   private void Awake()
   {
      HPBar = HPObject.GetComponent<Image>();
      barricades = FindObjectOfType<Barricades>();
      if(!whereBeBuilt){
         Debug.LogWarning("Careful this barricade doesn't have address , it can cause bug");
      }
      currentHP = HP;

   }
   // Start is called before the first frame update
   public void GetDamage(float damage)
   {
      currentHP -= damage;
      HPBar.fillAmount = currentHP / HP;
      if (currentHP < 0)
      {
         gameObject.SetActive(false);

         if (whereBeBuilt)
         {
            whereBeBuilt.IsBarricaded = false;
         }
         barricades.BarricadeBeDestroyed();
      }
   }
}
