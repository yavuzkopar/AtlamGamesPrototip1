using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] float damage;
    Transform par;

    private void Awake()
    {
        par = transform.parent;
    }

    private void OnEnable()
    {
        Invoke(nameof(Deactive), 3);
    }
    void Deactive()
    {
        gameObject.SetActive(false);
        transform.parent = par;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Target") || other.gameObject.CompareTag("Civil"))
        {
            Health h = other.GetComponent<Health>();
            h.can -= damage;
            transform.parent = h.spn;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
