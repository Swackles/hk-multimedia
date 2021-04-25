using Assets.Scripts.Entity;

namespace Assets.Scripts.EventSystems
{
    public interface IPlayerDeathHandler
    {
        void OnPlayerDeath(Player player);
    }
}
