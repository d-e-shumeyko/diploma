using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinsScript : MonoBehaviour, Idatapersistence
{
  
    public int coinsCollected;

  

   
   



    public void pickCoinUp()
    {
        
        coinsCollected++;
    }

    public void loadData(gameData data)
    {
        this.coinsCollected = data.coins;
       
    }
    public void saveData(ref gameData data)
    {
        data.coins = this.coinsCollected;
    }



}
