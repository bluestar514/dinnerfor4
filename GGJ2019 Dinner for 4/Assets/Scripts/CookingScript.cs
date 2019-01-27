using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingScript : MonoBehaviour
{
    Camera playerCam;
    GameObject foodObject;
    int dishes = 1;
    public string foodName;
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
        foodObject = gameObject.GetComponent<GameObject>();
        foodName = foodObject.name;
        food = new List<string>();
        Surfthai = new List<string> {"SahMan", "Onyan", "Tototo", "KoySauce"};
        Zuup = new List<string> {"Wet", "Pastata", "Tototo", "SahMan"};
        SaldPototo = new List<string> {"Pototo", "Moyaa", "Onyan", "Eg"};
        YumYum = new List<string> {"Eg", "Flufferoni", "Sweetness", "CowSauce"};
    }

    //collision check
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "")//whatever the tag for the food is
        {
            food.Add(foodName);
            Destroy(collision.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dishes == 1)
        {
            if (CheckIngrediants(dishes))
            {
                dishes++;
            }
            else
            {

            }
        }

        if (dishes == 2)
        {
            if (CheckIngrediants(dishes))
            {
                dishes++;
            }
            else
            {

            }
        }

        if (dishes == 3)
        {
            if (CheckIngrediants(dishes))
            {
                dishes++;
            }
            else
            {

            }
        }

        if (dishes == 4)
        {
            if (CheckIngrediants(dishes))
            {
                dishes++;
            }
            else
            {

            }
        }

        if(dishes == 5)
        {
            //end game
        }
    }


    bool CheckIngrediants(int dish)
    {
        int currentDish = dish;

        if (food.Count != 4 || food.Count != Surfthai.Count || food.Count != Zuup.Count || food.Count != SaldPototo.Count || food.Count != YumYum.Count)
        {
            return false;
        }

        food.Sort();
        Surfthai.Sort();
        Zuup.Sort();
        SaldPototo.Sort();
        YumYum.Sort();

        if (currentDish == 1)
        {
            for (int i = 0; i < food.Count; i++)
            {
                if (food[i] != Surfthai[i])
                {
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
                    return false;
                }
            }
        }

        food.Clear();
        return true;
    }
}
