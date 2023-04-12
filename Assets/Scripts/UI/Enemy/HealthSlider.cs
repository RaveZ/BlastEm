using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    public Image healthbar;
  

    public void reduceHealth(float Amount)
    {
        healthbar.fillAmount -= Amount;
    }
}
