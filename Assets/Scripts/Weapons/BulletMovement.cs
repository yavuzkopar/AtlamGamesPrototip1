using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Kazanma;
    [SerializeField] TextMeshProUGUI Kaybetme;
    [SerializeField] GameObject restartButon;

    private void OnEnable()
    {
        GameManager.Instance.SetCamera(2);
    }
    void Update()
    {
        
        transform.forward = FireManager.Instance.ray.direction;
        transform.Translate(Vector3.forward * Time.deltaTime * 2f);
    }
    float damage = 100;
    private void OnTriggerEnter(Collider other)
    {
       
            if (other.gameObject.CompareTag("Target") || other.gameObject.CompareTag("Civil"))
            {
                Health h = other.GetComponent<Health>();
                h.can -= damage;
                
            GameManager.Instance.EndLevel();
            gameObject.SetActive(false);
                if(other.gameObject.CompareTag("Target"))
                {
                Kazanma.gameObject.SetActive(true);
                Kaybetme.gameObject.SetActive(false);
                restartButon.gameObject.SetActive(false);
                }
            }
        
    }
}
