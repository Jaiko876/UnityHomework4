using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Homework7 : EditorWindow
{
    public static GameObject ObjectInstantiate;
    private void OnGUI()
    {
        GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);
        ObjectInstantiate =
            EditorGUILayout.ObjectField("Объект который хотим вставить",
                    ObjectInstantiate, typeof(GameObject), true)
                as GameObject;
        var colorField = EditorGUILayout.ColorField("color", Color.cyan);
        var button = GUILayout.Button("Применить");
        if (button)
        {
            if (ObjectInstantiate)
            {
                var component = ObjectInstantiate.GetComponent<Renderer>();
                component.sharedMaterial.color = colorField;
            }
        }
    }
}
public class MenuItems
{
    [MenuItem("Homework7/Homework7")]
    private static void MenuOption()
    {
        EditorWindow.GetWindow(typeof(Homework7), false, "ДЗ 7");
    }
}