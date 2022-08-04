using Zenject;

namespace FarmingWarrior
{
    public class HubInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInputActions();
        }

        private void BindInputActions()
        {
            Container.Bind<InputActions>().AsSingle();
        }
    }
}
