using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeadFactory : MonoBehaviour
{
    [SerializeField] GameObject beadPrefab; 

    [SerializeField] int beadCountToCreate;
    [SerializeField] int minUVBeadCount;
    [SerializeField] GameObject[] beads;
    [SerializeField] float spacing = 1.5f;
    [SerializeField] Vector3 creationPos = new Vector3(-12, 0, 25);
    System.Random rand = new System.Random(); //we specify System.Random because UnityEngine.Random does not generate random ints

    void Start()
    {
        
        beads = new GameObject[beadCountToCreate];

        for (int i=0; i<beadCountToCreate; i++)
        {
            beads[i] = Instantiate(beadPrefab, creationPos, Quaternion.identity);
            creationPos += new Vector3(spacing, 0, 0);

            ///newUV is true if the randomly generated int is 1 and false if its 0
            bool newUV = rand.Next(2) == 1 ? true : false; //we gotta alter this so that we ensure a minimum ammount of UV beads
            beads[i].GetComponent<Bead>().SetIsUV(newUV);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
