using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;

    public TMP_Text coinText;

    public int currentCoin = 0;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentCoin = 0;
        coinText.text = currentCoin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseCoins()
    {
        currentCoin += 1;
        coinText.text = currentCoin.ToString();
    }
}
