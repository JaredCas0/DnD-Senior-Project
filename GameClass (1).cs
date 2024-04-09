using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;


public class GameClass
{
  private PlayerCharacter player = new PlayerCharacter();
  List<Monster> monsters = new List<Monster>();
  
  public GameClass(){}
  


  //These will set up the player during character creation
  public void CreatePlayerCharacter(string name, string race, string className,  string background)
    {
      player.setStartInput(name, race, className, background);

    }

  public void SetPlayerStats(int str, int dex, int con, int intel, int wis, int cha, int level, int hp, int ac, int initiative, int speed)
  {
    player.SetStats(str, dex, con, intel, wis, cha, level, hp, ac, initiative, speed);
  }

  public void SetPlayerEquipment(string[] equipment)
  {
    player.SetEquiped(equipment);
  }

  public void SetPlayerSpells(string[] spells, int[] spellSlots)
  {
    player.SetSpells(spells);
    player.SetSpellSlots(spellSlots);
  }


  //Create monsters, amountOfMonsters is how many monsters you want to make
  public void LoadMonsters(string filePath, int amountToCreate)
  {
    try
    {
      using (var reader = new StreamReader(filePath))
      {
        bool isFirstLine = true;
        while (!reader.EndOfStream && amountToCreate > 0)
        {
          var line = reader.ReadLine();
          if (isFirstLine)
          {
            isFirstLine = false; // Skip the first line
            continue;
          }


          var values = line.Split(',');
          Monster newMonster = new Monster(values[0], values[1], values[2], int.Parse(values[3]), int.Parse(values[4]), double.Parse(values[5]), int.Parse(values[6]), int.Parse(values[7]), int.Parse(values[8]), int.Parse(values[9]), int.Parse(values[10]), int.Parse(values[11]), bool.Parse(values[12]), bool.Parse(values[13]), bool.Parse(values[14]), bool.Parse(values[15]), bool.Parse(values[16]), bool.Parse(values[17]), int.Parse(values[18]), int.Parse(values[19]), values[20].Split(";").ToList(), values[21].Split(";").ToList(), values[22].Split(";").ToList(), values[23].Split(";").ToList(), values[24].Split(";").ToList(), values[25].Split(";").ToList(), double.Parse(values[26]));

          monsters.Add(newMonster);
          amountToCreate--;

          //values 20-25 are lists

        }
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
    }
  }


  //simulates rolling an n-sided die

  public int RollDie(int sides)
  {
    if(sides < 1)
    {
      return 0;
    }
    Random rnd = new Random();
    return rnd.Next(1, sides+1);
  }


  //if the player is dead, then the game is over
  public bool DidPlayerDie() => player.GetCurrentHp() <= 0;

  //if all the monsters are dead, then the game is over
  public bool DidAllMonstersDie() => !monsters.Any();

  //a monster is killed if it has 0 or less hp
  public void KillMonster(Monster monster)
  {
    if(monster.GetCurrentHp() <= 0)
    {
      monsters.Remove(monster);
    }
  }

  //Add to keep track of attack range
  //Monsters that are close enough for you to attack
  //distance formula = sqrt( (x1-x2)^2 + (y1-y2)^2)
  //x = (x1-x2)^2, y = (y1-y2)^2
  //if the distance is equal to or less than the radius, it is within attack range
  public List<Monster> InAttackVicinity(double radius)
  {
    List<Monster> attackableMonsters = new List<Monster>();
    double x1 = player.GetPlayerLocation().Item1;
    double y1 = player.GetPlayerLocation().Item2;
    for(int i = 0; i < monsters.Count; i++)
    {
      double x = Math.Pow((x1-monsters[i].GetMonsterLocation().Item1),2);
      double y = Math.Pow((y1-monsters[i].GetMonsterLocation().Item2),2);
      double distanceFromPlayer = Math.Sqrt(x + y);
      if(distanceFromPlayer <= radius)
      {
        attackableMonsters.Add(monsters[i]);
      }
    }

    return attackableMonsters;
  }

  
  public List<Monster> GetMonsters() => monsters;
  public PlayerCharacter GetPlayerCharacter() => player;

}