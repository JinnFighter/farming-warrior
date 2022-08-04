using UnityEngine;
using UnityEngine.AddressableAssets;

public class BootLoader : MonoBehaviour
{
    public async void LoadScene(string sceneName)
    {
        var handle = Addressables.LoadSceneAsync(sceneName);
        await handle.Task;
    }
}
