using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPCalculator : MonoBehaviour
{
    public enum ClassType
    { 
        Barbarian,
        Rogue,
        Monk
    };

    public ClassType characterClass;

    public Character myCharacter;

    public Character[] characters;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    public struct Character
    {
        public string name;
        public int hp;
        public ClassType myClass;

    }
}
