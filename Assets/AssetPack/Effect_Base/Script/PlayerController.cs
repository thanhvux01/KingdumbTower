using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;



public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    float horizontalInput;
    float verticalInput;
    float speed = 0.1f;
    [SerializeField] GameObject fireBall;   
    [SerializeField] ParticleSystem muzzle;

    [Range(1f,100f)]
    public float spellPower = 50f;

    void Start()
    {
        
    }
    void Update() {

        SpellCast();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
       SimpleControl();
    }

  

    private void SimpleControl()
    {
        horizontalInput = Input.GetAxis("Horizontal") * speed;
        verticalInput = Input.GetAxis("Vertical") * speed;
     

        if (horizontalInput != 0)
        {

            transform.position = new Vector3(transform.position.x + horizontalInput, transform.position.y, transform.position.z);

        }
        if (verticalInput != 0)
        {

            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + verticalInput);
        }
    }

    private void SpellCast () {
         Vector3 spellPosition = transform.position + new Vector3(0,0,1);
         if (Input.GetMouseButtonUp(0) ) {
               TriggerMuzzle();
               GameObject spellInstance = Instantiate(fireBall,spellPosition,Quaternion.identity);
               Rigidbody spellVelocity = spellInstance.GetComponent<Rigidbody>();
               spellVelocity.AddForce(spellInstance.transform.forward * spellPower,ForceMode.Impulse);
         };
    }

    private void TriggerMuzzle() {
        
     muzzle.Play();
     
       
    }
}
