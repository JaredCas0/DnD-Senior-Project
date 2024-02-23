using System;
using UnityEngine;

class PlayerCharacter{
  private string name;
  private string className; //role
  private string race; // species
  private string background; //what the character did beforehand
  
  // from strength to charisma are the players attributes
  private int strength;
  private int wisdom;
  private int dexterity;
  private int constitution;
  private int intelligence;
  private int charisma;
  private int level; //the character's level
  private int maxHp; //max player health
  private int currentHp; //this is the hp that the game will change during combat
  private int armorClass; //this determines if the character gets hit
  private int initiative; //this is used to determine turn order
  private int maxSpeed; //max player movement
  private int currentSpeed; //this keeps track of how much movement a player has left for their turn

  //The Str, Dex, Con, Int, Wis, and Cha part are
  //short forms of strength, dexterity, constitution, intelligence, wisdom, and charisma
  private bool hasStrSaveProficiency = false; 
  private bool hasDexSaveProficiency = false;
  private bool hasConSaveProficiency = false;
  private bool hasIntSaveProficiency = false;
  private bool hasWisSaveProficiency = false;
  private bool hasChaSaveProficiency = false;

  private int proficiencyBonus;

  private string[] armorProficiencies;
  private string[] weaponProficiencies;

  private string[] equipment;//The items a player has
  private int[] spellSlots = new int[10]; //cantrips and spells from 1-9
  private string[] spells; //spells available to the player
  
  private string[] conditions; //any conditions that the player gets during combat
  private string[] resistances; //what the player will only take half damage from
  private string[] immunities; //what the player takes no damage from

  //what actions are available to the player
  public bool isActionAvailable = true;
  public bool isBonusActionAvailable = true;
  public bool isReactionAvailable = true;


  public (int, int) playerLocation;
  


  public PlayerCharacter(string name, string race, string subrace, string className,  string background)
  {
    this.name = name;
    this.race = race;
    this.subrace = subrace;
    this.className = className;
    this.background = background;
    
  }

  public void SetStats(int str, int dex, int con, int intel, int wis, int cha, int level, int hp, int ac, int initiative, int speed)
  {
    strength = str;
    dexterity = dex;
    constitution = con;
    intelligence = intel;
    wisdom = wis;
    charisma = cha;
    this.level = level;
    maxhp = hp;
    currenthp = hp;
    armorClass = ac;
    this.initiative = initiative;
    this.speed = speed;
    
  }

  public void SetEquiped(string[] equipment)
  {
    this.equipment = equipment;
  }

  public void SetSpells(string[] spells)
  {
    this.spells = spells;
  }



  public int WisdomModifier() => (wisdom-10)/2;
  public int DexterityModifier() => (dexterity-10)/2;
  public int ConstitutionModifier() => (constitution-10)/2;
  public int IntelligenceModifier() => (intelligence-10)/2;
  public int CharismaModifier() => (charisma-10)/2;
  public int StrengthModifier() => (strength-10)/2;

  public void ResetPlayerForTurn()
  {
    isActionAvailable = true;
    isBonusActionAvailable = true;
    isReactionAvailable = true;
    currentSpeed = maxSpeed;
  }

  //TakeDamage and HealHp will be used to set currentHp to different amounts
 public void TakeDamage(int damage)
 {
    currentHp -= damage;
 }
  //doesn't heal above maxHp, won't allow healing a negative amount
 public void HealHp(int healAmount)
 {
  if(healAmount < 0)
  {
    break;
  }
  if(currentHp + healAmount > maxHp)
  {
    currentHp = maxHp;
  }
  else
  {
    currentHp += healAmount;
  }
 } 
  
  public string GetName() => name;
  public string GetClassName() => className;
  public string GetRace() => race;
  public string GetBackground() => background;
  public int GetCurrentHp() => currentHp;
  public int GetMaxHp() => maxhp;
  public int GetLevel() => level;
  public bool GetInitiative() => initiative;
  public bool GetStrSaveProficiency() => strSaveProficiency;
  public bool GetDexSaveProficiency() => dexSaveProficiency;
  public bool GetConSaveProficiency() => conSaveProficiency;
  public bool GetIntSaveProficiency() => intSaveProficiency;
  public bool GetWisSaveProficiency() => wisSaveProficiency;
  public bool GetChaSaveProficiency() => chaSaveProficiency;
  public int GetProficiencyBonus() => proficiencyBonus;
  
}
