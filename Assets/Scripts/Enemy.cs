using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
	[SerializeField]
	int MAX_HEALTH;
	
	[SerializeField]
	Image ImgHealth;
	private Transform target;
	[SerializeField]
	Animator myAnimator;
	[SerializeField]
	AudioSource myAudioSource;
    [SerializeField]
    float attackSpeed;
	private float timeToAttack;
    [SerializeField]
    int attackDamage;
    [SerializeField]
    float attackDistance;
    [SerializeField]
    public NavMeshAgent agent;
    [SerializeField]
    Collider collision;
    [SerializeField]
    public int defaultSpeed;
    int Health;
    float timeLeft;
    GameObject Globals;

    public virtual void Start()
    {
        agent.speed = defaultSpeed;
        Globals = GameObject.Find( "Globals" );
        Health = MAX_HEALTH;
        GetTarget(GameObject.Find( "Player" ).transform); 
    }
    public void GetTarget(Transform newTarget)
    {
        target = newTarget;
        myAudioSource.Play();
    }
    public virtual void Death()
    {
        timeLeft = 600;
        Globals.GetComponent<Globals>().money += 10;
        agent.speed = 0;
        myAnimator.SetBool("IsWalking", false);
        myAnimator.SetTrigger("Die");
        collision.enabled = false;
    }
    public virtual void Damage(int points, Transform newTarget)
	{
		Health -= points;
		ImgHealth.fillAmount = (float)Health / (float)MAX_HEALTH;
        if (Health <= 0)
            Death();
        else
        {
            GetTarget(newTarget);
        }
	}
	public virtual void  Update()
	{
		if (target)
		{
			GetComponent<NavMeshAgent>().SetDestination(target.position);
			float distance = Vector3.Distance(target.position, transform.position);
			if (distance > attackDistance && Health > 0)
			{
				myAnimator.SetBool("IsWalking", true); 
				timeToAttack = attackSpeed;
			}
            else if(Health > 0)
            {
				myAnimator.SetBool("IsWalking", false);
				Attack();
			}
		}
        timeLeft -= 1;
        if (timeLeft <= 0 && Health <= 0)
        {
            Destroy(gameObject);
        }
    }
	void Attack()
	{
		timeToAttack -= Time.deltaTime;
		if (timeToAttack > 0)
			return;
		timeToAttack = attackSpeed;
		Player player = target.GetComponent<Player>();
		if (player)
		{
			myAnimator.SetTrigger("Attack");
			player.Damage(attackDamage);
		}
	}
}
