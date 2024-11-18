using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Everythingmove : MonoBehaviour
{
    private float speed = 5f; // ความเร็วในการเคลื่อนที่ของฉากหลัง
    [SerializeField] protected Character character ;
        
    void Start()
    {
        // หา GameObject ชื่อ Player
       
    }
    void Update()
    {
      
      
    }

    protected  void Move()
    {
        if (!character.IsDead())
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    protected void FindPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");;
        // ตรวจสอบว่าพบ GameObject หรือไม่
        if (player != null)
        {
            // กำหนด Component Character ให้กับตัวแปร character
            character = player.GetComponent<Character>();
            Debug.Log("พบ GameObject ชื่อ Player");
        }
        else
        {
            Debug.LogError("ไม่พบ GameObject ชื่อ Player");
        }
    }
}
