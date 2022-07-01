using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colt : Weapon
{
    [SerializeField] LayerMask targetLayer;
    [SerializeField] ParticleSystem[] particle;
    [SerializeField] ParticleSystem partic;
    public float damage;
    int particeIndex = 0;
    public override void Fire()
    {
        partic.Play();
      
        bool hasHit = Physics.Raycast(FireManager.Instance.ray, out RaycastHit hit, 100f, targetLayer);
        if (hasHit && (hit.transform.CompareTag("Target") || hit.transform.CompareTag("Civil")))
        {
            hit.transform.GetComponent<Health>().can -= damage;
            Debug.Log("hit");
            if (particeIndex >= particle.Length - 1)
                particeIndex = 0;

            particle[particeIndex].transform.position = hit.point - FireManager.Instance.ray.direction * 0.25f;

            particle[particeIndex].Play();

        }
    }
}
