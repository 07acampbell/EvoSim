using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agentVariables : MonoBehaviour
{
    public float speed = 20f;
    public int foodEaten;
    public int energy;
    public int vision = 30;

    public void setVision(int x)
    {
        vision = x;
    }
    public int getVision()
    {
        return (vision);
    }
    public void setFoodEaten(int x)
    {
        foodEaten = x;
    }
    public int getFoodEaten()
    {
        return (foodEaten);
    }
    public void setSpeed(int x)
    {
        speed = x;
    }
    public float getSpeed()
    {
        return (speed);
    }

    public void setEnergy(int x)
    {
        energy = x;
    }


}
