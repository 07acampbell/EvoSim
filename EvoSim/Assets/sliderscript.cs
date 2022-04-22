using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sliderscript : MonoBehaviour
{
    public Slider slider;
    public int slidertext;
    public FoodSpawnScript spawnscript;

    // Update is called once per frame
    void Update()
    {
        slider.onValueChanged.AddListener((v) => spawnscript.spawn((int)slider.value));
    }
}
