using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Solution1 : MonoBehaviour
{
    public string name;
    public int level;
    public string characterClass;
    public int conScore;
    public bool isHillDwarf;
    public bool hasToughFeat;
    public bool isHPAveraged;


    private List<string> classes = new List<String> { "Artificer", "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Ranger", "Rogue", "Paladin", "Sorcerer", "Wizard", "Warlock" };

    private Dictionary<string, int> classHitDice = new Dictionary<string, int>
    {
        {"Artificer", 8}, {"Barbarian", 12}, {"Bard", 8}, {"Cleric", 8}, {"Druid", 8}, {"Fighter", 10},
        {"Monk", 8}, {"Ranger", 10}, {"Rogue", 8}, {"Paladin", 10}, {"Sorcerer", 6}, {"Wizard", 6},
        {"Warlock", 8}
    };

    private int[] conScoreModifiers = {-5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7,
8, 8, 9, 9, 10 };

    private void Start()
    {
        CalculateHP();
    }

    // prints out debug log of character info and hp based in different fields
    private void CalculateHP()
    {
        // declare int hpAmount to calculate character's hp value
        int hpAmount = 0;

        // get local variables of conModifier (int) and hitDie (int) based on character class and defined lists/dictionaries
        int conModifier = conScoreModifiers[conScore - 1];

        int hitDie = 0;
        if (classHitDice.ContainsKey(characterClass))
        {
            classHitDice.TryGetValue(characterClass, out hitDie);
        }
        // if key doesn't exist, debug that class name isn't valid and return
        else
        {
            Debug.LogWarning("The class name does not exist in the class array!");
            return;
        }

        // if using average hp, use (n+1)/2 to calculate average roll * character level
        if (isHPAveraged)
        {
            hpAmount = ((hitDie / 2) + 1) * level;
        }
        // otherwise, roll a random hit die for each level
        else
        {
            for (int i = 0; i < level; i++)
            {
                hpAmount += UnityEngine.Random.Range(1, hitDie);
            }
        }

        // add con modifier
        hpAmount += conModifier * level;

        // if statement checks for hill dwarf and tough feat - add bonuses if true
        if (isHillDwarf)
        {
            hpAmount += level;
        }
        if (hasToughFeat)
        {
            hpAmount += level * 2;
        }

        // debug max hp in correct format with character info
        Debug.Log("My character " + name + " is a level " + level + " " + characterClass + " with a CON score of " + conScore + " and " + (isHillDwarf ? "is " : "is not ") + "a Hill Dwarf and " + (hasToughFeat ? "has " : "does not have ") + "Tough feat. I want the HP " + (isHPAveraged ? "averaged. " : "random. ") + name + "'s HP is " + hpAmount + ".");
    }
}
