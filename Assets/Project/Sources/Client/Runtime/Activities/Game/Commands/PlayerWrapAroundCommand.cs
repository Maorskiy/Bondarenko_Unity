using UnityEngine;

public class PlayerWrapAround : MonoBehaviour
{
    public RectTransform canvasRectTransform; 
    private RectTransform playerRectTransform; 

    void Start()
    {
        playerRectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        WrapAround();
    }

    private void WrapAround()
    {
        Vector3 playerPos = playerRectTransform.localPosition;
        Vector2 canvasSize = canvasRectTransform.sizeDelta;

        if (playerPos.x > canvasSize.x / 2) 
        {
            playerPos.x = -canvasSize.x / 2;
        }
        else if (playerPos.x < -canvasSize.x / 2) 
        {
            playerPos.x = canvasSize.x / 2;
        }

        if (playerPos.y > canvasSize.y / 2) 
        {
            playerPos.y = -canvasSize.y / 2;
        }
        else if (playerPos.y < -canvasSize.y / 2) 
        {
            playerPos.y = canvasSize.y / 2;
        }

        playerRectTransform.localPosition = playerPos;
    }
}
