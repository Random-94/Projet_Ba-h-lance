using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ball_Controls : MonoBehaviour
{
    [SerializeField] private float Gravity;

    private Rigidbody myRB ;
    private Vector3 lookDirection ; //la direction dans laquelle la camera est orientée

    public float Force = 1.0f;

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

        if (IsMove == false)
        {
            // the cube is going to move upwards in 10 units per second
            myRB.velocity = new Vector3(0, 10, 0);
            IsMove = true;
            Debug.Log("tu tir");
        }

        //Debug.Log(a);
    }

    private void OnShootCanceled(InputAction.CallbackContext obj)
    {
        if (IsPressed = true)
        {
            // the cube is going to move upwards in 10 units per second
            myRB.velocity = new Vector3(0, 10, 0);
            IsMove = true;
            Debug.Log("tu tir");
        }



        //Debug.Log(a);

        /*Une fois le clic gauche relaché et avoir fait une distance entre le point A et le point(le relâchement du clic) -> on calcul la distance des deux points pour 
         * déterminer la puissance du tir  calcul de flore(exemple b - a ; récupérer la taille du vecteur)
	    La force s’applique sur la balle et part dans la direction choisi
        lorsque que IsMove = false(ca veut dire que la balle est a l’arret) on peut tirer, sinon lorsque IsMove = true , il est impossible de tirer et mon curseur ne va
        réapparaitre que quand il passe a false( = !myRB.velocity. ? > 0.1 ) a chercher !!*/


    }




    // Start is called before the first frame update
    void Start()
    {
        Resolution = new Vector2(Screen.width, Screen.height);
        //Debug.Log(Resolution);

        



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
