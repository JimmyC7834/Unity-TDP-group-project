using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

// <summary>
// This class responsible for starting the game by loading the manager scene
// Flow: basic settings(temp) -> managers scene -> menu scene
// </summary>
public class InitializationLoader : MonoBehaviour
{
    [SerializeField] private GameSceneSO _managerScene = default;
    [SerializeField] private GameSceneSO[] _startingScene = default;
    [SerializeField] private AssetReference _loadSceneChannel = default;

    private void Start() {
        // --temporary settings--
        Application.targetFrameRate = 60;

        _managerScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true).Completed += LoadSceneEventChannelSO;
    }

    private void LoadSceneEventChannelSO(AsyncOperationHandle<SceneInstance> obj) {
        _loadSceneChannel.LoadAssetAsync<LoadSceneEventChannelSO>().Completed += LoadBattleTestScene;
    }

    private void LoadBattleTestScene(AsyncOperationHandle<LoadSceneEventChannelSO> obj) {
        obj.Result.RaiseEvent(_startingScene, false);

        // unload this scene after initialization
        SceneManager.UnloadSceneAsync(0);
    }
}
