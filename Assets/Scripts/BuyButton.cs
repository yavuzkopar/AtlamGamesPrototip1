using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
     public int durum;
    Button button;
    [SerializeField]int fiyat;
    [SerializeField] Shop shop;

    private void Start()
    {
        button = GetComponent<Button>();

            
        if(fiyat <= UIManager.Instance.gold)
            button.interactable=true;
        else  
            button.interactable=false;  
    }
    public void SetDurum(int index)
    {
       
        PlayerPrefs.SetInt(gameObject.name,index);
        durum = index;
    }
}
