using UnityEngine;

public class PanelSize : MonoBehaviour
{
    void Start()
    {
        RectTransform rt = GetComponent<RectTransform>();
        rt.offsetMax = new Vector2(-480, -320);
        rt.offsetMin = new Vector2(10, 10);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
