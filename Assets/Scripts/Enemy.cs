using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
	private const int MAX_HEALTH = 100;
	[SerializeField]
	int Health = MAX_HEALTH;
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

    public void Damage(int points, Transform newTarget)
	{
		Health -= points;
		ImgHealth.fillAmount = (float)Health / (float)MAX_HEALTH;
		if (Health <= 0)
			Destroy(gameObject);
		else{
			target = newTarget;
			myAudioSource.Play();
		}
	}
	void Update()
	{
		if (target)
		{
			GetComponent<NavMeshAgent>().SetDestination(target.position);
			float distance = Vector3.Distance(target.position, transform.position);
			if (distance > 2.5f)
			{
				myAnimator.SetBool("IsWalking", true); 
				timeToAttack = attackSpeed;
			}else{
				myAnimator.SetBool("IsWalking", false);
				Attack();
			}
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
