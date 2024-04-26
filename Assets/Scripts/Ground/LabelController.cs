using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

// Œ¡Œ¬'ﬂ« Œ¬Œ ¬»Õ≈—“» ÷≈… — –»œ“ ” œ¿œ ” Editor,  ŒÀ» ¡”ƒ≈ÃŒ ¡≤Àƒ»“» √–”, “¿  ﬂ  ﬁÕ≤“≤ œ–Œ—“Œ Õ≈ ƒ¿—“‹ «–Œ¡»“» ¡≤Àƒ ◊≈–≈« ¬» Œ–»—“¿ÕÕﬂ UnityEditor.EditorSnapSettings.move.x ¬  Œƒ≤


[RequireComponent(typeof(TextMeshPro))]
[ExecuteAlways]
public class LabelController : MonoBehaviour
{
    [Header("Color parameters")]
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.grey;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);

    TextMeshPro label;

    Vector2Int coordinates = new Vector2Int();

    GridManager gridManager;

   // Waypoint waipoint;


    void SetLabelColor() 
    {
        if (gridManager == null)
        {
            return;
        }
        else
        {
            Node node = gridManager.GetNode(coordinates);

            if (node == null)
            {
                return;
            }

            if (!node.isWalkable)
            {
                label.color = blockedColor;
            }
            else if (node.isPath)
            {
                label.color = pathColor;
            }
            else if (node.isExplored)
            {
                label.color = exploredColor;
            }
            else if (node.isWalkable)
            {
                label.color = defaultColor;
            }



        }


     /*   if (waipoint.IsItPath)
        {
            label.color = blockedColor;
        }
        else
        {
            label.color = defaultColor;
        }
        */

    }


    void ToggleCoordinate() 
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    
    }

    private void Awake()
    {

        gridManager = FindObjectOfType<GridManager>();

        label = GetComponent<TextMeshPro>();
        label.enabled = false;


       // waipoint = GetComponentInParent<Waypoint>();

        DisplayCoordinates();

        DisplayName();

    }

    void Start()
    {
        
    }

    
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            DisplayName();


            label.enabled = true;  // ·”ƒ”“‹  ŒŒ–ƒ»Õ¿“» ¬»ƒ»Ã≤ ¬ ≈ƒ≤“Œ–≤ ﬁÕ≤“≤ ◊» Õ≤
        }

        SetLabelColor();
        ToggleCoordinate();
    }


    void DisplayCoordinates() 
    {

        if (gridManager == null)
        {
            return;
        }

        coordinates.x = Mathf.RoundToInt(transform.position.x / gridManager.UnityGridSize);
        coordinates.y = Mathf.RoundToInt(transform.position.z / gridManager.UnityGridSize);


        label.text = coordinates.x + "," + coordinates.y ;
    }


    void DisplayName() 
    {

        transform.parent.name = coordinates.ToString();
    
    }
}
