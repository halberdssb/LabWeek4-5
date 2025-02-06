using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Solution2 : MonoBehaviour
{


    Character character;

   

    private void Start()
    {
        character = GetComponent<Character>();
        CalculateHP();
    }

    // prints out debug log of character info and hp based in different fields
    private void CalculateHP()
    {
        // declare int hpAmount to calculate character's hp value
        int hpAmount = 0;

        // get local variables of conModifier (int) and hitDie (int) based on character class and defined lists/dictionaries
        int conModifier = character.conScoreModifiers[character.conScore - 1];

        int hitDie = 0;
        if (character.classHitDice.ContainsKey(character.characterClass))
        {
            character.classHitDice.TryGetValue(character.characterClass, out hitDie);
        }
        // if key doesn't exist, debug that class name isn't valid and return
        else
        {
            Debug.LogWarning("The class name does not exist in the class array!");
            return;
        }

        // if using average hp, use (n+1)/2 to calculate average roll * character level
        if (character.isHPAveraged)
        {
            hpAmount = ((hitDie / 2) + 1) * character.level;
        }
        // otherwise, roll a random hit die for each level
        else
        {
            for (int i = 0; i < character.level; i++)
            {
                hpAmount += UnityEngine.Random.Range(1, hitDie);
            }
        }

        // add con modifier
        hpAmount += conModifier * character.level;

        // if statement checks for hill dwarf and tough feat - add bonuses if true
        if (character.isHillDwarf)
        {
            hpAmount += character.level;
        }
        if (character.hasToughFeat)
        {
            hpAmount += character.level * 2;
        }

        // debug max hp in correct format with character info
        Debug.Log("My character " + character.name + " is a level " + character.level + " " + character.characterClass + " with a CON score of " + character.conScore + " and " + (character.isHillDwarf ? "is " : "is not ") + "a Hill Dwarf and " + (character.hasToughFeat ? "has " : "does not have ") + "Tough feat. I want the HP " + (character.isHPAveraged ? "averaged. " : "random. ") + character.name + "'s HP is " + hpAmount + ".");
    }
}

