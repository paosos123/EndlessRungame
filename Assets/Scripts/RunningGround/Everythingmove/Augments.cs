using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Augments :  Everythingmove
{
    private int i = 0;
    [SerializeField]private GameObject augmentsScreen;
    private List<int> listAugment = new List<int>{0, 1, 2, 3};
    [SerializeField] List<Sprite> listOfSprites = new List<Sprite>();
    [SerializeField] List<GameObject> listSelectUI = new List<GameObject>();
    [SerializeField] private List<TextMeshProUGUI> listText = new List<TextMeshProUGUI>();
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
    private List<int> randomList = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
         randomList = GetUniqueRandomElements(listAugment, 3);
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
            gameObject.SetActive(false);
            foreach (GameObject gameObject in listSelectUI)
            {
                Image imageComponent = gameObject.GetComponent<Image>();
                // Assign your new sprite to the Image component
                imageComponent.sprite = listOfSprites[randomList[i]];
                i++;
            }
        }
    }
    public void disableAugmentScreen(GameObject augmentsScreen)
    {
        augmentsScreen.SetActive(false);
    }
   
}
