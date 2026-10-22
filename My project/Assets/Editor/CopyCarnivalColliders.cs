using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class CopyCarnivalColliders
{
    [MenuItem("Tools/Copy Carnival Colliders")]
    public static void CopyColliders()
    {
        string backupPath = "Assets/Scenes/Carnival_Colliders_Backup.unity";
        string targetPath = "Assets/Scenes/Carnival.unity";

        Scene backupScene = EditorSceneManager.OpenScene(
            backupPath,
            OpenSceneMode.Single
        );

        GameObject backupRoot = FindObject(backupScene, "CarnivalArea");

        if (backupRoot == null)
        {
            Debug.LogError("Could not find CarnivalArea in backup scene.");
            return;
        }

        Scene targetScene = EditorSceneManager.OpenScene(
            targetPath,
            OpenSceneMode.Additive
        );

        GameObject targetRoot = FindObject(targetScene, "CarnivalArea");

        if (targetRoot == null)
        {
            Debug.LogError("Could not find CarnivalArea in target scene.");
            return;
        }

        int copied = CopyRecursive(backupRoot.transform, targetRoot.transform);

        EditorSceneManager.MarkSceneDirty(targetScene);
        EditorSceneManager.SaveScene(targetScene);

        Debug.Log("Finished copying colliders. Copied: " + copied);
    }

    private static int CopyRecursive(Transform source, Transform target)
    {
        int count = 0;

        Collider[] sourceColliders = source.GetComponents<Collider>();

        foreach (Collider sourceCollider in sourceColliders)
        {
            if (target.GetComponent(sourceCollider.GetType()) != null)
                continue;

            UnityEditorInternal.ComponentUtility.CopyComponent(sourceCollider);
            UnityEditorInternal.ComponentUtility.PasteComponentAsNew(target.gameObject);

            count++;
        }

        foreach (Transform sourceChild in source)
        {
            Transform targetChild = target.Find(sourceChild.name);

            if (targetChild != null)
            {
                count += CopyRecursive(sourceChild, targetChild);
            }
        }

        return count;
    }

    private static GameObject FindObject(Scene scene, string name)
    {
        foreach (GameObject root in scene.GetRootGameObjects())
        {
            Transform found = FindRecursive(root.transform, name);

            if (found != null)
                return found.gameObject;
        }

        return null;
    }

    private static Transform FindRecursive(Transform parent, string name)
    {
        if (parent.name == name)
            return parent;

        foreach (Transform child in parent)
        {
            Transform found = FindRecursive(child, name);

            if (found != null)
                return found;
        }

        return null;
    }
}