using UnityEngine;
using UnityEngine.UI;

public class TextSize : MonoBehaviour
{
    void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.offsetMax = new Vector2(-10, -10);
        rt.offsetMin = new Vector2(10, 10);

        Text tx = GetComponent<Text>();
        tx.fontSize = 40;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
