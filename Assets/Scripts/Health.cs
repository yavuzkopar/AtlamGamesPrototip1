using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [HideInInspector]public float can;
    public Transform spn;
    [SerializeField] float maxHealth = 10;

    private void OnEnable()
    {
        can = maxHealth;
    }
    public bool IsDead()
    {
        return can <= 0;
    }
}
