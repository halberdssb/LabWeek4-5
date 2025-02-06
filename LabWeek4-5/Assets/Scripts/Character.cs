using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string name;
    public int level;
    public string characterClass;
    public int conScore;
    public bool isHillDwarf;
    public bool hasToughFeat;
    public bool isHPAveraged;


    public List<string> classes = new List<String> { "Artificer", "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Ranger", "Rogue", "Paladin", "Sorcerer", "Wizard", "Warlock" };

    public Dictionary<string, int> classHitDice = new Dictionary<string, int>
    {
        {"Artificer", 8}, {"Barbarian", 12}, {"Bard", 8}, {"Cleric", 8}, {"Druid", 8}, {"Fighter", 10},
        {"Monk", 8}, {"Ranger", 10}, {"Rogue", 8}, {"Paladin", 10}, {"Sorcerer", 6}, {"Wizard", 6},
        {"Warlock", 8}
    };

    public int[] conScoreModifiers = {-5, -4, -4, -3, -3, -2, -2, -1, -1, 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7,
8, 8, 9, 9, 10 };
}

