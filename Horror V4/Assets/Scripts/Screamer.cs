using UnityEngine;

public class Screamer : MonoBehaviour
{
    [SerializeField]
    private Transform root;
    [SerializeField]
    private Transform screamer;
    [SerializeField]
    private AudioSource audio;

    private void Start(){
        // disable screamer by default
        screamer.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            screamer.gameObject.SetActive(true);
            audio.Play();

            // start Destroy method in 4 seconds
            Invoke("Destroy", 3f);
        }
    }

    private void Destroy(){
        Destroy(root.gameObject);
    }
}
