using UnityEngine;

public static class ManagerVariables
{
    public static bool player;
    public static float length;
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        player = false;
        length = 10;
        Debug.Log("After Scene is loaded and game is running");
    }

}