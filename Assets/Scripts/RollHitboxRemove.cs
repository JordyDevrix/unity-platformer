using UnityEngine;

public class RollHitboxRemove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private BoxCollider2D BoxCollider2D;
    private float rollTimer = 0f;

    void Start()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rollTimer > 0f)
        {
            rollTimer -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rollTimer = 0.2f;
            BoxCollider2D.enabled = false;
        }
        else if (rollTimer <= 0)
        {
            BoxCollider2D.enabled = true;
        }
    }
}
