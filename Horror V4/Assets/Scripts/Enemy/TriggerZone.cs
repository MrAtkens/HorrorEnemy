using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    [SerializeField]
    private Enemy parent;

    private void OnTriggerEnter(Collider other){
        parent.CheckSight();
    }
}
