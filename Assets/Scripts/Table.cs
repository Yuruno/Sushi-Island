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
    
    public void addEnemy(int atk, int hp) {
        // Find first empty card slot on enemy side and adds a card there
        for (int i = 0; i < enemyCards.Length; i++) {
            if (enemyCards[i] == null) {
                enemyCards[i] = Instantiate(prefab);
                enemyCards[i].GetComponent<Card>().setAtk(atk);
                enemyCards[i].GetComponent<Card>().setHp(hp);
                enemyCards[i].transform.position = new Vector3(enemyX, (spacing * i) + 50, 0);
                enemyCards[i].GetComponent<Card>().index = i;
                enemyCards[i].GetComponent<Card>().isPlayer = false;
                break;
            }
        }
    }

    public void addWave(int difficulty)
        //Check wave difficulty
    {
        //difficulty 1 has 3 enemies of low stats
        if (difficulty == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                int atk = Random.Range(3, 4);
                int hp = Random.Range(3, 4);
                addEnemy(atk, hp);
            }
        }
        //difficulty 2 has 2 enemies of medium stats
        else if (difficulty == 2)
        {
            for (int i = 0; i < 2; i++)
            {
                int atk = Random.Range(6, 9);
                int hp = Random.Range(6, 9);
                addEnemy(atk, hp);
            }
        }
        //difficulty 3 has 1 enemy of high stats
        else
        {
            int atk = Random.Range(10, 15);
            int hp = Random.Range(10, 15);
            addEnemy(atk, hp);
        }

    }
    
    public void addAlly() {
        // Find first empty card slot on player side and adds a card there
        for (int i = 0; i < playerCards.Length; i++) {
            if (playerCards[i] == null) {
                int hp = Random.Range(1, 10);
                int atk = Random.Range(1, 10);
                playerCards[i] = Instantiate(prefab);
                playerCards[i].GetComponent<Card>().setAtk(atk);
                playerCards[i].GetComponent<Card>().setHp(hp);
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
