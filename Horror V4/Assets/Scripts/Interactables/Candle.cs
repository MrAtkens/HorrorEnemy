using UnityEngine;

public class Candle : MonoBehaviour
{
    [SerializeField]
    private Light candle;

    public void SetActive(){
        var isActive = candle.enabled;
        candle.enabled = !isActive;
    }
}
