using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEditor.UI;

public class Card : MonoBehaviour
{
    // Actual values
    public int hp_int;
    public int atk_int;
    // NonSerialized means public but not shown in unity
    [System.NonSerialized] public int index;
    [System.NonSerialized] public bool isPlayer;


    // Displayed text
    public TextMeshPro hp;
    public TextMeshPro atk;

    Table table;
    [SerializeField] GameObject tableGoesHere;



    void Awake() {
        table = tableGoesHere.GetComponent<Table>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void reduceHp(int dmg) {
        hp_int -= dmg;
        if (hp_int <= 0) {
            Destroy(gameObject);
        }
        hp.text= hp_int.ToString();
    }
    
    // Note: onMouseDown() requires object to have a collision component, with isTrigger = true
    private void OnMouseDown() {
        table.attack(isPlayer, index);
    }



    // Setters need to update text value as well
    public void setHp(int n) {
        hp_int = n;
        hp.text = hp_int.ToString();
    }

    public void setAtk(int n) {
        atk_int = n;
        atk.text = atk_int.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
