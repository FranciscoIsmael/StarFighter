using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Transform target;

    public float Speed = 20f;
    public float xRange = 20;
    public float yRange = 40;
    private float horizontalInput;
    private float verticalInput;
    /*private float rotateInput;*/
    public float rotateSpeed = 30;
    public bool isDead = false;
    Vector3 currentOffset;
    
    private Vector3 offset = new Vector3(0,0,5);
    // Start is called before the first frame update
    void Start()
    {
        
        currentOffset = transform.position;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {

        //hacer que la nave apunte al raton

        //pillar la entrada de la posicion del raton
        Vector3 MouseScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        Vector3 MouseWorldPoint = Camera.main.ScreenToWorldPoint(MouseScreenPoint);
        //hacemos que apunte al raton pero con el eje z en 0 porque es donde esta nuestra nave, si quitamos esta linea de codigo apunta a la z de la camara, como resultado la nave apunta para arriba
        MouseWorldPoint.z = 0;

        //target = MouseWorldPoint;

        
        //hace el vector que hay entre la posicion del raton y la posicion de la nave
        Vector3 relativePos = MouseWorldPoint - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.back);
        //rota la nave para que mire al raton
        //transform.rotation = rotation;
        gameObject.transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
        
        




        //mover nave
       
        if(isDead == false)
        {
            //movimiento con las telcas
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Speed * Time.deltaTime * horizontalInput);
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * Speed * Time.deltaTime * verticalInput);

            //rotar con teclas
            /*
            if (Input.GetKey(KeyCode.Keypad6) || Input.GetKey(KeyCode.L))
            {
                transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.Keypad4) || Input.GetKey(KeyCode.J))
            {
                transform.Rotate(Vector3.up * -rotateSpeed * Time.deltaTime);
            }*/

            //limitar un rango para no salirse de la pantalla
            if (transform.position.x < currentOffset.x - xRange)
            {
                transform.position = new Vector3(currentOffset.x - xRange, transform.position.y, transform.position.z);
            }
            if (transform.position.x > currentOffset.x + xRange)
            {
                transform.position = new Vector3(currentOffset.x + xRange, transform.position.y, transform.position.z);
            }

            if (transform.position.y < currentOffset.y - yRange)
            {
                transform.position = new Vector3(transform.position.x, currentOffset.y - yRange, transform.position.z);
            }
            if (transform.position.y > currentOffset.y + yRange)
            {
                transform.position = new Vector3(transform.position.x, currentOffset.y + yRange, transform.position.z);
            }
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject.CompareTag("playerBeam")))
        {
            isDead = true;
            Debug.Log("Has perdido");
        }


    }

}
