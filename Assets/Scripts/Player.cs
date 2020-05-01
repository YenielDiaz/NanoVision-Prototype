using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] Object currentTarget;
    [SerializeField] Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        //Only works if we will end up with one canvas
        canvas = FindObjectOfType<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        //we might have to do something with touch phase


        if(Input.touchCount > 0)//if (Input.GetMouseButtonDown(0))
        {
            Touch touch = Input.GetTouch(0);
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(touch.position);//(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                //Check if the object clicked on is interactable by putting it in a variable and see if its null
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                    //We set the interactable to be our current target
                    currentTarget = interactable;
                    //We start the temp coroutine that temporarily increases target size
                    StartCoroutine(ScaleMe(hit.transform));
                    // Message to show which object was clicked on
                    Debug.Log("You selected the " + hit.transform.name);

                    if(canvas != null)
                    {
                        showDialogue(canvas.GetComponent<InteractionCanvas>());
                    }
                    
                }

                
            }
        }

    }

    IEnumerator ScaleMe(Transform objTr)
    {
        objTr.localScale *= 1.2f;
        yield return new WaitForSeconds(0.5f);
        objTr.localScale /= 1.2f;
    }

    //function to show dialogue box
    void showDialogue(InteractionCanvas intCanvas)
    {
        intCanvas.ShowBox();
        //intCanvas.DestroyBox();
    }
}
