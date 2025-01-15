using UnityEngine;

public class SpriteUPDOWN : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveHeight = 3f;
    public int movementType = 0;

    private Vector2 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = transform.position.y;
        if (movementType == 0)
        {
            newY = Mathf.Sin(Time.time * moveSpeed) * moveHeight;
        }
        else if (movementType == 1)
        {
            newY = Mathf.Abs(Mathf.Sin(Time.time * moveSpeed) * moveHeight);
        }
        else if (movementType == 2)
        {
            newY = Mathf.Abs(Mathf.Sin(Time.time * moveSpeed) * moveHeight) * -1;
        }

        transform.position = new Vector3(startPosition.x, startPosition.y + newY);
    }
}
