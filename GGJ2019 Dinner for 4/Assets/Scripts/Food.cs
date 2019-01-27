using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private string foodName;//name of the food
    private int foodWeight;//weight food holds
    
    public Food(string name, int weight)//constructor
    {
        this.foodName = name;
        this.foodWeight = weight;
    }
    
    public void setFood(Food food)
    {
        setFoodName(food.foodName);
        setFoodWeight(food.foodWeight);
    }

    public void setFoodName(string myName)//set name
    {
        if (myName != null)
        {
            foodName = myName;
        }
        Debug.Log(foodName);
    }

    public string getFoodName()
    {
        return foodName;
    }

    public void setFoodWeight(int myWeight)//set weight
    {
        if (!(myWeight < 0))
        {
            foodWeight = myWeight;
        }
        Debug.Log(foodWeight);
    }

    public int getFoodWeight()
    {
        return foodWeight;
    }
}
