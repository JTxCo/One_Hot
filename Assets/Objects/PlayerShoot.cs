using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerShoot: MonoBehaviour
{
    [SerializeField]
    public GameObject bulletTemplate;
    public float shootPower = 100f;


    public InputActionReference trigger;
        // Start is called before the first frame update
    void Start()
    {
        trigger.action.performed += Shoot;   
    }
 
    // Update is called once per frame
    void Shoot(InputAction.CallbackContext __)
    {   
        GameObject newBullet = Instantiate(bulletTemplate, transform.position, transform.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootPower);
        
    }
}
