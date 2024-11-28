using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Everythingmove : MonoBehaviour
{
    private float speed = 5f; // ความเร็วในการเคลื่อนที่ของฉากหลัง
    [SerializeField] protected Character character ;
    [SerializeField] protected SoundEffePlayer soundEffePlayer ;
    void Start()
    {
        // หา GameObject ชื่อ Player
       
    }
    void Update()
    {
      
      
    }

    protected  void Move()
    {
        
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        
    }

    protected void FindPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");;
        // ตรวจสอบว่าพบ GameObject หรือไม่
        if (player != null)
        {
            // กำหนด Component Character ให้กับตัวแปร character
            character = player.GetComponent<Character>();
           
        }
        else
        {
            
        }
        GameObject sound = GameObject.FindGameObjectWithTag("Sound");;
        // ตรวจสอบว่าพบ GameObject หรือไม่
        if (sound != null)
        {
            // กำหนด Component Character ให้กับตัวแปร character
            soundEffePlayer = sound.GetComponent<SoundEffePlayer>();
           
        }
        else
        {
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Dead"))
        {
            Destroy(gameObject);
        }
        
    }
}
