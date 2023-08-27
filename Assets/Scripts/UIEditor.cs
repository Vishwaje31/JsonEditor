using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class UIEditor : EditorWindow
{
    Color selectedColor;

    [MenuItem("Window/Colorizer")]
    public static void ShowWindow()
    {
        GetWindow<UIEditor>("Colorizer");
    }


    private void OnGUI()
    {
        GUILayout.Label("Select any gameobject to Colorize it!!", EditorStyles.boldLabel);

        selectedColor = EditorGUILayout.ColorField("Color", selectedColor);     

        if (GUILayout.Button("COLORIZE!"))
        {
            foreach (var item in Selection.gameObjects)
            {
                var temp = item.GetComponent<SpriteRenderer>();

                if (temp)
                {
                    temp.color = selectedColor;
                }

            } 


        }
        
    }



}
