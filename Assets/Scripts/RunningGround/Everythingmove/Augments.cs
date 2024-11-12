using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Augments :  Everythingmove
{
    
    private int i = 0;
    [SerializeField]private GameObject augmentsScreen;
    [SerializeField] private List<Button>  myButton= new List<Button>(); 
    private List<int> listAugment = new List<int>{0, 1, 2, 3};
    [SerializeField] List<Sprite> listOfSprites = new List<Sprite>();
    [SerializeField] List<GameObject> listSelectUI = new List<GameObject>();
    [SerializeField] private List<TextMeshProUGUI> listTextUI = new List<TextMeshProUGUI>();
    [SerializeField] private List<string> listTextAugment = new List<string>();
    
    List<T> GetUniqueRandomElements<T>(List<T> inputList, int count)
    {
        List<T> inputListClone = new List<T>(inputList);
        Shuffle(inputListClone);
        return inputListClone.GetRange(0, count);
    }
    void Shuffle<T>(List<T> inputList)
    {
        for (int i = 0; i < inputList.Count - 1; i++)
        {
            T temp = inputList[i];
            int rand = Random.Range(i, inputList.Count);
            inputList[i] = inputList[rand];
            inputList[rand] = temp;
        }
    }
    [SerializeField]private List<int> randomList = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        randomList = GetUniqueRandomElements(listAugment, 3);
       OnClick(0,randomList[0]);
       OnClick(1,randomList[1]);
       OnClick(2,randomList[2]);
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
            augmentsScreen.SetActive(true);
            foreach (GameObject gameObject in listSelectUI)
            {
                Image imageComponent = gameObject.GetComponent<Image>();
                // Assign your new sprite to the Image component
                imageComponent.sprite = listOfSprites[randomList[i]];
                //text change
                listTextUI[i].text = listTextAugment[randomList[i]];
                if (i < listSelectUI.Count - 1)
                {
                    i++;
                }
            }
           
        }
    }

    void OnClick(int UI,int io)
    {
        myButton[UI].onClick.AddListener(() =>
        {
            switch (io)
            {
                case 0:
                    Debug.Log(1);
                    break;
                case 1:
                    
                    Debug.Log(2);
                    break;
                case 2:
                    Debug.Log(3);
                    
                    break;
                case 3:
                    Debug.Log(4);
                    
                    break;
                default:
                    // Code for values of i not explicitly handled
                    break;
            }
            augmentsScreen.SetActive(false);
            Destroy(gameObject);
        });
    }
  
}
