using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InteractManager : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private float interactDistance;

    [SerializeField]
    private Transform cameraPosition;

    [SerializeField]
    private FlashLight flashLight;

    [SerializeField]
    private Image interactImage;

     [SerializeField]
    private Door door;
    private void Start(){
        interactImage.gameObject.SetActive(false);
    }

       private void Update(){
        // origin - откуда исходит луч, direction - направление
        Ray ray = new Ray(cameraPosition.position, cameraPosition.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, interactDistance, layerMask)){
            interactImage.gameObject.SetActive(true);            
            // если нажата клавиша E
            if(Input.GetKeyDown(KeyCode.E)){
                // если попали в объект с tag == Battery
                if(hit.collider.tag == "Battery"){
                    // добавить энергии
                    flashLight.AddEnergy(1.5f);
                    // уничтожаем объект
                    Destroy(hit.collider.gameObject);
                }else if(hit.collider.tag == "Candle"){
                    // получаем скрипт Candle у свечи
                    var candle  = hit.collider.GetComponent<Candle>();
                    candle.SetActive();
                }else if(hit.collider.tag == "Door"){                    
                    door.Unlock();
                    door.Open();
                }
                else if(hit.collider.tag == "Key"){                    
                    door.PickUp();
                    Destroy(hit.collider.gameObject);
                }
                else if(hit.collider.tag == "Win"){                    
                    SceneManager.LoadScene("Menu");
                }      
            }                        
        }else{
            interactImage.gameObject.SetActive(false);
        }         
    }
}
