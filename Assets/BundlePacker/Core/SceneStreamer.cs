using UnityEngine;
using UnityEngine.SceneManagement;
namespace BundlePacker.Core
{
    public static class SceneStreamer
    {
        public static string defaultLoadLevel;
        public static void LoadLevel(string level, string loadLevel = null)
        {
            if (string.IsNullOrWhiteSpace(loadLevel)) loadLevel = defaultLoadLevel;

            var loading = LoadLevelAsync(loadLevel, LoadSceneMode.Single);
            loading.completed += (_) => LoadLevelAsync(level, LoadSceneMode.Single);
        }

        public static AsyncOperation LoadLevelAsync(string level, LoadSceneMode mode)
        {
            var levelCrate = (LevelCrate)AssetWarehouse.crates[level];
            return SceneManager.LoadSceneAsync(levelCrate.scene, mode);
        }
    }
}