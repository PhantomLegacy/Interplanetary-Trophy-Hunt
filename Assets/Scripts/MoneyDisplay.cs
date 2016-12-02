using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyDisplay : MonoBehaviour
{
    public Text moneyText;
    public GameObject bank;

    void Start()
    {
        bank = GameObject.Find("Globals");
    }

    void Update()
    {
        moneyText.text = "$" + bank.GetComponent<Globals>().money.ToString();
    }
}
