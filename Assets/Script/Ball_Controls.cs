using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ball_Controls : MonoBehaviour
{
    [SerializeField] private float Gravity;

    private Rigidbody myRB ;
    //private Vector3 lookDirection ; //la direction dans laquelle la camera est orientée

    [SerializeField] float Force;
    [SerializeField] float Force1;

    private bool IsMove = false; //savoir si la balle est à l’arrêt ou pas
    private bool IsPressed = false; //savoir si on a appuyer
    private Controls controls;
    private Vector2 a; // le point "a" correspond a la premiere postion de ma souris chaque frame
    private Vector2 Resolution; //correspond a la variable qui va contenir la resolution de l'ecran
    
    
 

    private void OnEnable()
    {
        controls = new Controls();
        controls.Enable();

        controls.Ball.Aim.performed += OnAimPerformed; //position souris
        controls.Ball.Aim2.performed += OnAim2Performed;//delta de la souris pour la cam
        controls.Ball.Shoot.performed += OnShootPerformed;
        controls.Ball.Shoot.canceled += OnShootCanceled;
        
    }

    private void OnAimPerformed(InputAction.CallbackContext obj)
    {
        
        a = obj.ReadValue<Vector2>(); // permet de lire la valeur de "a" 
        a /= Resolution;
        a.x = Mathf.Clamp(a.x, 0, 1);
        a.y = Mathf.Clamp(a.y, 0, 1);
        //Debug.Log(a);
        // regarder pour le clamp juste apres avoir lu la valeur  -> pour le "a"
        
    }

    private void OnAim2Performed(InputAction.CallbackContext obj)
    {
    }

    private void OnShootPerformed(InputAction.CallbackContext obj)
    {
        IsPressed = true;

        

        //Debug.Log(a);
    }

    private void OnShootCanceled(InputAction.CallbackContext obj)
    {
        /*if (IsPressed = true)
        {
            // the cube is going to move upwards in 10 units per second
            //myRB.velocity = new Vector3(1, 0, 2);
            myRB.velocity = transform.forward;
            IsMove = true;
            Debug.Log("tu tir");
        }*/

        if (IsPressed = true)
        {
            var camForward = Camera.main.transform.forward;
            var camDir = new Vector3(camForward.x, 0.0f, camForward.z);
            myRB.velocity = camDir * Force;
            
                if(myRB.velocity.magnitude < Force1)
                {
                   Slow();
                }
            IsMove = true;
        }

        /*
         var camForward = Camera.main.transform.forward;
         var camDir = new Vector3(camForward.x, 0.0f, camForward.z);
 
         var angle = Mathf.Sign(camDir.x) * Vector3.Angle(camDir.normalized, Vector3.forward);
         var quat = Quaternion.Euler(0f, angle, 0f) * movement;
 
         movement = quat;
        
         
         
         */

    }

    /*private void IsMove() // arreter la camera pendant un tir
    {

    }*/

    private void Slow() // ralentir le mouvement de la balle apres le tir
    {
        myRB.velocity = Vector3.zero;
    }


    // Start is called before the first frame update
    void Start()
    {
        Resolution = new Vector2(Screen.width, Screen.height);
        //Debug.Log(Resolution);
        myRB = GetComponent<Rigidbody>();




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
