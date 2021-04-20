using UnityEngine.EventSystems;

namespace Assets.Scripts.EventSystems
{
    /// <summary>
    /// Used to catch when Medicine gets collected by the player
    /// </summary>
    public interface IMedicineCollectedHandler : IEventSystemHandler
    {
        /// <summary>
        /// When medicine gets collected
        /// </summary>
        /// <param name="Timer">the timer length that medicine effect will last</param>
        void OnMedicineCollected(int Timer);
    }
}
