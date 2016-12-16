using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyBoss : Enemy
{
    [SerializeField]
    int trophy;
    [SerializeField]
    int chargeTrigger;
    [SerializeField]
    int chargeSpeed;
    int chargeTime = 0;
    int chargeCount = 0;
    GameObject Globals;
    public override void Start()
    {
        Globals = GameObject.Find("Globals");
        base.Start();
    }

    public override void Update()
    {
        if (chargeCount == chargeTrigger)
        {
            agent.speed = chargeSpeed;
            chargeCount = 0;
            chargeTime = 5 * 60;
        }
        if (chargeTime > 0)
        {
            chargeTime -= 1;
            if (chargeTime == 0)
            {
                agent.speed = defaultSpeed;
            }
        }
        base.Update();
    }

    public override void Damage(int points, Transform newTarget)
    {
        chargeCount += 1;
        base.Damage(points, newTarget);
    }

    public override void Death()
    {
        Globals.GetComponent<Globals>().trophy[trophy] = true;
        Globals.GetComponent<Globals>().money += 100*trophy;
        Debug.Log("You now have Trophy " + trophy);
        base.Death();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("TrophyRoom");
    }
	
}
