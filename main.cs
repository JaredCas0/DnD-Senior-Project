using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;


class Program
{
  public static void Main(string[] args)
  {
    GameClass game = new GameClass();
    //keeps track of what round it is, needed for some interactions
    int round = 1;
    List<object> turnOrder = new List<object>();
    bool playerEndTurn = false;
    
    
    

    
    // on new game call game class
    // wait for character info
    // call game's create character methods with user data
    // call game's load monsters method based on map selected

    //load map screen
    //load tokens
    //figure out initiave
    rollForTurnOrder();
    //start with first entity
    //Do turn per turn
    //while(!didplayerdie && !didallmonstersdie){

    while(!game.DidPlayerDie() && !game.DidAllMonstersDie())
    {
      for(int i = 0; i < turnOrder.Count; i++){
        while(!playerEndTurn)
        {
          playerEndTurn = true;
        }
      }
      

      round++;
    }
    //player actions
    //turn loop that waits until player ends turn
    //when next button is pressed bool changes turn, move to next monster
    //}
    //GameOver(player) function for main class
    //here would be if the person wants to export the character
    void rollForTurnOrder()
    {
      int arrSize = game.GetMonsters().Count +1;
      
      int[] initiatives = new int[arrSize];
      //adds player to the turn order, records the initiative he rolled
      int initiative = game.GetPlayerCharacter().GetInitiative() + game.RollDie(20);
      initiatives[0] = initiative;
      turnOrder.Add(game.GetPlayerCharacter());
      int amountOrdered = 1;
      
      for(int i = 0; i < arrSize-1; i++)
      {
        initiative = game.GetMonsters()[i].GetInitiative() + game.RollDie(20);

        int j;
        for(j = amountOrdered -1; j >= 0 && initiative < initiatives[j]; j--)
        {
          initiatives[j+1] = initiatives[j];
          
        }
        initiatives[j+1] = initiative;
        amountOrdered++;
        turnOrder.Insert(j+1, game.GetMonsters()[i]);
      }
    }
    
    
  }

  
}

