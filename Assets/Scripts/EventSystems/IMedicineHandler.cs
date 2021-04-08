using UnityEngine.EventSystems;

namespace Assets.Scripts.EventSystems
{
    /// <summary>
    /// Used to catch when Medicine gets collected by the player
    /// </summary>
    public interface IMedicineCollectedHandler : IEventSystemHandler
    {
        void OnMedicineCollected();
    }

    /// <summary>
    /// Used to catch when Medicine is missed by the player
    /// </summary>
    public interface IMedicineMissedHandler : IEventSystemHandler
    {
        void OnMedicineMissed();
    }
}
