using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPerfab : Everythingmove
{
    // Start is called before the first frame update
    void Start()
    {
        FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CoinSystem.totalCoin += 1;
            CoinCounter.instance.IncreaseCoins();
            Destroy(gameObject);
        }
        
    }
}
