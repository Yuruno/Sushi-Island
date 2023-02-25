using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Table : MonoBehaviour {

    public GameObject prefab;

    // 5 cards per side
    static public GameObject[] enemyCards = new GameObject[3];
    static public GameObject[] playerCards = new GameObject[3];
    // These numbers worked for me lol
    [SerializeField] int spacing = 150;
    [SerializeField] int enemyX = 1000;
    [SerializeField] int playerX = 25;


    // Start is called before the first frame update
    void Start() {
    }
    
    public void addEnemy() {
        // Find first empty card slot on enemy side and adds a card there
        for (int i = 0; i < enemyCards.Length; i++) {
            if (enemyCards[i] == null) {
                enemyCards[i] = Instantiate(prefab);
                enemyCards[i].GetComponent<Card>().setAtk(i + 1);
                enemyCards[i].GetComponent<Card>().setHp(2 * i + 1);
                enemyCards[i].transform.position = new Vector3(enemyX, (spacing * i) + 50, 0);
                enemyCards[i].GetComponent<Card>().index = i;
                enemyCards[i].GetComponent<Card>().isPlayer = false;
                break;
            }
        }
    }
    
    public void addAlly() {
        // Find first empty card slot on player side and adds a card there
        for (int i = 0; i < playerCards.Length; i++) {
            if (playerCards[i] == null) {
                playerCards[i] = Instantiate(prefab);
                playerCards[i].GetComponent<Card>().setAtk(i + 1);
                playerCards[i].GetComponent<Card>().setHp(2 * i + 1);
                playerCards[i].transform.position = new Vector3(playerX, (spacing * i) + 50, 0);
                playerCards[i].GetComponent<Card>().index = i;
                playerCards[i].GetComponent<Card>().isPlayer = true;
                break;
            }
        }
    }

    public void attack(bool isPlayer, int index) {
        // Attacks the card opposite of chosen card
        if (isPlayer) {
            if (enemyCards[index] != null) { 
                enemyCards[index].GetComponent<Card>().reduceHp(playerCards[index].GetComponent<Card>().atk_int);
            }
        } else {
            if (playerCards[index] != null) {
                playerCards[index].GetComponent<Card>().reduceHp(enemyCards[index].GetComponent<Card>().atk_int);
            }
        }
    }





    // Update is called once per frame
    void Update() {
        
    }
}
