using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
namespace Project.Code.Common.Extra.Helpers
{
    [InitializeOnLoad]
    public static class LoadBootstrapperScene
    {
        private const string PreviousScenePath = "PREVIOUS_SCENE";

        static LoadBootstrapperScene() =>
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;

        private static void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            if (!EditorApplication.isPlaying && EditorApplication.isPlayingOrWillChangePlaymode)
            {
                string currentPath = SceneManager.GetActiveScene().path;
                EditorPrefs.SetString(PreviousScenePath, currentPath);
        
                if (SceneManager.GetActiveScene().buildIndex == 0)
                    return;
        
                if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                {
                    string path = EditorBuildSettings.scenes[0].path;
                    try
                    {
                        EditorSceneManager.OpenScene(path);
                    }
                    catch(Exception e)
                    {
                        EditorApplication.isPlaying = false;
                        EditorApplication.ExitPlaymode();
                        Debug.LogError($"Cant load boot scene, because of {e}");
                    }
                }
                else
                {
                    EditorApplication.isPlaying = false;
                }
            }
        
            if (!EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode)
            {
                string path = EditorPrefs.GetString(PreviousScenePath);
                if (SceneManager.GetActiveScene().path == path)
                    return;
        
                try
                {
                    EditorSceneManager.OpenScene(path);
                }
                catch
                {
                    Debug.LogError($"Cant load scene { path }");
                    Application.Quit();
                    EditorApplication.isPlaying = false;
                }
            }
        }
    }
}
#endif