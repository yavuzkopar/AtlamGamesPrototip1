using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Catcher : MonoBehaviour
{
    public static Catcher instance;
    private void Awake()
    {
        instance = this;
        savedPerseon = PlayerPrefs.GetInt("saved");
    }
    public UnityEvent onEnemyTrigger;
    public UnityEvent onFriendTrigger;
    public int savedPerseon;
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.transform.CompareTag("Target"))
        {
            other.gameObject.SetActive(false);
            onEnemyTrigger?.Invoke();
        }
        else if (other.transform.CompareTag("Civil"))
        {
            savedPerseon++;
            other.gameObject.SetActive(false);
            onFriendTrigger?.Invoke();
        }
    }
}
