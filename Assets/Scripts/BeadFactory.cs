using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeadFactory : MonoBehaviour
{
    [SerializeField] GameObject beadPrefab; 

    [SerializeField] int beadCountToCreate;
    [SerializeField] int minUVBeadCount; //MUST BE LESS THAN BEAD COUNT TO CREATE
    [SerializeField] GameObject[] beads;
    [SerializeField] float spacing = 1.5f;
    [SerializeField] Vector3 creationPos = new Vector3(-12, 0, 25);
    System.Random rand = new System.Random(); //we specify System.Random because UnityEngine.Random does not generate random ints

    //starting number of beads set to UV
    int currUVBeads;

    void Start()
    {
        currUVBeads = 0;

        beads = new GameObject[beadCountToCreate];

        for (int i=0; i<beadCountToCreate; i++)
        {
            beads[i] = Instantiate(beadPrefab, creationPos, Quaternion.identity);
            if(currUVBeads < minUVBeadCount)
            {
                beads[i].GetComponent<Bead>().SetIsUV(true);
                currUVBeads++;
            }
            //way of positioning beads at random spots, but right now i dont have a way to make sure they dont overlap
            creationPos.x = rand.Next(-12, 12);
            creationPos.y = rand.Next(-4, 5);

            /*
             * 
             * 
             * //until we get the min amound of UV beads, we keep turning a random one into UV
        while (currUVBeads < minUVBeadCount)
        {
            if(!beads[rand.Next(0, beadCountToCreate)].GetComponent<Bead>().GetIsUV())
            {
                beads[rand.Next(0, beadCountToCreate)].GetComponent<Bead>().SetIsUV(true);
                currUVBeads++;
            }
            
        }
             * An Alternative to the above method would be to:
             *  instantiate the beads outside of the screen with assigned UV vals such that we have a desired amount of UV
             *  then move their position to a random part of the screen
             * */
        }
    }

    void Update()
    {
        
    }
}
