using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shop : MonoBehaviour
{
    public BuyButton[] buyButtons;

    private void Start()
    {
          
        foreach (var item in buyButtons)
        {
            if(1 == PlayerPrefs.GetInt(item.name))
            {
                item.gameObject.SetActive(false);
            }
            else
            {
                item.gameObject.SetActive(true);
            }
        }
    }
}
