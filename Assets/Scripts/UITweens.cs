using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITweens : MonoBehaviour
{
    
    [SerializeField] Transform hedef;
    [SerializeField] Transform hedef1;
    [SerializeField]float lerpvalue = 0;
    Vector3 p;
    Vector3 pos;
    Catcher catcher;

    private void Awake()
    {
        catcher = GameObject.FindGameObjectWithTag("Catcher").GetComponent<Catcher>();
    }
    private void OnEnable()
    {
        transform.DOScale(Vector3.one, 1);
        p = transform.localPosition;
    }
    void Deactive()
    {
        UIManager.Instance.SavedPeopleUpdate(catcher.savedPerseon.ToString());
        gameObject.SetActive(false);
        UIManager.Instance.KilledUpdate();
    }
    
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 180);
        Vector3 a = Vector3.Lerp(p, hedef1.localPosition, lerpvalue);
        Vector3 b = Vector3.Lerp(hedef1.localPosition, hedef.localPosition, lerpvalue);
        pos = Vector3.Lerp(a, b, lerpvalue);
        transform.localPosition = pos;
        lerpvalue += Time.deltaTime * 0.5f;
        if (lerpvalue >= 1)
            Deactive();
    }
    private void OnDisable()
    {
        transform.localPosition = p;
        transform.localScale = Vector3.zero;
        lerpvalue = 0;
    }
}
