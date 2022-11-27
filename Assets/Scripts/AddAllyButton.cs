using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAllyButton : MonoBehaviour
{
    Table table;
    [SerializeField] GameObject tableGoesHere;



    void Awake() {
        table = tableGoesHere.GetComponent<Table>();
    }

    // Start is called before the first frame update
    void Start() {
    }

    // Note: onMouseDown() requires object to have a collision component, with isTrigger = true
    private void OnMouseDown() {
        table.addAlly();
    }


    // Update is called once per frame
    void Update() {
    }
}
