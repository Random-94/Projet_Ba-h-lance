using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class Ball_Controls : MonoBehaviour
{
    [SerializeField] private float Gravity;

    public Rigidbody myRB ;
    [SerializeField] CinemachineFreeLook Mycam;
    
    //private Vector3 lookDirection ; //la direction dans laquelle la camera est orientée

    [SerializeField] float Force;
    [SerializeField] float Force1;
   

    private bool IsMove; //savoir si la balle est à l’arrêt ou pas
    private bool IsPressed = false; //savoir si on a appuyer
    private Controls controls;
    private Vector2 a; // le point "a" correspond a la premiere postion de ma souris chaque frame
    private Vector2 Resolution; //correspond a la variable qui va contenir la resolution de l'ecran


    // Start is called before the first frame update
    void Start()
    {
        Resolution = new Vector2(Screen.width, Screen.height);
        //Debug.Log(Resolution);
        myRB = GetComponent<Rigidbody>();
        

        //RECUPERER VALEUR DE LA SPEED CAM X,Y ET STOCKER DANS VARIABLES CHACUNES -> a assigner apres 

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (myRB.velocity.magnitude <= 0f)
        {
            IsMove = false;
        }


    }


    private void OnEnable()
    {
        controls = new Controls();
        controls.Enable();

        controls.Ball.Aim.performed += OnAimPerformed; //position souris
        
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

    

    private void OnShootPerformed(InputAction.CallbackContext obj)
    {
        if(!IsMove)
        {
            Mycam.m_XAxis.m_MaxSpeed = 0;
            Mycam.m_YAxis.m_MaxSpeed = 0;
        }
        
        //mettre valeur de speed camera x et y  a zero
        //recuperer la position de la souris


        //vector faut les multiplier entre eux

        Debug.Log(a);
    }

    private void OnShootCanceled(InputAction.CallbackContext obj)
    {
        //recuperer la position de la souris 
        //ensuite, creer le vecteur allant de la premiere position de la souris a celle recupere a la ligne precedente
        //"force" sera la magnitude du vecteur recuperé avant
        if (!IsMove)
        { 
        var camForward = Camera.main.transform.forward;
        var camDir = new Vector3(camForward.x, 0.0f, camForward.z);
        myRB.AddForce(camDir * Force, ForceMode.Impulse);
        IsMove = true;
        }

        Mycam.m_XAxis.m_MaxSpeed = 300; 
        Mycam.m_YAxis.m_MaxSpeed = 2;

        Debug.Log(a);

        //remettre valeur de speed camera de x et y a la normal 




    }


  

   


}
