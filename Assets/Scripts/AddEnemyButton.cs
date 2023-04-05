using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AddEnemyButton : MonoBehaviour
{
    int difficulty;

    public int difficulty_int;

    public TextMeshPro Difficulty;

    Table table;
    [SerializeField] GameObject tableGoesHere;



    void Awake() {
        table = tableGoesHere.GetComponent<Table>();
    }

    // Start is called before the first frame update
    void Start() {
        difficulty = Random.Range(1, 3);
        table.addWave(difficulty);
        difficulty_int = difficulty;
        Difficulty.text = "Difficulty: " + difficulty_int.ToString();
    }

    // Update is called once per frame
    void Update() {
    }
}
