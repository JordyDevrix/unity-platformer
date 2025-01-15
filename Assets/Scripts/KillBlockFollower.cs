using UnityEngine;

public class KillBlockFollow : MonoBehaviour
{
    public Transform Camera;
    
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera != null)
        {
            transform.position = new Vector2(Camera.position.x, transform.position.y);
        }
    }
}
