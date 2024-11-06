using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Everythingmove : MonoBehaviour
{
    private float speed = 5f; // ความเร็วในการเคลื่อนที่ของฉากหลัง
    [SerializeField] protected Character character;
   
    void Update()
    {
       Move();
    }

    protected  void Move()
    {
        if (!character.IsDead())
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
       
    }
}
