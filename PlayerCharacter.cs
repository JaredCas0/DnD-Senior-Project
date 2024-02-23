using System;
using UnityEngine;

class PlayerCharacter{
  public string name;
  public string className;
  private string race;
  private string subrace;
  private string background;
  
  private int strength;
  private int wisdom;
  private int dexterity;
  private int constitution;
  private int intelligence;
  private int charisma;
  private int level;
  private int maxhp;
  public int currenthp;
  public int armorClass;
  private int initiative;
  private int speed;
  public currentSpeed;

  private int strSaveProficiency;
  private int dexSaveProficiency;
  private int conSaveProficiency;
  private int intSaveProficiency;
  private int wisSaveProficiency;
  private int chaSaveProficiency;

  private int profiencyBonus;

  private string[] armorProficencies;
  private string[] weaponProficencies;

  public string[] equipment;
  public int[] spellSlots = new int[10];
  private string[] spells;
  
  public string condition;
  public string[] resistances;
  public string[] immunities;

  public bool isActionAvailable = true;
  public bool isBonusActionAvailable = true;
  public bool isReactionAvailable = true;
  
  


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
  
  
  public int GetMaxHP() => maxhp;
  public int GetInitiative() => initiative;
  public int GetStrSaveProficiency() => strSaveProficiency;
  public int GetDexSaveProficiency() => dexSaveProficiency;
  public int GetConSaveProficiency() => conSaveProficiency;
  public int GetIntSaveProficiency() => intSaveProficiency;
  public int GetWisSaveProficiency() => wisSaveProficiency;
  public int GetChaSaveProficiency() => chaSaveProficiency;
  public int GetProficiencyBonus() => profiencyBonus;
  
}