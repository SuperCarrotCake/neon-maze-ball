using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    // Lista de niveles desbloqueados. Por defecto, comienza con el nivel 1 desbloqueado.
    public List<int> unlockedLevels = new List<int> { 1 };

    // Guarda el último nivel jugado (puede servir para reanudar).
    public int lastLevelPlayed = 0;

    // Aquí podrás agregar más campos en el futuro, como configuraciones de audio, puntuaciones, etc.
}
