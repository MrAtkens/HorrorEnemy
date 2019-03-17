using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashLight : MonoBehaviour
{
    public static bool isFlashLightOn;
    [SerializeField]
    private Light flashLight;
    private bool isEnabled = true;

    [SerializeField]
    private Image indicator;
    private float maxBatteryLife;
    private float curBatteryLife;

    [SerializeField]
    private float lightDrain = 0.01f;
    
    private void Start(){
        maxBatteryLife = flashLight.intensity;
        curBatteryLife = maxBatteryLife;
        isFlashLightOn = true;
    }

    private void Update(){
        if(isEnabled == true){
            if(curBatteryLife > 0){
                curBatteryLife -= lightDrain * Time.deltaTime;
                var indicatorWidth = curBatteryLife / maxBatteryLife;

                flashLight.intensity = curBatteryLife;

                var indicatorScale = indicator.transform.localScale;
                indicator.transform.localScale = new Vector3(indicatorWidth, 
                    indicatorScale.y, 
                    indicatorScale.z);
            }else{
                // выключаем фонарик
                curBatteryLife = 0;
                isEnabled = false;
                flashLight.enabled = false;
                isFlashLightOn = false;
            }    
        }

        if(Input.GetKeyDown(KeyCode.F) && curBatteryLife > 0){
            // если фонарик включен - выключить
            isEnabled = !isEnabled;
            flashLight.enabled = isEnabled;
            isFlashLightOn = true;
        }
    }

    public void AddEnergy(float value){
        curBatteryLife += value;
    }
}
