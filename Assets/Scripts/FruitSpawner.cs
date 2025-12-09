using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public GameObject[] fruitPrefabs;

    [Header("Timing")]
    public float spawnInterval = 0.8f;

    [Header("Spawn Area")]
    public float spawnRadius = 4f;    // how far left/right from center

    [Header("Forces")]
    public float minUpForce = 12f;    // how low the launch can be
    public float maxUpForce = 18f;    // how high the launch can be
    public float horizontalForce = 3f; // side-to-side wobble

    void Start()
    {
        InvokeRepeating(nameof(SpawnFruit), 1f, spawnInterval);
    }

    void SpawnFruit()
    {
        if (fruitPrefabs == null || fruitPrefabs.Length == 0) return;

        // pick a random fruit
        int index = Random.Range(0, fruitPrefabs.Length);

        // random X position along the ground
        Vector3 spawnPos = transform.position;
        spawnPos.x += Random.Range(-spawnRadius, spawnRadius);

        // create fruit
        GameObject fruit = Instantiate(fruitPrefabs[index], spawnPos, Quaternion.identity);

        // launch it upward with some sideways variation
        Rigidbody rb = fruit.GetComponent<Rigidbody>();
        if (rb != null)
        {
            float upForce = Random.Range(minUpForce, maxUpForce);
            float sideForce = Random.Range(-horizontalForce, horizontalForce);

            Vector3 force = new Vector3(sideForce, upForce, 0f);
            rb.AddForce(force, ForceMode.Impulse);
        }
    }
}
