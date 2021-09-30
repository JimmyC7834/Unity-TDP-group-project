using UnityEngine;
using UnityEngine.Events;

// [CreateAssetMenu(menuName = "EventChannel/LoadSceneEventChannelSO")]
// commented as only one LoadSceneEventChannelSO needed
public class LoadSceneEventChannelSO : EventChannelSO
{
    public UnityAction<GameSceneSO[], bool> OnLoadingRequested;

    public void RaiseEvent(GameSceneSO[] scene, bool showLoadingScreen = false)
    {
        if (OnLoadingRequested != null)
        {
            OnLoadingRequested.Invoke(scene, showLoadingScreen);
        }
        else
        {
            Debug.LogWarning("A Scene loading was requested, but nobody picked it up. " +
                "Check why there is no SceneLoader already present, " +
                "and make sure it's listening on this Load Event channel.");
        }
    }
}
