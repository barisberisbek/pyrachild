using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    float MouseSensitivty = 200f;

    public Transform CharacterBody;

    float xRotation = 0f;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (PauseMenu.Instance.gameIsPaused == false && Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if(PauseMenu.Instance.gameIsPaused == true)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        float MouseX = Input.GetAxis("Mouse X") * MouseSensitivty * Time.deltaTime; // Mevcut framerate g�re ba��ms�z olarak d�nd���m�zden emin olmak istiyoruz
        float MouseY = Input.GetAxis("Mouse Y") * MouseSensitivty * Time.deltaTime;

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // D�nmeyi s�n�rland�rd�m

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Bu, karakterin �ne veya arkaya do�ru d�nmesini sa�lar

        CharacterBody.Rotate(Vector3.up * MouseX); //Karakterin yatay (y ekseni etraf�nda) d�n��� kontrol etmek i�in kullan�l�r
    }
}
