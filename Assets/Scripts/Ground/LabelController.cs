using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

// нанб'ъгйнбн бхмеярх жеи яйпхор с оюойс Editor, йнкх асделн а╡кдхрх цпс, рюй ъй чм╡р╡ опнярн ме дюярэ гпнахрх а╡кд вепег бхйнпхярюммъ UnityEditor.EditorSnapSettings.move.x б йнд╡


[RequireComponent(typeof(TextMeshPro))]
[ExecuteAlways]
public class LabelController : MonoBehaviour
{
    [Header("Color parameters")]
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.grey;

    TextMeshPro label;

    Vector2Int coordinates = new Vector2Int();

    Waypoint waipoint;


    void SetLabelColor() 
    {
        if (waipoint.IsItPath)
        {
            label.color = blockedColor;
        }
        else
        {
            label.color = defaultColor;
        }
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

        label = GetComponent<TextMeshPro>();
        label.enabled = false;


        waipoint = GetComponentInParent<Waypoint>();

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


            label.enabled = false;  // Асдсрэ йннпдхмюрх бхдхл╡ б ед╡рнп╡ чм╡р╡ вх м╡
        }

        SetLabelColor();
        ToggleCoordinate();
    }


    void DisplayCoordinates() 
    {

        coordinates.x = Mathf.RoundToInt(transform.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.position.z / UnityEditor.EditorSnapSettings.move.z);


        label.text = coordinates.x + "," + coordinates.y ;
    }


    void DisplayName() 
    {

        transform.parent.name = coordinates.ToString();
    
    }
}
