using System.Xml.XPath;
using UnityEngine;

public class Coingen : MonoBehaviour

{
    [SerializeField] private Vector2Int GridSize;
    [SerializeField] private GameObject Coin;
    [SerializeField] private GameObject Spikes;
    [SerializeField] private GameObject Tesla;
    int coincount;

    int[,] matrix; 

    void Start()
    {
        GridSize = new Vector2Int(5, 5);
        coincount = (int)((GridSize.x + GridSize.y) / 2f - 1);
        int bufcount = coincount;

        matrix = new int[GridSize.x, GridSize.y];
        matrix[0, 0] = 1;

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

        bufcount = coincount / 2;
        while (bufcount > -1)
        {
            int xp = Random.Range(0, coincount);
            int yp = Random.Range(0, coincount);

            if (matrix[xp, yp] == 0)
            {
                matrix[xp, yp] = 1;
                bufcount--;
                SpikesGen(xp, yp);
            }
        }


        int buftesla = 1;

        while (buftesla > 0) {
            int xp = Random.Range(0, coincount);
            int yp = Random.Range(0, coincount);

            if (matrix[xp, yp] == 0)
            {
                matrix[xp, yp] = 1;
                buftesla--;
                TeslaGen(xp, yp);
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

    void SpikesGen(int a, int b)
    {

        GameObject newSpikes = Instantiate(
            Spikes,
            new Vector3(a - 0.5f, 0f, b - 0.5f),
            Quaternion.Euler(0, 0, 0)
            );

        int p = Random.Range(0, 2);

        if (p == 0) newSpikes.tag = "spike";

        else
        {
            newSpikes.tag = "toxicspike";

            foreach (Transform child in newSpikes.transform)
            {
                Renderer spikesRenderer = child.GetComponent<Renderer>();
                spikesRenderer.material.color = Color.magenta;
            }
        }

        //Collider spikcol = newSpikes.GetComponent<Collider>();
        //spikcol.isTrigger = true;
    }

    void TeslaGen(int a, int b)
    {
        GameObject newTesla = Instantiate(
            Tesla,
            new Vector3(a, -0.5f, b),
            Quaternion.Euler(0, 0, 0)
            );

        newTesla.tag = "tesla";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
