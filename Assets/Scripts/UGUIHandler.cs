using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UGUIHandler : MonoBehaviour
{
  [SerializeField] Button startGameButton;
    
   
  
   
   
   
   
   
   public void RestartGame()
   {

   SceneManager.LoadScene(1);

   }
   


}
