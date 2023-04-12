using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthUI : MonoBehaviour
{
    public Image HealthSlider;


    public void changeHealth(float Amount)
    {
        if(HealthSlider.fillAmount > 1.0f)
        {
            HealthSlider.fillAmount = 1.0f;
        }
        HealthSlider.fillAmount += Amount;
    }
    
}
