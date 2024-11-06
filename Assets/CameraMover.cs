using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    public Vector3[] targetPosition = { new Vector3 { x = -17, y = 0, z = -10 }, 
                                new Vector3 { x = 0, y = 0, z = -10} ,
                                new Vector3 { x = 17, y = 0, z = -10} };
    public float moveSpeed = 5f;
    [SerializeField]private int i = 1; 
    private Camera mainCamera;
    
    [SerializeField] private Button buttonLeft;
    [SerializeField] private Button buttonRight;
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if(i<0)
        {
            i = 0;
        }
        else if (i > 2)
        {
            i = 2;
        }
    }
    public void MoveToTargetLeft()
    {    
        i--;
        StartCoroutine(SmoothMove(targetPosition[i]));
    }

    public void MoveToTargetRight()
    {
        i++;
        StartCoroutine(SmoothMove(targetPosition[i]));
    }
   
    
    IEnumerator SmoothMove(Vector3 targetPosition)
    {
        if (i>=0&&i<=2)
        {
            Vector3 startPosition = mainCamera.transform.position;
            float elapsedTime = 0f;
            float moveDuration = Vector3.Distance(startPosition, new Vector3(targetPosition.x, targetPosition.y, mainCamera.transform.position.z)) / moveSpeed;
           
            while (elapsedTime < moveDuration)
            {
                float t = elapsedTime / moveDuration;
                mainCamera.transform.position = Vector3.Lerp(startPosition, new Vector3(targetPosition.x, targetPosition.y, mainCamera.transform.position.z), t);
                elapsedTime += Time.deltaTime;
                buttonLeft.interactable = false;
                buttonRight.interactable = false;
                yield return null;
            }
            buttonLeft.interactable = true;
            buttonRight.interactable = true;
            mainCamera.transform.position = new Vector3(targetPosition.x, targetPosition.y, mainCamera.transform.position.z);
        }
       
    }
}
