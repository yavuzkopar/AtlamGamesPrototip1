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
    public Ray ray;
    private static FireManager instance;
    public static FireManager Instance { get { return instance; } }
    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        ray = Camera.main.ScreenPointToRay(mage.rectTransform.position);
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
