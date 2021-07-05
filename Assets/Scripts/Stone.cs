using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public Transform player;
    public GameObject[] zombies;

    private List<GameObject> clones;
    private GameObject zombie;
    private int num;
    private float timeToAappear, appearTimer;

    // Start is called before the first frame update
    private void Start()
    {
        clones = new List<GameObject>();
        timeToAappear = 30;
        appearTimer = Random.Range(0, timeToAappear);
    }

    // Update is called once per frame
    private void Update()
    {
        if (appearTimer > timeToAappear)
        {
            appearTimer = 0;
            num = Random.Range(0, zombies.Length);
            zombie = zombies[num];
            clones.Add(Instantiate(zombie, transform.position, Quaternion.identity) as GameObject);
            clones[clones.Count - 1].GetComponent<Zombie>().player = player;
        }
        else
        {
            appearTimer += Time.deltaTime;
        }
    }
}
