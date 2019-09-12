using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public float lifeDistance = 0.5f;
    private List<GameObject> lifes = new List<GameObject>();


    public void CreateLifes(int count)
    {
        GameObject firstLife = transform.GetChild(0).gameObject;
        lifes.Add(firstLife);

        if (firstLife == null)
        {
            Debug.Log("No lifes!");
        }

        for (int i = 0; i < count -1; i++)
        {
            GameObject life = Instantiate(firstLife);
            lifes.Add(life);
            life.transform.parent = transform;
            Vector3 position = life.transform.position;
            position.x += lifeDistance * (i + 1);
            life.transform.position = position;
        }
    }

    public bool RemoveLife()
    {
        if (lifes.Count < 0)
        {
            return false;
        }

        GameObject lastLife = lifes[lifes.Count -1];
        lifes.RemoveAt(lifes.Count -1);
        Destroy(lastLife);
        return true;
    }

}
