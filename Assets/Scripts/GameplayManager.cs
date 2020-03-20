using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{

    public Card currentCard;
    public Card SaladCardPrefab;
    public Card FishCardPrefab;
    public Card SharkCardPrefab;
    public Canvas canvas;
    public int totalEnergy;
    public int totalCalories;
    public int greensCount;
    public GameObject[] anchors;
    public List<Card> plate;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NewCard()
    {
        Transform spawnLocation = null;
        foreach (GameObject a in anchors)
        {
            if (a.transform.childCount <=0)
            { 
            spawnLocation = a.GetComponent<Transform>();
            break;
            }

        }
        Card newCard = Instantiate(currentCard, spawnLocation);
        totalEnergy = totalEnergy - currentCard.energyNeeded;
        Debug.Log(totalEnergy);
        totalCalories = totalCalories + currentCard.caloriesProvided;
        Debug.Log(totalCalories);
        plate.Add(newCard);
    }

    public void SaladButtonClicked()
    {
        if (totalEnergy > 0)
        {
            currentCard = SaladCardPrefab;
        }
        if(totalEnergy == 0)
        {
            Debug.Log("not enough energy");
        }
    }

    public void FishButtonClicked()
    {
        if (plate.Contains(SaladCardPrefab))
        {
            currentCard = FishCardPrefab;
        }
        else
        {
            Debug.Log("no food for fish");
        }
    }

    public void SharkButtonClicked()
    {
        currentCard = FishCardPrefab;
        Debug.Log(currentCard);
    }

}
