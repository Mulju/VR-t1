using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class DistanceGrab : MonoBehaviour
{
    public InputActionReference zRotation = null;

    public float lineMaxLength = 50f;
    public bool grabbed = false;

    void Update()
    {
        float zValue = zRotation.action.ReadValue<float>();
        
        // Debuggasin, ett‰ 0.6f on k‰si n. 90 asteen kulmassa
        if (zValue > 0.6f)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, transform.forward);
            
            // Et‰isyys mille objekti j‰tet‰‰n leijumaan
            Vector3 end = transform.position + (transform.forward * lineMaxLength);

            if(Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag("Grabbable"))
            {
                hit.transform.position = end;

                // Ymm‰rt‰‰kseni t‰m‰ laittaa osutun objektin fysiikan pois p‰‰lt‰
                // Aiemmin se tippui k‰dest‰ kun kiihtyvyys kasvoi liian suureksi
                // T‰m‰ pit‰‰ myˆs ottaa pois p‰‰lt‰, jota varten on toinen skripti
                hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                grabbed = true;
            }
            else
            {
                grabbed = false;
            }
        }
        else
        {
            grabbed = false;
        }
        
    }
}
