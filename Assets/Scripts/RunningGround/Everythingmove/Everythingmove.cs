using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Everythingmove : MonoBehaviour
{
    private float speed = 5f; // ความเร็วในการเคลื่อนที่ของฉากหลัง
    [SerializeField]private Character character;
   
    void Update()
    {
        if (!character.IsDead())
        {
            Move();
        }

    }

    void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
