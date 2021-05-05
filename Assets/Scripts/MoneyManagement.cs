using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyManagement : MonoBehaviour
{
    public int Balance;
    public int DollarCost;
    public int CoinCost;
    public int DamageCost;
    public TextMeshProUGUI Display;
    public static MoneyManagement Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;   
    }

    // Update is called once per frame
    void Update()
    {
        Display.text = Balance.ToString();
    }
}
