using UnityEngine;
using UnityEditor;
using System.IO;

public class ConvertMaterialsToURP : EditorWindow
{
    private string targetFolder = "Assets/"; // Đường dẫn folder chứa materials

    [MenuItem("Tools/Convert Materials to URP (Keep Color & Texture)")]
    public static void ShowWindow()
    {
        GetWindow(typeof(ConvertMaterialsToURP));
    }

    private void OnGUI()
    {
        GUILayout.Label("Chuyển đổi Materials sang URP/Lit", EditorStyles.boldLabel);

        targetFolder = EditorGUILayout.TextField("Folder:", targetFolder);

        if (GUILayout.Button("Convert"))
        {
            ConvertMaterials(targetFolder);
        }
    }

    private static void ConvertMaterials(string folderPath)
    {
        string[] guids = AssetDatabase.FindAssets("t:Material", new[] { folderPath });

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            Material mat = AssetDatabase.LoadAssetAtPath<Material>(path);

            if (mat != null)
            {
                Debug.Log("Đang chuyển: " + mat.name);

                // Lưu thông tin cũ
                Texture mainTex = mat.HasProperty("_MainTex") ? mat.GetTexture("_MainTex") : null;
                Color color = mat.HasProperty("_Color") ? mat.GetColor("_Color") : Color.white;
                Texture emissionTex = mat.HasProperty("_EmissionMap") ? mat.GetTexture("_EmissionMap") : null;
                Color emissionColor = mat.HasProperty("_EmissionColor") ? mat.GetColor("_EmissionColor") : Color.black;

                // Chuyển shader sang URP
                mat.shader = Shader.Find("Universal Render Pipeline/Lit");

                // Gán lại texture & color
                if (mainTex != null) mat.SetTexture("_BaseMap", mainTex);
                mat.SetColor("_BaseColor", color);

                if (emissionTex != null) mat.SetTexture("_EmissionMap", emissionTex);
                if (emissionColor != Color.black) mat.SetColor("_EmissionColor", emissionColor);

                EditorUtility.SetDirty(mat);
            }
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("Hoàn tất chuyển đổi Materials trong: " + folderPath);
    }
}
