using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiveSlider : MonoBehaviour
{
    public Slider slider;
    public GameObject display;
    Color colorArr[] = new Color[] { Color.green, Color.yellow, Color.cyan, Color.magenta, Color.red};
    // Start is called before the first frame update
    void Start()
    {
        slider.onValueChanged.AddListener(UpdateDisplay);
    }

    void UpdateDisplay()
    {
        Text displayText = display.GetComponent<Text>();
        displayText.text = slider.value;
        Image displayImage = display.GetComponent<Image>();
        displayImage.color = colorArr[slider.value];
    }

}
