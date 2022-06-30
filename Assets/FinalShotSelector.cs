using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalShotSelector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(PlayerPrefs.GetInt("ChosenWeapon")).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
