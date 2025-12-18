// CoinUICounter.cs
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private Text coinText;
    //[SerializeField] private Collector playerCollector;
    [SerializeField] public GameObject player;

    Collector playerCollector;
    PlayerHP playerHP;

    void Start()
    {
        playerCollector = player.GetComponent<Collector>();
        playerHP = player.GetComponent<PlayerHP>();
    }

    void Update()
    {
        int coincount = playerCollector.coinsCollected;
        float curHP = playerHP.curHP;

        if (curHP > 0)
        {
            coinText.text = "Coins: " + coincount + "     HP: " + curHP;
        } else
        {
            coinText.text = "Lol u died";
        }
    }


    // Этот метод вызывается при сборе монетки
    //private void UpdateCoinText(int coinCount)
    //{
    //    if (coinText != null)
    //    {
    //        coinText.text = $"Coins: {coinCount}";
    //    }
    //}

    //void OnDestroy()
    //{
    //    // Отписываемся от события при уничтожении объекта
    //    if (playerCollector != null)
    //    {
    //        playerCollector.coinsCollected.RemoveListener(UpdateCoinText);
    //    }
    //}
}
