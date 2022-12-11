
using UnityEngine;

public class health : MonoBehaviour
{
   
   [SerializeField] private GameOverHandler gameOverHandler;
   public void Crash()
   {

    gameOverHandler.EndGame();
    gameObject.SetActive(false);


   }
}
