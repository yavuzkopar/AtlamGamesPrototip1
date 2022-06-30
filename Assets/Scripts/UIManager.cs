using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] TextMeshProUGUI savedPeople;
    [SerializeField] TextMeshProUGUI savedEndPeople;
    [SerializeField] TextMeshProUGUI killedRewards;
    [SerializeField] TextMeshProUGUI killedEndRewards;
    
    public int gold;
    public int killed;
    private void Awake()
    {
        
        Instance = this;
        gold = PlayerPrefs.GetInt("gold");
    }
    private void Start()
    {
       
        killedRewards.text = gold.ToString();
        savedPeople.text = PlayerPrefs.GetInt("saved").ToString();
        
    }
    public void UpdateMoney(int girdi)
    {
        gold += girdi;
        killedRewards.text = gold.ToString();
    }
    public void SavedPeopleUpdate(string s)
    {
        savedPeople.text = s;
    }
    public void KilledUpdate()
    {
        killedRewards.text = gold.ToString();
    }
    public void EndSaved()
    {
        savedEndPeople.text = "Saved People " + Catcher.instance.savedPerseon.ToString();
    }
    public void EndCoin()
    {
        killedEndRewards.text = "Shooted Enemies " + killed.ToString();
    }
    public void SceneUpdate(int index)
    {
        PlayerPrefs.SetInt("gold", gold);
        
        PlayerPrefs.SetInt("saved", Catcher.instance.savedPerseon);
        SceneManager.LoadScene(index);
    }

}
