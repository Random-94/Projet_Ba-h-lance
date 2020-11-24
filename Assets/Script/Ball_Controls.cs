using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ball_Controls : MonoBehaviour
{
    [SerializeField] private float Gravity;

    private Rigidbody myRB ;
    private Vector3 lookDirection ; //la direction dans laquelle la camera est orientée
    private Vector3 MousePosition ; //la position de la souris dans l'espace
    private bool IsMove = false; //savoir si la balle est à l’arrêt ou pas
    private Controls controls;
    private Vector2 a; // le point "a" correspond a la premiere postion de ma souris chaque frame
    private Vector2 Resolution; //resolution de l'ecran



    private void OnEnable()
    {
        controls = new Controls();
        controls.Enable();

        controls.Ball.Aim.performed += OnAimPerformed;
        //Controls.Ball.Aim.canceled += OnAimCanceled;
        controls.Ball.Shoot.performed += OnShootPerformed;
        controls.Ball.Shoot.canceled += OnShootCanceled;

        
    }

    private void OnAimPerformed(InputAction.CallbackContext obj)
    {
        //lookDirection = direction de la camera avec notre curseur -> on recupere les infos de la cam pour l’associer a ma souris
        a = obj.ReadValue<Vector2>();
        a /= Resolution;
        Debug.Log(a);
        
    }

    private void OnShootPerformed(InputAction.CallbackContext obj)
    {
        //MousePosition

    }

    private void OnShootCanceled(InputAction.CallbackContext obj)
    {
        /*Une fois le clic gauche relaché et avoir fait une distance entre le point A et le point(le relâchement du clic) -> on calcul la distance des deux points pour 
         * déterminer la puissance du tir  calcul de flore(exemple b - a ; récupérer la taille du vecteur)
	    La force s’applique sur la balle et part dans la direction choisi
        lorsque que IsMove = false(ca veut dire que la balle est a l’arret) on peut tirer, sinon lorsque IsMove = true , il est impossible de tirer et mon curseur ne va
        réapparaitre que quand il passe a false( = !myRB.velocity. ? > 0.1 ) a chercher !!*/


    }




    // Start is called before the first frame update
    void Start()
    {
        print(Resolution);
        // trouver comment prendre la resolution de l'ecran
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
