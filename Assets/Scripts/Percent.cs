using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderPercentLabel : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI label;

    void Update()
    {
        if (slider && label)
        {
            int pct = Mathf.RoundToInt(slider.value * 100f);
            label.text = pct + "%";
        }
    }
}
