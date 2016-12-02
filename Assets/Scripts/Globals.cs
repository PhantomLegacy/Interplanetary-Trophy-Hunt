using UnityEngine;
using System.Collections;

public class Globals : MonoBehaviour {
    
    public int money = 0;
    public int bullets = 100;
    public bool[] trophy = new bool[3];


    void Awake()
    {
        DontDestroyOnLoad( transform.gameObject );
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            money += 10;
            Debug.Log( "Money added, balance = " + money );
        }
        if( Input.GetKeyDown( KeyCode.KeypadMinus ) )
        {
            money -= 10;
            Debug.Log( "Money removed, balance = " + money );
        }

        if( Input.GetKeyDown( KeyCode.Keypad1 ) )
        {
            if( trophy[0] == false )
            {
                trophy[0] = true;
                Debug.Log( "You now have Trophy 3" );
            }
            else
            {
                trophy[0] = false;
                Debug.Log( "You no longer have Trophy 3" );
            }
        }
        if( Input.GetKeyDown( KeyCode.Keypad2 ) )
        {
            if(trophy[1] == false)
            {
                trophy[1] = true;
                Debug.Log( "You now have Trophy 1" );
            }
            else
            {
                trophy[1] = false;
                Debug.Log( "You no longer have Trophy 1" );
            }
        }
        if( Input.GetKeyDown( KeyCode.Keypad3 ) )
        {
            if( trophy[2] == false )
            {
                trophy[2] = true;
                Debug.Log( "You now have Trophy 2" );
            }
            else
            {
                trophy[2] = false;
                Debug.Log( "You no longer have Trophy 2" );
            }
        }
    }
}
