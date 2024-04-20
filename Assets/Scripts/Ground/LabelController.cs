using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

// ����'������ ������� ��� ������ � ����� Editor, ���� ������ ������� ���, ��� �� �ͲҲ ������ �� ����� ������� ���� ����� ������������ UnityEditor.EditorSnapSettings.move.x � ��Ĳ


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


            label.enabled = false;  // ������ ���������� ����̲ � �Ĳ��в �ͲҲ �� Ͳ
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
