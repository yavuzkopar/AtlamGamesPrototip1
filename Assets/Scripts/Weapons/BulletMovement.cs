using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletMovement : MonoBehaviour
{
   [SerializeField] Image mage;
    [SerializeField] TextMeshProUGUI Kazanma;
    [SerializeField] TextMeshProUGUI Kaybetme;
    [SerializeField] GameObject restartButon;
   
    Ray ray;
    // Update is called once per frame
    private void OnEnable()
    {
        GameManager.Instance.SetCamera(2);
    }
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(mage.rectTransform.position);
        transform.forward = ray.direction;
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
