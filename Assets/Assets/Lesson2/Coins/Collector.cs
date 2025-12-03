using UnityEngine;

public class Collector : MonoBehaviour
{
    public int coinsCollected = 0;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("coin"))
        {
            coinsCollected++;

            //Debug.Log($"Монеток собрано: {coinsCollected}");

            Destroy(other.gameObject);
        }
    }

    public int GetCoinsCount()
    {
        return coinsCollected;
    }
}
