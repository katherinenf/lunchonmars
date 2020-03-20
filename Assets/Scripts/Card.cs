using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum CardType
{
    Salad, 
    Fish, 
    Shark,
    Steak,
    Bacon,
    Chicken
}

public class Card : MonoBehaviour
{

    public CardType cardType;
    public int energyNeeded;
    public int caloriesProvided;
    public CardType costType;
    public int costCount;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
