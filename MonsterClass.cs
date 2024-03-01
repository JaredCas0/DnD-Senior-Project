using System.Collections.Generic;

public class Monster
{
    // Monster information
    public string name { get; }
    public string MonsterType { get; }

    // Monster stats
    public int strength { get; }
    public int dexterity { get; }
    public int constitution { get; }
    public int intelligence { get; }
    public int wisdom { get;  }
    public int charisma { get;  }
    // HP
    public int maxHp { get;  }
    public int currentHp;
    public int armorClass { get; }
    // Initiative & Movement
    public int initiative { get; }
    public int maxSpeed { get; }
    public int currentSpeed;

    // Saves
    public bool hasStrSaveProficiency { get; }
    public bool hasDexSaveProficiency { get; }
    public bool hasConSaveProficiency { get; }
    public bool hasIntSaveProficiency { get; }
    public bool hasWisSaveProficiency { get; }
    public bool hasChaSaveProficiency { get; }

    public int proficiencyBonus { get; }

    // Spells, attacks, abilities
    public List<string> spells { get; }
    public List<string> attacks { get; }
    public List<string> abilities { get; }

    // Conditions and resistances
    public List<string> conditions;
    public List<string> resistances;
    public List<string> immunities;

    //used to keep track of the monsters location
    (int, int) monsterLocation;

    public bool isActionAvailable = true;
    public bool isBonusActionAvailable = true;
    public bool isReactionAvailable = true;


    

    // Constructor
    public Monster(string name, string monsterType, int strength, int dexterity, int constitution, int intelligence, int wisdom, int charisma, int maxHp, int armorClass, int initiative, int maxSpeed, bool strSaveProf, bool dexSaveProf, bool conSaveProf, bool intSaveProf, bool wisSaveProf, bool chaSaveProf, int proficiencyBonus, List<string> spells, List<string> attacks, List<string> abilities, List<string> resistances, List<string> immununities)
    {
      this.name = name;
      this.MonsterType = monsterType;

      this.strength = strength;
      this.dexterity = dexterity;
      this.constitution = constitution;
      this.intelligence = intelligence;
      this.wisdom = wisdom;
      this.charisma = charisma;

      this.maxHp = maxHp;
      currentHp = maxHp;

      this.armorClass = armorClass;
      this.initiative = initiative;

      this.maxSpeed = maxSpeed;
      currentHp = maxSpeed;

      hasStrSaveProficiency = strSaveProf;
      hasDexSaveProficiency = dexSaveProf;
      hasConSaveProficiency = conSaveProf;
      hasIntSaveProficiency = intSaveProf;
      hasWisSaveProficiency = wisSaveProf;
      hasChaSaveProficiency = chaSaveProf;

      this.proficiencyBonus = proficiencyBonus;
      this.spells = spells;
      this.attacks = attacks;
      this.abilities = abilities;
      this.resistances = resistances;
      this.immunities = immununities;
        
    }

  //ability modifiers
  public int WisdomModifier() => (wisdom-10)/2;
  public int DexterityModifier() => (dexterity-10)/2;
  public int ConstitutionModifier() => (constitution-10)/2;
  public int IntelligenceModifier() => (intelligence-10)/2;
  public int CharismaModifier() => (charisma-10)/2;
  public int StrengthModifier() => (strength-10)/2;

  //Resets monster actions and currentSpeed at the start of their turn
  public void ResetMonsterForTurn()
  {
    isActionAvailable = true;
    isBonusActionAvailable = true;
    isReactionAvailable = true;
    currentSpeed = maxSpeed;
  }

  //TakeDamage and HealHp will be used to set currentHp to different amounts
   public void TakeDamage(int damage)
   {
     if(currentHp - damage < 0)
     {
       currentHp = 0;
     }
     else
     {
       currentHp -= damage;
     }

   }
    //doesn't heal above maxHp, won't allow healing a negative amount
   public void HealHp(int healAmount)
   {
    if(healAmount < 0)
    {
      return;
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

  public void SetMonsterLocation(int x, int y)
  {
    monsterLocation = (x,y);
  }
  //when a monster moves, they spend currentSpeed
  //can't move if they have 0 speed
  public void MonsterMove(int distance)
  {
    if(currentSpeed-distance < 0)
    {
      currentSpeed = 0;
    }
    else
    {
      currentSpeed -= distance;
    }

  }

  //add and remove conditions
  public void AddCondition(string condition)
  {
    if(!conditions.Contains(condition))
    {
      conditions.Add(condition);
    }
  }
  public void RemoveCondition(string condition)
  {
    if(conditions.Contains(condition))
    {
      conditions.Remove(condition);
    }
  }

  //add and remove resistances
  public void AddResistance(string resistance)
  {
    if(!resistances.Contains(resistance))
    {
      resistances.Add(resistance);
    }
  }

  public void RemoveResistance(string resistance)
  {
    if(resistances.Contains(resistance))
    {
      resistances.Remove(resistance);
    }
  }

  //add and remove immunities
  public void AddImmunity(string immunity)
  {
    if(!immunities.Contains(immunity))
    {
      immunities.Add(immunity);
    }
  }
  public void RemoveImmunity(string immunity)
  {
    if(immunities.Contains(immunity))
    {
      immunities.Remove(immunity);
    }
  }


  //The monster used their actions, so they can't use it again
  public void UseAction()
  {
    isActionAvailable = false;
  }
  //The monster used their bonus actions, so they can't use it again
  public void UseBonusAction()
  {
    isBonusActionAvailable = false;
  }
  //The monster used their reaction, so they can't use it again
  public void UseReaction()
  {
    isReactionAvailable = false;
  }
  
  

    // Methods for getting saves and proficiency bonus
    public bool GetStrSaveProficiency() => hasStrSaveProficiency;
    public bool GetDexSaveProficiency() => hasDexSaveProficiency;
    public bool GetConSaveProficiency() => hasConSaveProficiency;
    public bool GetIntSaveProficiency() => hasIntSaveProficiency;
    public bool GetWisSaveProficiency() => hasWisSaveProficiency;
    public bool GetChaSaveProficiency() => hasChaSaveProficiency;
    public int GetProficiencyBonus() => proficiencyBonus;

    public string GetName() => name;
    public string GetMonsterType() => MonsterType;


    public int GetArmorClass() => armorClass;
    public int GetCurrentHp() => currentHp;
    public int GetMaxHp() => maxHp;
    public int GetInitiative() => initiative;

    public int GetMaxSpeed() => maxSpeed;
    public int GetCurrentSpeed() => currentSpeed;

   public List<string> GetSpells() => spells;
   public List<string> GetAttacks() => attacks;
   public List<string> GetAbilities() => abilities;


    public List<string> GetConditions() => conditions;
    public List<string> GetResistances() => resistances;
    public List<string> GetImmunities() => immunities;
    // Additional methods for monster actions can be added as needed
}
