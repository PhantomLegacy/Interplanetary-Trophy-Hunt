using UnityEngine;
using System.Collections;

public class EnemyBoss : Enemy
{
    [SerializeField]
    int trophy;
    GameObject Globals;
    public override void Start()
    {
        Globals = GameObject.Find("Globals");
        base.Start();
    }

    public override void Death()
    {
        Globals.GetComponent<Globals>().trophy[trophy] = true;
        Debug.Log("You now have Trophy " + trophy);
        base.Death();
    }
	
}
