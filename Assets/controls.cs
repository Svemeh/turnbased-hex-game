using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour
{

    [SerializeField] private Material highlightMaterial;
    
    private GameObject previouslySelectedGameObject = null;
    

    private Renderer SelectedRenderer;
    private Renderer previouslySelectedRenderer;

    private Material originalMaterial;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetMouseButtonDown(0))
        {

            // gets mouse cordiantes in vector2
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousepos2D = new Vector2(mousePos.x, mousePos.y);


            // finds object intercepting mouse raycast & checks if object is selectable
            RaycastHit2D hit = Physics2D.Raycast(mousepos2D, Vector2.zero);
            if (hit.collider.gameObject.tag == "Selectable")
            {
                GameObject selectedGameObject = hit.collider.gameObject; 
                Debug.Log("mousePressedOn " + selectedGameObject);

                if (selectedGameObject != previouslySelectedGameObject)
                {
                    //Set original material to oldSelected if it's not the first selection
                    if (previouslySelectedGameObject != null)
                    {
                        previouslySelectedRenderer = previouslySelectedGameObject.GetComponent<Renderer>();
                        previouslySelectedRenderer.material = originalMaterial;
                    }

                    //Set highlighted material to selected
                    SelectedRenderer = selectedGameObject.GetComponent<Renderer>();
                    originalMaterial = SelectedRenderer.material;
                    SelectedRenderer.material = highlightMaterial;

                    //assign oldSelected GO to your current selection
                    previouslySelectedGameObject = selectedGameObject;
                }

                // selectedGameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }
    }
}
