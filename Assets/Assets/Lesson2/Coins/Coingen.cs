using System.Xml.XPath;
using UnityEngine;

public class Coingen : MonoBehaviour

{
    [SerializeField] private Vector2Int GridSize;
    [SerializeField] private GameObject Coin;
    int coincount;

    int[,] matrix;

    void Start()
    {
        GridSize = new Vector2Int(5, 5);
        coincount = (int)((GridSize.x + GridSize.y) / 2f - 1);
        int bufcount = coincount;

        matrix = new int[GridSize.x, GridSize.y];

        //for (int i = 0; i < coincount + 1; i++) {
        //    int xp = Random.Range(0, coincount);
        //    int yp = Random.Range(0, coincount);

        //    CoinGen(0, coincount); 
        //}

        while (bufcount > -1)
        {
            int xp = Random.Range(0, coincount);
            int yp = Random.Range(0, coincount);

            if (matrix[xp, yp] == 0)
            {
                matrix[xp, yp] = 1;
                bufcount--;
                CoinGen(xp, yp);
            }
        }

    }


    void CoinGen(int a, int b)
    {

        GameObject newCoin = Instantiate(
            Coin, 
            new Vector3(a, 0.5f, b), 
            Quaternion.Euler(0, Random.Range(0, 180), 90)
            );

        Collider coincol = newCoin.GetComponent<Collider>();
        coincol.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
