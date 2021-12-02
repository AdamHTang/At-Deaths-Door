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
                        } else if (hitInfo.collider.tag == "StaminaPotion")
                        {
                            inventory.addSP();
                            Debug.Log("Add Health Potion");
                        } else  if (hitInfo.collider.tag == "Obj1")
                        {
                            inventory.addObjOne();
                        } else if (inventory.hasObjItemOne() && hitInfo.collider.tag == "Obj2")
                        {
                            inventory.addObjTwo();
                        }



                        Destroy(hitInfo.collider.transform.parent.gameObject);
                    }
                }
            }
        }
        
    }
}
