using System.IO;
using UnityEngine;

public class SaveManager
{
    private string _filePath;

    public SaveManager()
    {
        // Asignamos la ruta donde se guardará el JSON
        _filePath = Path.Combine(Application.persistentDataPath, "savegame.json");
    }

    // Carga el GameData desde disco. Si no existe el archivo, devuelve un GameData por defecto.
    public GameData Load()
    {
        if (File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);
            try
            {
                return JsonUtility.FromJson<GameData>(json);
            }
            catch
            {
                Debug.LogWarning("SaveManager: JSON mal formado, reiniciando GameData");
                return new GameData();
            }
        }
        else
        {
            // No existe el archivo de guardado; devolvemos datos limpios
            return new GameData();
        }
    }

    // Guarda el GameData actual en disco (sobre escribe).
    public void Save(GameData data)
    {
        string json = JsonUtility.ToJson(data, prettyPrint: true);
        try
        {
            File.WriteAllText(_filePath, json);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"SaveManager: Error al guardar GameData:\n{e}");
        }
    }
}
