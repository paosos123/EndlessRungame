using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class MapGenSystem : MonoBehaviour
{
    [SerializeField]List<GameObject> listMap1 = new List<GameObject>();
    [SerializeField]private List<GameObject> randomList = new List<GameObject>();
    public float spawnInterval = 4.5f;
    float timer = 0f;
    List<T> GetRandomElements<T>(List<T> inputList, int count)
    {
        List<T> outputList = new List<T>();
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(0, inputList.Count);
            outputList.Add(inputList[index]);
        }
        return outputList;
    }
    Vector2 position = new Vector2(0, 0);

    [SerializeField]private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        randomList = GetRandomElements(listMap1, 1);
       
        Instantiate(randomList[0], position, Quaternion.identity);
        /* for (int i = 0; i < 15; i++)
         {
             
             if (i>=0&&i<=2&&i>=4&&i<=14)
             {
                 //Instantiate(randomList[0])
             }
             else if (i == 3)
             {
                 //Instantiate()
             }
             else if(i == 15)
             {
                 //Instantiate()
             }
         }*/
    }
    

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if (timer >= spawnInterval)
        {
            if (i !=3 && i !=15)
            {
                Instantiate(randomList[0], position, Quaternion.identity);
                randomList = GetRandomElements(listMap1, 1);
            }
            else if (i == 3)
            {
                Instantiate(randomList[0], position, Quaternion.identity);
            }
            else if(i == 15)
            {
                Instantiate(randomList[0], position, Quaternion.identity);
                i = 0;
            }
            i++;
            timer = 0f;
        }

        
    }
}
