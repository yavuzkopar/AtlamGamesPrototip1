using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BowArrow : Weapon
{
    [SerializeField] GameObject _arrow;
    [SerializeField] float speed;
    [SerializeField] GameObject[] projectiles;
    float timer = 0;
    Ray ray;
    private void Update()
    {
        timer += Time.deltaTime;
    }
    public override void Fire()
    {
        if(timer > 1f)
        {
            
            ray = FireManager.Instance.ray;
            Obje();
            timer = 0;
        }
       
    }
   void Obje()
    {
        for (int i = 0; i < projectiles.Length; i++)
        {
            if (projectiles[i].activeSelf)
            {
                continue;
            }
            projectiles[i].SetActive(true);
            projectiles[i].transform.position = ray.origin;
            projectiles[i].transform.forward = ray.direction;
            projectiles[i].GetComponent<Rigidbody>().AddForce(ray.direction * speed);
            return;
            
        }
        
    }
}
