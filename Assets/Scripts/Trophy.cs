using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Trophy : MonoBehaviour 
{
    GameObject globals;
    Globals globalscript;
    [SerializeField]
    Image image;
    [SerializeField]
    public int trophyNumber;

    void Start()
    {
        globals = GameObject.Find( "Globals" );
        globalscript = globals.GetComponent<Globals>();
    }

	void Update () 
    {
	    if(globalscript.trophy[trophyNumber] == true)
        {
            image.enabled = true;
        }
        else
        {
            image.enabled = false;
        }
	}
}
