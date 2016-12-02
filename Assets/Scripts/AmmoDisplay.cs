using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoDisplay : MonoBehaviour
{ 
    public Text ammoText;
    public GameObject bank;

    void Start()
    {
        bank = GameObject.Find("Globals");
    }

    void Update()
    {
        ammoText.text = "Ammo: " + bank.GetComponent<Globals>().bullets.ToString();
    }
}
