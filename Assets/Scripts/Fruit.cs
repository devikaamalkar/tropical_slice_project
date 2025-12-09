using UnityEngine;

public class Fruit : MonoBehaviour
{
    [HideInInspector] public bool sliced = false;
    public float missY = -4.5f;   // slightly below your plane

    void Update()
    {
        // If fruit falls below missY and wasn't sliced, count as a miss
        if (!sliced && transform.position.y < missY)
        {
            if (ScoreManager.Instance != null)
                ScoreManager.Instance.AddMiss();

            Destroy(gameObject);
        }
    }

    public void Slice()
    {
        if (sliced) return;
        sliced = true;

        if (ScoreManager.Instance != null)
            ScoreManager.Instance.AddScore(1);

        Destroy(gameObject);
    }
}

