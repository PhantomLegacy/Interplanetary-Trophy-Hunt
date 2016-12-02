using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GunControl : MonoBehaviour {

	[SerializeField]
	Animator myAnimator;
    [SerializeField]
	AudioSource myAudiosource;
    [SerializeField]
	GameObject PlayerFPCamera;
    [SerializeField]
    int attackDamage;

    GameObject Globals;

    void Start()
    {
        Globals = GameObject.Find("Globals");
    }

    void Update () {
		if (CrossPlatformInputManager.GetButtonDown("Fire1"))
		{
			myAnimator.SetTrigger("Shoot");
			myAudiosource.Play();
            Globals.GetComponent<Globals>().bullets -= 1;

			RaycastHit hit;
			if (Physics.Raycast(PlayerFPCamera.transform.position, 
				PlayerFPCamera.transform.forward, out hit))
			{
				GameObject target = hit.collider.transform.gameObject;
				Enemy enemy = target.GetComponent<Enemy>();
				if (enemy)
					enemy.Damage(attackDamage,PlayerFPCamera.transform.parent);
			}
		}
	}
}
