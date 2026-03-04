using UnityEngine;
using UnityEditor;
using System.IO;

public class MaterialVariantGenerator
{
    private const string sourceFolder = "Assets/Materials/Rainbow"; // Change this
    private const string variantFolderName = "Variants";

    [MenuItem("Tools/Generate Color Variants")]
    public static void GenerateVariants()
    {
        if (!AssetDatabase.IsValidFolder(sourceFolder))
        {
            Debug.LogError("Source folder not found: " + sourceFolder);
            return;
        }

        string variantFolderPath = Path.Combine(sourceFolder, variantFolderName);

        if (!AssetDatabase.IsValidFolder(variantFolderPath))
        {
            AssetDatabase.CreateFolder(sourceFolder, variantFolderName);
        }

        string[] materialGUIDs = AssetDatabase.FindAssets("t:Material", new[] { sourceFolder });

        foreach (string guid in materialGUIDs)
        {
            string materialPath = AssetDatabase.GUIDToAssetPath(guid);

            // Skip materials already inside Variants folder
            if (materialPath.Contains(variantFolderName))
                continue;

            Material baseMaterial = AssetDatabase.LoadAssetAtPath<Material>(materialPath);
            if (baseMaterial == null)
                continue;

            CreateVariant(baseMaterial, variantFolderPath, "Red", Color.red);
            CreateVariant(baseMaterial, variantFolderPath, "Orange", Color.orange);
            CreateVariant(baseMaterial, variantFolderPath, "Yellow", Color.yellow);
            CreateVariant(baseMaterial, variantFolderPath, "Green", Color.green);
            CreateVariant(baseMaterial, variantFolderPath, "Blue", Color.blue);
            CreateVariant(baseMaterial, variantFolderPath, "Purple", Color.purple);
            CreateVariant(baseMaterial, variantFolderPath, "Gray", Color.gray);
        }

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("Material variants generated successfully.");
    }

    private static void CreateVariant(Material baseMaterial, string folderPath, string colorName, Color color)
    {
        string variantName = $"{baseMaterial.name}_{colorName}.mat";
        string variantPath = Path.Combine(folderPath, variantName);

        if (File.Exists(variantPath))
        {
            Debug.LogWarning($"Variant already exists: {variantName}");
            return;
        }

        // Create material variant
        Material variant = new Material(baseMaterial);
        variant.parent = baseMaterial;

        // Set color property (_Color for Standard/URP Lit)
        if (variant.HasProperty("_BaseColor"))
        {
            variant.SetColor("_BaseColor", color);
        }
        if (variant.HasProperty("_EmissionColor"))
        {
            variant.SetColor("_EmissionColor", color);
        }

        AssetDatabase.CreateAsset(variant, variantPath);
    }
}
