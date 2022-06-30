using UnityEngine;
using UnityEngine.AI;


public class Runner : MonoBehaviour
{

    [SerializeField] Transform goal;
    NavMeshAgent agent;
    Health _health;
    [SerializeField] Animator animator;
    string _tagg;
    public int reward;
    void Awake()
    {
        goal = GameObject.FindGameObjectWithTag("RunnerGoal").transform;
        _health = GetComponent<Health>();  
        agent = GetComponent<NavMeshAgent>();
        _tagg = gameObject.tag;
    }
    private void OnEnable()
    {
        agent.SetDestination(goal.position);
        gameObject.tag = _tagg;
 
        
    }
    float timer = 0;

    int a = 0;
    int b = 0;
    [SerializeField] GameObject coin;
    void Update()
    {
        if(_health.IsDead())
        {
          
            a++;
            if (a == 1 && gameObject.CompareTag("Target"))
            {
                UIManager.Instance.killed++;
                UIManager.Instance.gold += reward;
                coin.SetActive(true);
                
            }
            timer += Time.deltaTime;
            if(timer >= 2)
            {

                gameObject.SetActive(false);
                a = 0;
                timer = 0;  
            }
                
            gameObject.tag = "deadMan";
            animator.SetBool("Dead", true);
            agent.ResetPath();
            return;
        }
    }



}
