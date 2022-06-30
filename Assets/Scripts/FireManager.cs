using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireManager : MonoBehaviour
{
    
    public Weapon weapon;
    [SerializeField] Image mage;
    [SerializeField] Transform tr;
    [SerializeField] LayerMask layer;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(mage.rectTransform.position);
        bool hasHit = Physics.Raycast(ray, out RaycastHit hit, 100f, layer);
        if (hasHit)
            tr.LookAt(hit.point);

    }
    public void WeaponSwitch(Weapon w)
    {
     
        weapon = w;
       
    }
    public void Fire()
    {
      weapon.Fire();
    }
   
}
