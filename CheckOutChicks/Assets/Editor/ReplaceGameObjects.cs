using UnityEngine;
using System.Collections;
using UnityEditor;

public class ReplaceGameObjects : ScriptableWizard
{
    public GameObject useGameObject;

    [MenuItem("GameObject/Replace GameObjects", false, 0)]
    [MenuItem("Custom/Replace GameObjects")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Replace GameObjects", typeof(ReplaceGameObjects), "Replace");
    }

    void OnWizardCreate()
    {
        foreach (Transform t in Selection.transforms)
        {
            GameObject newObject = PrefabUtility.InstantiatePrefab(useGameObject) as GameObject;
            Transform newT = newObject.transform;

            newT.name = t.name;
            newT.position = t.position;
            newT.rotation = t.rotation;
            newT.localScale = t.localScale;
            newT.parent = t.parent;

        }

        foreach (GameObject go in Selection.gameObjects)
        {
            DestroyImmediate(go);
        }
    }
}
