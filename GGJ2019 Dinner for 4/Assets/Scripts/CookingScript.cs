using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CookingScript : MonoBehaviour
{
    Camera playerCam;
    GameObject foodObject;
    string foodName;
    int dishes = 1;
    Text hoverText;

    public GameObject text;
    public List<string> food;

    private List<string> Surfthai;
    private List<string> Zuup;
    private List<string> SaldPototo; 
    private List<string> YumYum;

    // Start is called before the first frame update
    void Start()
    {
        playerCam = Camera.main;//get main camera reference
        //foodObject = playerCam.transform.GetChild(0).gameObject;//get child of the camera
        //foodName = playerCam.transform.GetChild(0).gameObject.name;//get child name of the camera
        //foodObject = gameObject.GetComponent<GameObject>();
        //foodName = foodObject.name;
        hoverText = text.GetComponent<Text>();
        food = new List<string>();
        Surfthai = new List<string> {"SahMan", "Onyan", "Tototo", "KoySauce"};
        Zuup = new List<string> {"Wet", "Pastata", "Tototo", "SahMan"};
        SaldPototo = new List<string> {"Pototo", "Moyaa", "Onyan", "Eg"};
        YumYum = new List<string> {"Eg", "Flufferoni", "Sweetness", "CowSauce"};
        hoverText.text = "Drop ingredient to cook.";
        Surfthai.Sort();
        Zuup.Sort();
        SaldPototo.Sort();
        YumYum.Sort();
    }

    //collision check
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ingredient")//whatever the tag for the food is
        {
            Debug.Log(collision.gameObject.tag == "ingredient");
            foodObject = GameObject.FindWithTag("ingredient");
            foodName = foodObject.name;
            food.Add(foodName);
            Destroy(foodObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(food.Count);

        if (dishes == 1)
        {
            if (food.Count == 4)
            {
                if (CheckIngrediants(dishes))
                {
                    hoverText.text = "Surfthai is made! Three more dishes to go!";
                    dishes++;
                }
                else
                {
                    hoverText.text = "Looks like I did not make this dish correctly. Need to try again.";
                }
            }
        }

        if (dishes == 2)
        {
            if (food.Count == 4)
            {
                if (CheckIngrediants(dishes))
                {
                    hoverText.text = "Zuup is made! Only two more!";
                    dishes++;
                }
                else
                {
                    hoverText.text = "Not again!! Let me try again.";
                }
            }
        }

        if (dishes == 3)
        {
            if (food.Count == 4)
            {
                if (CheckIngrediants(dishes))
                {
                    hoverText.text = "SaldPototo is made! One last dish left to make!";
                    dishes++;
                }
                else
                {
                    hoverText.text = "Close but not good enough. Lets have at it!";
                }
            }
        }

        if (dishes == 4)
        {
            if (food.Count == 4)
            {
                if (CheckIngrediants(dishes))
                {
                    hoverText.text = "YumYum is made! All done, time to eat dinner!";
                    dishes++;
                }
                else
                {
                    hoverText.text = "Tastes funny. Need a do-over";
                }
            }
        }

        if(dishes == 5)
        {
            //end game
            //cinamatic
            //happy family dinner for the bears
        }
    }

    bool CheckIngrediants(int dish)
    {
        int currentDish = dish;

        if (food.Count != 4 || food.Count != Surfthai.Count || food.Count != Zuup.Count || food.Count != SaldPototo.Count || food.Count != YumYum.Count)
        {
            Debug.Log("Not enough ingredients");
            food.Clear();
            return false;
        }

        food.Sort();

        if (currentDish == 1)
        {
            for (int i = 0; i < food.Count; i++)
            {
                if (food[i] != Surfthai[i])
                {
                    food.Clear();
                    return false;
                }
            }
        }

        if (currentDish == 2)
        {
            for (int i = 0; i < food.Count; i++)
            {
                if (food[i] != Zuup[i])
                {
                    food.Clear();
                    return false;
                }
            }
        }

        if (currentDish == 3)
        {
            for (int i = 0; i < food.Count; i++)
            {
                if (food[i] != SaldPototo[i])
                {
                    food.Clear();
                    return false;
                }
            }
        }

        if (currentDish == 4)
        {
            for (int i = 0; i < food.Count; i++)
            {
                if (food[i] != YumYum[i])
                {
                    food.Clear();
                    return false;
                }
            }
        }

        food.Clear();
        return true;
    }
}
