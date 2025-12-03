// CoinUICounter.cs
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private Text coinText;
    [SerializeField] private Collector playerCollector;

    void Start()
    {
        // Авто//if (coinText == null)
        //    coinText = GetComponent<Text>();

        //// Подписываемся на событие сбора монет
        //if (playerCollector != null)
        //{
        //    playerCollector.coinsCollected.AddListener(UpdateCoinText);
        //}

        //// Устанавливаем начальное значение
        //UpdateCoinText(playerCollector != null ? playerCollector.GetCoinsCount() : 0);матически находим компоненты если не назначены
        
    }

    void Update()
    {
        coinText.text = $"Coins: {playerCollector.coinsCollected}";
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
