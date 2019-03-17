using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Door settings")]
    [SerializeField]
    private float openAngle;

    [SerializeField]
    private float closedAngle;

    [SerializeField]
    private float smooth;

    private bool isLocked = true, isOpen = false, isClosed = true, isKeyPickedUp = false;

    [Header("Audio settings")]
    [SerializeField]
    private AudioSource audio;

    [SerializeField]
    private AudioClip doorClosed, doorOpen, keyPickUp;

    public void Open()
    {
        if (isLocked == false)
        {
            if (isClosed == false)
            {
                isOpen = false;
                isClosed = true;
                // помещаем звук открытой двери
                audio.clip = doorOpen;
                // проигрываем звук
                audio.Play();
            }
            else
            {
                // помещаем звук закрытой двери
                audio.clip = doorClosed;
                // проигрываем звук
                audio.Play();
                isOpen = true;
                isClosed = false;
            }
        }
    }

    public void Unlock()
    {
        if (isKeyPickedUp == true)
        {
            isLocked = false;
            isKeyPickedUp = false;
        }
    }

    public void PickUp()
    {
        isKeyPickedUp = true;
        audio.clip = keyPickUp;
        audio.Play();
    }

    private void Update()
    {
        if (isOpen)
        {
            // Открыть дверь
            Quaternion targetRotationOpen = Quaternion.Euler(0, openAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotationClosed = Quaternion.Euler(0, closedAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationClosed, smooth * Time.deltaTime);
        }
    }

}
