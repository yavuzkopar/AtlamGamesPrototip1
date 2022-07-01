using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState gameState;
    [SerializeField] UnityEvent bossTime;
    [SerializeField] UnityEvent endTime;
    [SerializeField] CinemachineVirtualCamera[] cameras;
    [SerializeField] GameObject altPanel;
    [SerializeField] int killGoal;
    [SerializeField] Transform weaponParent;
    [SerializeField] Transform fireParent;
    private void Awake()
    {
        Instance = this;
    }
    int inBoss;
    private void Start()
    {
        
        weaponParent.GetChild(PlayerPrefs.GetInt("ChosenWeapon")).gameObject.SetActive(true);
      FireManager.Instance.weapon = fireParent.GetChild(PlayerPrefs.GetInt("ChosenWeapon")).GetComponent<Weapon>();
    }
    public void SetWeapon(int index)
    {
        PlayerPrefs.SetInt("ChosenWeapon", index);
    }
    private void Update()
    {
        if (inBoss > 1)
            return;
        if (UIManager.Instance.killed >= killGoal)
        {
            inBoss++;
            if(inBoss== 1)
            {
                bossTime?.Invoke();
                Hadi();
                
            }

        }
            
    }

    private void Hadi()
    {
        Invoke(nameof(SetDefCam), 2);
    }

    void SetDefCam()
    {
        foreach (var item in cameras)
        {
            item.Priority = 10;
        }
        cameras[0].Priority = 11;
        altPanel.SetActive(true);
    }

    public void SetCamera(int index)
    {
        foreach (var item in cameras)
        {
            item.Priority = 10;
        }
        cameras[index].Priority = 11;
    }
    public void EndLevel()
    {
        cameras[3].Priority = 12;
        endTime?.Invoke();
    }
}
public enum GameState
{
    Fight,
    Boss

}
