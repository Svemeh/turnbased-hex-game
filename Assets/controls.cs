using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controls : MonoBehaviour
{

    [SerializeField] private Material highlightMaterial;
    
    private GameObject oldSelectedGameObject = null;

    private Renderer selectionRenderer;
    private Renderer oldSelectionRenderer;

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
            if (hit.collider.gameObject.tag == "Character")
            {
                GameObject selectedGameObject = hit.collider.gameObject; 
                Debug.Log("mousePressedOn " + selectedGameObject);

                if (selectedGameObject != oldSelectedGameObject)
                {
                    //Set original material to oldSelected if it's not the first selection
                    if (oldSelectedGameObject != null)
                    {
                        oldSelectionRenderer = oldSelectedGameObject.GetComponent<Renderer>();
                        oldSelectionRenderer.material = originalMaterial;
                    }

                    //Set highlighted material to selected
                    selectionRenderer = selectedGameObject.GetComponent<Renderer>();
                    originalMaterial = selectionRenderer.material;
                    selectionRenderer.material = highlightMaterial;

                    //assign oldSelected GO to your current selection
                    oldSelectedGameObject = selectedGameObject;
                }

                // selectedGameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            }
        }
    }
}
