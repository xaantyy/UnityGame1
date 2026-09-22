using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private InputProvider _inputProvider;
    [SerializeField] private ScoreManager _scoraManager;

    public override void InstallBindings()
    {
        Container.Bind<InputProvider>().FromInstance(_inputProvider).AsSingle();
        Container.Bind<InputService>().AsSingle();
        Container.Bind<ScoreManager>().FromInstance(_scoraManager).AsSingle();
    }
}