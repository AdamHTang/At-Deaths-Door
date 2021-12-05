/*
 * Created By: Adam Tang
 * Date Created: 11/25/2021
 * Date Modified: 11/25/2021
 * Description: Selects objects with available interactions.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{

    public new Camera camera;
    public GameObject player;
    public Inventory inventory;


    void Awake()
    {
        inventory = player.GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.GetComponent<Interact>()!=null)
                {
                    Vector3 distanceToTarget = hitInfo.point - transform.position;

                    if (Vector3.Magnitude(distanceToTarget) <= 2)
                    {

                        if (hitInfo.collider.tag == "HealthPotion")
                        {
                            inventory.addHP();
                            Debug.Log("Add Health Potion");
                            Destroy(hitInfo.collider.transform.parent.gameObject);
                        }
                        else if (hitInfo.collider.tag == "StaminaPotion")
                        {
                            inventory.addSP();
                            Debug.Log("Add Health Potion");
                            Destroy(hitInfo.collider.transform.parent.gameObject);
                        }
                        else if (hitInfo.collider.tag == "Key")
                        {
                            inventory.addKey();
                            Debug.Log("Add Key");
                            Destroy(hitInfo.collider.transform.parent.gameObject);
                        } else if (hitInfo.collider.tag == "Lock" && (inventory.getKeys() > 0))
                        {
                            inventory.useKey();
                            Debug.Log("Removed Lock");
                            Destroy(hitInfo.collider.transform.parent.gameObject);
                        }

                        
                    }
                }
            }
        }
        
    }
}
