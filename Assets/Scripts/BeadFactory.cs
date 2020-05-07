using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeadFactory : MonoBehaviour
{
    [Tooltip("Prefab of the objects we will be instantiaiting")]
    [SerializeField] GameObject beadPrefab; 

    [Tooltip("Amount of beads we will create")]
    [SerializeField] int beadCountToCreate;
    [Tooltip("Amount of created beads that will be UV. MUST BE LESS THAN BEAD COUNT TO CREATE")]
    [SerializeField] int minUVBeadCount;
    [Tooltip("array that holds all the created beads")]
    [SerializeField] GameObject[] beads;
    [Tooltip("Currently Unused. Minimum space that there must be between the beads")] [SerializeField] float spacing = 1.5f;
    [Tooltip("position where the first bead will be created")]
    [SerializeField] Vector3 creationPos = new Vector3(-12, 0, 25); //might want to make this random within the specified range
    //horizontal and vertical range where beads could spawn respectively
    [SerializeField] int HorizontalLimit = 8;
    [SerializeField] int VerticalLimit = 4;

    //random generator
    System.Random rand = new System.Random(); //we specify System.Random because UnityEngine.Random does not generate random ints
    //starting number of beads set to UV
    int currUVBeads;

    void Start()
    {
        //initialize current UV bead count
        currUVBeads = 0;

        //initialize bead array
        beads = new GameObject[beadCountToCreate];

        //create the specified amount of beads
        for (int i=0; i<beadCountToCreate; i++)
        {
            //creates the beads at the desired position and the desired rotation
            beads[i] = Instantiate(beadPrefab, creationPos, Quaternion.identity);
            //while we dont have our desired minimum amount of UV beads change them to UV and increment the UVBead count
            if(currUVBeads < minUVBeadCount)
            {
                beads[i].GetComponent<Bead>().SetIsUV(true);
                currUVBeads++;
            }
            //way of positioning beads at random spots, but right now i dont have a way to make sure they dont overlap
            creationPos.x = rand.Next(-HorizontalLimit, HorizontalLimit+1);
            creationPos.y = rand.Next(-VerticalLimit, VerticalLimit + 1);

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
