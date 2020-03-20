using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{

    public Card currentCard;
    public Card SaladCardPrefab;
    public Card FishCardPrefab;
    public Card SharkCardPrefab;
    public Canvas canvas;
    public int totalEnergy;
    public Text energyText;
    public int totalCalories;
    public Text caloriesText;
    public GameObject[] anchors;
    public List<Card> plate;


    public void NewCard()
    {
        if (currentCard != null)
        {
            if (!CanAffordCost(currentCard.costType, currentCard.costCount))
            {
                Debug.Log("can't afford that");
                return;
            }
            SpendCost(currentCard.costType, currentCard.costCount);
            SpawnCard(currentCard);

        }
        else
        {
            Debug.Log("please select a card");
        }
    }

    public void SpendCost(CardType costType, int cost)
    {
        foreach (Card c in plate)
        {
            if (cost == 0)
            {
                break;
            }
            if (c.cardType == costType)
            {
                plate.Remove(c);
                Destroy(c.gameObject);
                cost--;
            }
        }
    }

    public void SpawnCard(Card toSpawn)
    {
        Transform spawnLocation = null;
        foreach (GameObject a in anchors)
        {
            if (a.transform.childCount <= 0)
            {
                spawnLocation = a.GetComponent<Transform>();
                break;
            }
        }
        Card newCard = Instantiate(toSpawn, spawnLocation);
        totalEnergy = totalEnergy - toSpawn.energyNeeded;
        Debug.Log(totalEnergy);
        energyText.text = "Energy Left " + totalEnergy;
        totalCalories = totalCalories + toSpawn.caloriesProvided;
        Debug.Log(totalCalories);
        caloriesText.text = "Calories " + totalCalories;
        plate.Add(newCard);
    }

    public bool CanAffordCost(CardType costType, int costCount)
    {
        int count = 0;
        foreach (var card in plate)
        {
            if (card.cardType == costType)
            {
                count++;
            }
        }
        if (count >= costCount)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void SaladButtonClicked()
    {
        if (totalEnergy > 0)
        {
            currentCard = SaladCardPrefab;
        }
        if (totalEnergy == 0)
        {
            Debug.Log("not enough energy");
        }
    }

    public void FishButtonClicked()
    {
        currentCard = FishCardPrefab;
    }

    public void SharkButtonClicked()
    {
        currentCard = SharkCardPrefab;
    }

}
