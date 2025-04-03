using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float screenWidthInUnits = 16;
    [SerializeField] private float minX = 1f;
    [SerializeField] private float maxX = 15f;

    void Start()
    {
    }

    void Update()
    {
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits, minX, maxX);
        transform.position = paddlePos;
    }
}