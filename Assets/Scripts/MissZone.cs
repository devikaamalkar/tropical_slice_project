using UnityEngine;

public class MissZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Fruit")) return;

        Fruit fruit = other.GetComponent<Fruit>();
        if (fruit != null && !fruit.sliced)
        {
            ScoreManager.Instance.AddMiss();
        }

        Destroy(other.gameObject);
    }
}

