using System.Collections;
using System.Collections.Generic;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;// on rajoute le namespace scenemanagement pour gérer le changement de scene

public class Pause_Menu : MonoBehaviour
{


    public static bool GameIsPaused = false; //je commence le jeu en timescale 1 (sans pause)
    public Rigidbody myRB;
    public GameObject PauseMenuUi; // je cree la variable du menu qui va s'afficher a l'ecran
    private Controls controls;// on cree une variable pour les inputs d'actions du personnage

    [SerializeField] GameObject Ball;

    private void OnEnable()
    {
        controls = new Controls();// //on instancie l'input system créé dans Unity
        controls.Enable();//on instancie l'input system créé dans Unity
        controls.Ball.Pause.performed += OnPausePerformed;//quand on appuie sur les inputs de l'action Pause de l'action Map Perso, on lance la fonction OnPausePerformed
        controls.Ball.Shoot.performed += OnShootPerformed;
        controls.Ball.Shoot.canceled += OnShootCanceled;
    }

    void Start()
    {
        myRB = Ball.GetComponent<Rigidbody>();


    }

    private void OnPausePerformed(InputAction.CallbackContext obj) //je demande de realiser les fonctions resume ou pause lorsque que la fonction OnPausePerformed est activée
    {

        Resume();
        Pause();

    }

    private void OnShootPerformed(InputAction.CallbackContext obj) 
    {

        

    }
    private void OnShootCanceled(InputAction.CallbackContext obj)
    {
        myRB.AddForce(0, 0, 0); // j'essai d'enlever la force du tir quand j'appuie sur continuer


    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void Resume()
    {
        PauseMenuUi.SetActive(false); // on demande a l'ui du menu pause de disparaitre lorsque qu'on appuie sur le bouton correspondant
        Time.timeScale = 1f; //le jeu revient en timescale 1, c'est a dire que l'ecran n'est plus freeze
        GameIsPaused = false;
        
    }

    public void Pause()
    {
        PauseMenuUi.SetActive(true);// on demande a l'ui du menu pause d'apparaitre lorsque qu'on appuie sur le bouton correspondant
        Time.timeScale = 0f;//le jeu se met en timescale 0, c'est a dire que l'ecran est freeze , laissant seulement le menu actif
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
        Debug.Log("Loading menu...");//Charge la scène du jeu
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit menu...");//demande de quitter le jeu
    }

}
