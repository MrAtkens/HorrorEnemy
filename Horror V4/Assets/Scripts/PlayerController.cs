using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController firstPerson;

    public bool isAlive=true;

   public void KillPlayer(){
       firstPerson.enabled=false;
       isAlive=false;
   }
}
