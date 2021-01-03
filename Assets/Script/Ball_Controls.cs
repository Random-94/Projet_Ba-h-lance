using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;
using TMPro;
using UnityEngine.SceneManagement;

public class Ball_Controls : MonoBehaviour
{
    [SerializeField] private float Gravity;
    

    public Rigidbody myRB ;
    [SerializeField] CinemachineFreeLook Mycam;
    
    //private Vector3 lookDirection ; //la direction dans laquelle la camera est orientée

    [SerializeField] float Force;
    private float Force1;
   

    private bool IsMove; //savoir si la balle est à l’arrêt ou pas
    private bool IsPressed = false; //savoir si on a appuyer
    private Controls controls;
    private Vector2 mousePos; // le point "a" correspond a la premiere postion de ma souris chaque frame
    private Vector2 Resolution; //correspond a la variable qui va contenir la resolution de l'ecran
    private Vector2 a, b;

    private bool CamMove;
    
    //question
    [SerializeField] private Transform ball;
    [SerializeField] private Transform RespawnPoint;
    [SerializeField] private Transform RespawnPoint2;
    [SerializeField] private Transform RespawnPoint3;
    [SerializeField] private Transform RespawnPoint4;
    [SerializeField] private Transform RespawnPoint5;
    /*[SerializeField] private Transform RespawnPoint6;
    [SerializeField] private Transform RespawnPoint7;
    [SerializeField] private Transform RespawnPoint8;
    [SerializeField] private Transform RespawnPoint9;
    [SerializeField] private Transform RespawnPoint10;*/
    [SerializeField] private TextMeshProUGUI Question1;
    [SerializeField] private TextMeshProUGUI Question2;
    [SerializeField] private TextMeshProUGUI Question3;
    [SerializeField] private TextMeshProUGUI Question4;
    [SerializeField] private TextMeshProUGUI Question5;
    /*[SerializeField] private TextMeshProUGUI Question6;
    [SerializeField] private TextMeshProUGUI Question7;
    [SerializeField] private TextMeshProUGUI Question8;
    [SerializeField] private TextMeshProUGUI Question9;
    [SerializeField] private TextMeshProUGUI Question10;*/

    

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Resolution = new Vector2(Screen.width, Screen.height);
        //Debug.Log(Resolution);
        myRB = GetComponent<Rigidbody>();

        Question2.GetComponent<TextMeshProUGUI>().enabled = false;
        Question3.GetComponent<TextMeshProUGUI>().enabled = false;
        Question4.GetComponent<TextMeshProUGUI>().enabled = false;
        Question5.GetComponent<TextMeshProUGUI>().enabled = false;
        /*Question6.GetComponent<TextMeshProUGUI>().enabled = false;
        Question7.GetComponent<TextMeshProUGUI>().enabled = false;
        Question8.GetComponent<TextMeshProUGUI>().enabled = false;
        Question9.GetComponent<TextMeshProUGUI>().enabled = false;
        Question10.GetComponent<TextMeshProUGUI>().enabled = false;*/


        CamMove = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (myRB.velocity.magnitude <= 0.1f)
        {
            IsMove = false;
        }

        if(!CamMove)
        {
            Mycam.m_XAxis.m_MaxSpeed = 0;
            Mycam.m_YAxis.m_MaxSpeed = 0;
        }
        else if(CamMove)
        {
            Mycam.m_XAxis.m_MaxSpeed = 130; 
            Mycam.m_YAxis.m_MaxSpeed = 1.3f;
        }

    }


    private void OnEnable()
    {
        controls = new Controls();
        controls.Enable();

        controls.Ball.Aim.performed += OnAimPerformed; //position souris 
        controls.Ball.Cam.performed += OnCamPerformed;
        controls.Ball.Cam.canceled += OnCamCanceled;
        controls.Ball.Shoot.performed += OnShootPerformed;
        controls.Ball.Shoot.canceled += OnShootCanceled;
        


    }

    private void OnAimPerformed(InputAction.CallbackContext obj)
    {
        
        mousePos = obj.ReadValue<Vector2>(); // permet de lire la valeur de "a" 
        mousePos /= Resolution;
        mousePos.x = Mathf.Clamp(mousePos.x, 0, 1);
        mousePos.y = Mathf.Clamp(mousePos.y, 0, 1);
        //Debug.Log(a);
        b = obj.ReadValue<Vector2>(); // permet de lire la valeur de "a" 
        b /= Resolution;
        b.x = Mathf.Clamp(b.x, 0, 1);
        b.y = Mathf.Clamp(b.y, 0, 1);

    }

    private void OnCamPerformed(InputAction.CallbackContext obj)
    {
        
        CamMove = true;

    }

    private void OnCamCanceled(InputAction.CallbackContext obj)
    {

        CamMove = false;

    }


    private void OnShootPerformed(InputAction.CallbackContext obj)
    {
        /*if(!IsMove)
        {
            Mycam.m_XAxis.m_MaxSpeed = 0;
            Mycam.m_YAxis.m_MaxSpeed = 0;
        }*/
        a = mousePos;
        
        

        Debug.Log(mousePos);

       
    }

    private void OnShootCanceled(InputAction.CallbackContext obj)
    {
        

        b = mousePos;
        /*
         * var posAddForce = b - a;          
           var posAdvancedLengh = posAddForce.magnitude; equivaut a "var magnitude = Vector2.Distance(a, b);"
        */

        var magnitude = Vector2.Distance(a, b);

        var camForward = Camera.main.transform.forward;
        var camDir = new Vector3(camForward.x, 0.0f, camForward.z);
        myRB.AddForce(camDir * Force * magnitude, ForceMode.Impulse);
        IsMove = true;
        
        
        //Mycam.m_XAxis.m_MaxSpeed = 300; 
        //Mycam.m_YAxis.m_MaxSpeed = 2;
        Debug.Log(b);







    }
    private void OnTriggerEnter(Collider other)
    {
        //question1
        if (other.CompareTag("RespawnTrigger"))
        {
            ball.transform.position = RespawnPoint.transform.position;
            Physics.SyncTransforms();
            myRB.velocity = Vector3.zero;
        }

        if (other.CompareTag("RepB"))
        {
            ball.transform.position = RespawnPoint2.transform.position;
            Physics.SyncTransforms();
            myRB.velocity = Vector3.zero;
            //Destroy(Question1);
            Question1.GetComponent<TextMeshProUGUI>().enabled = false;
            Question2.GetComponent<TextMeshProUGUI>().enabled = true;

        }
        if (other.CompareTag("RepF"))
        {
            ball.transform.position = RespawnPoint.transform.position;
            Physics.SyncTransforms();
            myRB.velocity = Vector3.zero;
        }

        //question2
        if (other.CompareTag("RespawnTrigger2"))
        {
            ball.transform.position = RespawnPoint2.transform.position;
            Physics.SyncTransforms();
            myRB.velocity = Vector3.zero;
        }

        if (other.CompareTag("RepB2"))
        {
            ball.transform.position = RespawnPoint3.transform.position;
            Physics.SyncTransforms();
            myRB.velocity = Vector3.zero;
            Question2.GetComponent<TextMeshProUGUI>().enabled = false;
            Question3.GetComponent<TextMeshProUGUI>().enabled = true;
        }

        if (other.CompareTag("RepF2"))
        {
            ball.transform.position = RespawnPoint2.transform.position;
            Physics.SyncTransforms();
            myRB.velocity = Vector3.zero;
        }

        //question3
        if (other.CompareTag("RespawnTrigger3"))
        {
            ball.transform.position = RespawnPoint3.transform.position;
            Physics.SyncTransforms();
            myRB.velocity = Vector3.zero;
        }

        if (other.CompareTag("RepB3"))
        {
            ball.transform.position = RespawnPoint4.transform.position;
            Physics.SyncTransforms();
            myRB.velocity = Vector3.zero;
            Question3.GetComponent<TextMeshProUGUI>().enabled = false;
            Question4.GetComponent<TextMeshProUGUI>().enabled = true;
        }

        if (other.CompareTag("RepF3"))
        {
            ball.transform.position = RespawnPoint3.transform.position;
            Physics.SyncTransforms();
            myRB.velocity = Vector3.zero;
        }

        //question4
        if (other.CompareTag("RespawnTrigger4"))
        {
            ball.transform.position = RespawnPoint4.transform.position;
            Physics.SyncTransforms();
            myRB.velocity = Vector3.zero;
        }

        if (other.CompareTag("RepB4"))
        {
            ball.transform.position = RespawnPoint5.transform.position;
            Physics.SyncTransforms();
            myRB.velocity = Vector3.zero;
            Question4.GetComponent<TextMeshProUGUI>().enabled = false;
            Question5.GetComponent<TextMeshProUGUI>().enabled = true;
        }

        if (other.CompareTag("RepF4"))
        {
            ball.transform.position = RespawnPoint4.transform.position;
            Physics.SyncTransforms();
            myRB.velocity = Vector3.zero;
        }

        //question5
        if (other.CompareTag("RespawnTrigger5"))
        {
            ball.transform.position = RespawnPoint5.transform.position;
            Physics.SyncTransforms();
            myRB.velocity = Vector3.zero;
        }

        if (other.CompareTag("RepB5"))
        {
            SceneManager.LoadScene("Fin", LoadSceneMode.Single);
        }

        if (other.CompareTag("RepF5"))
        {
            ball.transform.position = RespawnPoint5.transform.position;
            Physics.SyncTransforms();
            myRB.velocity = Vector3.zero;
        }



    }






}
