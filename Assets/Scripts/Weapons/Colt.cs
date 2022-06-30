using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colt : Weapon
{
    [SerializeField] LayerMask targetLayer;
    [SerializeField] ParticleSystem[] particle;
    [SerializeField] ParticleSystem partic;
    [SerializeField] Image mage;
    public float damage;
    Ray ray;
    int particeIndex = 0;
    public override void Fire()
    {
        ray = Camera.main.ScreenPointToRay(mage.rectTransform.position);
        partic.Play();
        bool hasHit = Physics.Raycast(ray, out RaycastHit hit, 100f, targetLayer);
        if (hasHit && (hit.transform.CompareTag("Target") || hit.transform.CompareTag("Civil")))
        {
            hit.transform.GetComponent<Health>().can -= damage;
            Debug.Log("hit");
            if (particeIndex >= particle.Length - 1)
                particeIndex = 0;

            particle[particeIndex].transform.position = hit.point - ray.direction * 0.25f;

            particle[particeIndex].Play();

        }
    }
}
