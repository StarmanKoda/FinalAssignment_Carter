using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MoneyManagement : MonoBehaviour
{
    public int Balance;
    public int DollarCost;
    public int CoinCost;
    public int DamageCost;
    public TextMeshProUGUI Display;
    public string leveltoload;
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

        if (Balance <= 0)
        {
            SceneManager.LoadScene(leveltoload);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
