using _Source.Abstract;
using _Source.FirstScreen;
using _Source.SecondScreen;
using _Source.Services;
using UnityEngine;

namespace _Source.Main
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private MainScreenView mainScreenView;
        [SerializeField] private PanelView panelView;
        [SerializeField] private Score score;

        [SerializeField] private AudioClip openSound;
        [SerializeField] private AudioClip closeSound;

        private void Awake()
        {
            var serviceLocator = new ServiceLocator(audioSource, openSound, closeSound);
            var fadeService = serviceLocator.GetService<IFadeService>();
            var soundPlayer = serviceLocator.GetService<ISoundPlayer>();
            var saver = serviceLocator.GetService<ISaver>();

            var uiSwitcher = new UISwitcher();

            var mainScreenController = new MainScreenController(mainScreenView, uiSwitcher);
            var panelController = new PanelController(panelView, uiSwitcher, fadeService, soundPlayer, saver, score);

            uiSwitcher.RegisterState<MainScreenController>(mainScreenController);
            uiSwitcher.RegisterState<PanelController>(panelController);

            uiSwitcher.SwitchState<MainScreenController>();
        }
    }
}