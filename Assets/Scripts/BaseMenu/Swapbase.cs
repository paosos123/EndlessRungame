using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Swapbase : MonoBehaviour
{
    
    public Button moveButton;
    public Vector2 targetPosition;
    public float moveSpeed = 5f;

    static private Camera mainCamera= Camera.main;
    
    void Start()
    {
        mainCamera = Camera.main;
        moveButton.onClick.AddListener(MoveToTarget);
        
    }

    void update()
    {
        
    }
    void MoveToTarget()
    {
        //StartCoroutine(SmoothMove());
    }

    IEnumerator SmoothMove(Vector3 targetPosition)
    {
        Vector3 startPosition = mainCamera.transform.position;

        float elapsedTime = 0f;
        float moveDuration = Vector3.Distance(startPosition, new Vector3(targetPosition.x, targetPosition.y, mainCamera.transform.position.z)) / moveSpeed;

        while (elapsedTime < moveDuration)
        {
            float t = elapsedTime / moveDuration;
            mainCamera.transform.position = Vector3.Lerp(startPosition, new Vector3(targetPosition.x, targetPosition.y, mainCamera.transform.position.z), t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        mainCamera.transform.position = new Vector3(targetPosition.x, targetPosition.y, mainCamera.transform.position.z);
    }
}
