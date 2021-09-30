using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;

public class SceneLoader : MonoBehaviour
{
    // TODO: complete load main menu
    // [SerializeField] private BattleSceneSO _battleScene = default;

    [Header("Event Channels")]
    [SerializeField] private LoadSceneEventChannelSO _loadScenesEvent = default;
    // [SerializeField] private LoadBattleEventChannelSO _loadBattleEvent = default;

    [Header("Broadcasting on")]
    [SerializeField] private BoolEventChannelSO _toggleLoadingScreen = default;
    [SerializeField] private VoidEventChannelSO _onScenesReady = default;

	private List<AsyncOperationHandle<SceneInstance>> _loadingOperationHandles = new List<AsyncOperationHandle<SceneInstance>>();

	private AsyncOperationHandle<SceneInstance> _gameplayManagerLoadingOpHandle;

    // parameters coming from scene loading requests
    private GameSceneSO[] _scenesToLoad;
    private GameSceneSO[] _currentlyLoadedScenes = new GameSceneSO[] { };
    private bool _showLoadingScreen;

    private void OnEnable() {
        _loadScenesEvent.OnLoadingRequested += LoadScene;
        // _loadBattleEvent.OnLoadBattleRequested += LoadBattleScene;
    }

    // private void LoadBattleScene(Data.BattleData data)
    // {
    //     _battleScene.battleData = data;
    //     _scenesToLoad = new GameSceneSO[] { _battleScene };
    //     _showLoadingScreen = true;

    //     StartCoroutine(LoadingProcess(_scenesToLoad, _showLoadingScreen));
    // }

    private void LoadScene(GameSceneSO[] scenesToLoad, bool showLoadingScreen)
    {
        _scenesToLoad = scenesToLoad;
        _showLoadingScreen = showLoadingScreen;

        StartCoroutine(LoadingProcess(scenesToLoad, showLoadingScreen));
    }

    private IEnumerator LoadingProcess(GameSceneSO[] scenesToLoad, bool showLoadingScreen)
    {
        // TODO: to load gameplay managers
        // _gameplayManagerLoadingOpHandle = _battleScene.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true);
        // while (_gameplayManagerLoadingOpHandle.Status != AsyncOperationStatus.Succeeded)
        // {
        //     yield return null;
        // }

        yield return null;
        UnloadPreviousScenes();
    }

    private void UnloadPreviousScenes()
    {
        for (int i = 0; i < _currentlyLoadedScenes.Length; i++)
		{
			_currentlyLoadedScenes[i].sceneReference.UnLoadScene();
		}

        LoadNewScenes();
    }

    private void LoadNewScenes() {
        if (_showLoadingScreen) {
            _toggleLoadingScreen.RaiseEvent(true);
        }

        _loadingOperationHandles.Clear();
        //Build the array of handles of the temporary scenes to load
		for (int i = 0; i < _scenesToLoad.Length; i++)
		{
			_loadingOperationHandles.Add(_scenesToLoad[i].sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true, 0));
		}

        StartCoroutine(LoadingProcess());
    }

    private IEnumerator LoadingProcess() {
        bool done = _loadingOperationHandles.Count == 0;

        while (!done)
        {
            for (int i = 0; i < _loadingOperationHandles.Count; ++i)
			{
				if (_loadingOperationHandles[i].Status != AsyncOperationStatus.Succeeded)
				{
					break;
				}

                done = true;
			}

            yield return null;
        }

        // save loaded to be unloaded in next request;
        _currentlyLoadedScenes = _scenesToLoad;
        SetActiveScene();
    }

    // called when all scenes have been loaded
    private void SetActiveScene()
    {
		//All the scenes have been loaded, so we assume the first in the array is ready to become the active scene
        SceneManager.SetActiveScene(((SceneInstance)_loadingOperationHandles[0].Result).Scene);

        _onScenesReady.RaiseEvent();
    }

    private void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit!");
    }
}
