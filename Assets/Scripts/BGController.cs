using UnityEngine;

public class BGController : MonoBehaviour
{
    public GameObject Camera;
    public float ParallaxEffect;

    private float StartPos, Length;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartPos = transform.position.x;
        Length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Camera.transform.position.x * ParallaxEffect;
        float movement = Camera.transform.position.x * (1 - ParallaxEffect);

        transform.position = new Vector3(StartPos + distance, transform.position.y, transform.position.z);

        if (movement > StartPos + Length)
        {
            StartPos += Length;
        }
        else if (movement < StartPos - Length)
        {
            StartPos -= Length;
        }
    }
}
