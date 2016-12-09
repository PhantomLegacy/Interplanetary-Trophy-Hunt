using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
	[SerializeField]
	int MAX_HEALTH = 100;
	
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
    NavMeshAgent agent;
    [SerializeField]
    Collider collision;
    int Health;
    float timeLeft;

    public virtual void Start()
    {
        Health = MAX_HEALTH;         
    }
    public void GetTarget(Transform newTarget)
    {
        target = newTarget;
        myAudioSource.Play();
    }
    public virtual void Death()
    {
        timeLeft = 600;
        agent.speed = 0;
        myAnimator.SetBool("IsWalking", false);
        myAnimator.SetTrigger("Die");
        collision.enabled = false;
    }
    public void Damage(int points, Transform newTarget)
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
	void Update()
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
