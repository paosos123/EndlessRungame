using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;

    public TMP_Text coinCurrentText;
    public TMP_Text coinAllText;
    public static int currentCoin = 0;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentCoin = 0;
        coinCurrentText.text = currentCoin.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            CoinSystem.totalCoin++;
        }
        coinAllText.text = CoinSystem.totalCoin.ToString();
    }

    public void IncreaseCoins()
    {
        currentCoin += 1;
        coinCurrentText.text = currentCoin.ToString();
    }
}
