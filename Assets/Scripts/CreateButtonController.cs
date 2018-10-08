using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.EventSystems;

public class CreateButtonController : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    public Button createButton;

    public Button prefabToInstantiate;

    public GridLayoutGroup grid;

    private int id = 0;

    private Color[] buttonColors = new Color[4] { Color.red, Color.green, Color.blue, Color.yellow };

    void Start()
    {
        Button button = createButton.GetComponent<Button>();
        button.onClick.AddListener(CreateButtonClick);
        // for (int i = 0; i < 36; i++)
        // {
        //     CreateButtonClick();
        // }
    }

    void CreateButtonClick()
    {
        Debug.Log("You have clicked the create button!");
        // Button instantiated = Instantiate<Button>(prefabToInstantiate);
        Button instantiated = PrefabUtility.InstantiatePrefab(prefabToInstantiate) as Button;
        instantiated.name = "Button " + id.ToString();
        instantiated.transform.SetParent(grid.transform, false);
        instantiated.onClick.AddListener(delegate { InstantiatedClick(); } );
        // var colors = instantiated.colors;
        // colors.normalColor = buttonColors[id % 4];
        // instantiated.colors = colors;
        // id++;
    }

    void InstantiatedClick()
    {
        GameObject go = EventSystem.current.currentSelectedGameObject;
        Debug.Log("Instantiated click" + go.name + "!");
    }
}