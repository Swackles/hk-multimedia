using UnityEngine.EventSystems;

namespace Assets.Scripts.EventSystems
{
    /// <summary>
    /// Used to catch when Medicine gets collected by the player
    /// </summary>
    public interface IVaccineCollectedHandler : IEventSystemHandler
    {
        /// <summary>
        /// When vaccine gets collected
        /// </summary>
        /// <param name="Timer">the timer length that medicine effect will last</param>
        void OnVaccineCollected(int Timer);
    }
}
