using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeSys : MonoBehaviour
{
     [SerializeField] private  GameObject HealthMaxUp;
    [SerializeField] private GameObject HealthMaxUpUI;
    
    [SerializeField] private Button HealthMaxUpUIButton;
    public TMP_Text[] upgradeText;
    private int LvHealthMaxUp=0;
    
    public Sprite[] sprites;
    [SerializeField] private  GameObject MeatMaxUp;
    [SerializeField] private GameObject MeatMaxUpUI;
    [SerializeField] private Button MeatUIButton;
    private int LvMeatMaxUp=0;
    
    
    [SerializeField] private List<GameObject> RockMaxUp;
    [SerializeField] private GameObject RockMaxUpUI;
    private int HealthMaxUpneed = 5;
    private int MeatMaxUpneed = 5;
    static  int  po,oo =0;
    // Start is called before the first frame update
    void Start()
    {
        CoinSystem.totalCoin = 20;
        if (oo == 1)
        {
            ChangeSprite(MeatMaxUp,sprites[1]);
        }

        if (po == 1)
        {
            ChangeSprite(HealthMaxUp,sprites[0]);
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        ifUpgradeNoteg(HealthMaxUpUIButton, HealthMaxUpneed);
        ifUpgradeNoteg( MeatUIButton,  MeatMaxUpneed );
       if (Input.touchCount > 0)
       {
           Touch t = Input.GetTouch(0);

           Vector2 touchpos = Camera.main.ScreenToWorldPoint(t.position);

           // Check if the touch position overlaps the target GameObject's collider
           if (Physics2D.OverlapPoint(touchpos) == HealthMaxUp.GetComponent<Collider2D>())
           {
                HealthMaxUpUI.SetActive(true);
           }
           else
           {
               // Optional: Handle touches on other GameObjects (if desired)
           }
           if (Physics2D.OverlapPoint(touchpos) == MeatMaxUp.GetComponent<Collider2D>())
           {
              MeatMaxUpUI.SetActive(true);
           }
           if (Physics2D.OverlapPoint(touchpos) == RockMaxUp[0].GetComponent<Collider2D>())
           {
               RockMaxUpUI.SetActive(true);
           }
           if (Physics2D.OverlapPoint(touchpos) == RockMaxUp[1].GetComponent<Collider2D>())
           {
               RockMaxUpUI.SetActive(true);
           }
           if (Physics2D.OverlapPoint(touchpos) == RockMaxUp[2].GetComponent<Collider2D>())
           {
               RockMaxUpUI.SetActive(true);
           }
           if (Physics2D.OverlapPoint(touchpos) == RockMaxUp[3].GetComponent<Collider2D>())
           {
               RockMaxUpUI.SetActive(true);
           }

           
           
       }
       /* if (Input.touchCount > 0)
      {
          Touch t = Input.GetTouch(0);

          Vector2 touchpos = Camera.main.ScreenToWorldPoint(t.position);

          // Use Physics2D.OverlapPoint to check for any collider at the touch position
          Collider2D collider = Physics2D.OverlapPoint(touchpos);

          if (collider != null)
          {
              // Check if the touched GameObject has the specific name "First"
              if (collider.gameObject.name == "First")
              {
                  // If the name is "First", log a specific message
                  Debug.Log("You touched the GameObject named 'First'");
              }
              else
              {
                  // Otherwise, log a generic message with the collider's name
                  Debug.Log("Touched GameObject: " + collider.gameObject.name);
              }
          }
      }*/
    }

    public  void ifUpgradeNoteg(Button bu,int i)
    {
        if (CoinSystem.totalCoin >= i )
        {
           bu.interactable = true;
        }
        else if (CoinSystem.totalCoin < i )
        {
            bu.interactable = false;
            
        }
    }
    public void CloseHealthMaxUpUI()
    {
        HealthMaxUpUI.SetActive(false);
    }
    public void CloseMeatMaxUpUI()
    {
        MeatMaxUpUI.SetActive(false);
    }
    public void CloseRockMaxUpUI()
    {
        RockMaxUpUI.SetActive(false);
    }
    public void UpgradeHealthMaxUpUI()
    {
        LvHealthMaxUp++;
        CoinSystem.totalCoin -= 5+Character.upgradeHealth;
        HealthMaxUpneed += 10;
        Character.upgradeHealth += 10;
        ChangeSprite(HealthMaxUp,sprites[0]);
        po = 1;
        upgradeText[0].text = $"Lv {LvHealthMaxUp}";
        upgradeText[1].text = $"Need {5+Character.upgradeHealth} Coins";
        upgradeText[2].text = $"MaxHealth {100+Character.upgradeHealth} to {110+Character.upgradeHealth} ";
    }
    public void UpgradeMeatMaxUpUI()
    {
        LvMeatMaxUp++;
        CoinSystem.totalCoin -= 5+Healthfillingpot.HealthfillingpotIncrese; 
        MeatMaxUpneed += 10;
        Healthfillingpot.HealthfillingpotIncrese += 10;
        ChangeSprite(MeatMaxUp,sprites[1]);
        oo = 1;
        upgradeText[3].text = $"Lv {LvMeatMaxUp}";
        upgradeText[4].text = $"Need {5+Healthfillingpot.HealthfillingpotIncrese} Coins";
        upgradeText[5].text = $"MaxHealth {20+Healthfillingpot.HealthfillingpotIncrese} to {30+Healthfillingpot.HealthfillingpotIncrese} ";
    }
    public void ChangeSprite(GameObject gameObject,Sprite newSprite)
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = newSprite;
        }
        else
        {
           
        }
    }
}
