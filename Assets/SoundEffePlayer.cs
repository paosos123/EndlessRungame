using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffePlayer : MonoBehaviour
{
    public AudioSource src;

    public AudioClip Jump;
    public AudioClip Damage;
    public AudioClip Coin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundJump()
    {
        src.clip = Jump;
        src.Play();
    }

    public void DamageSound()
    {
        src.clip = Damage;
        src.Play();
    }
    public void CoinSound()
    {
        src.clip = Coin;
        src.Play();
    }
    
}
