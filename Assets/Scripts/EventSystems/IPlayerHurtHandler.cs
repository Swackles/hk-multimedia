namespace Assets.Scripts.EventSystems
{
    interface IPlayerHurtHandler
    {
        /// <summary>
        /// Called when player gets hurt
        /// </summary>
        /// <param name="oldHealth">The player hp before getting hurt</param>
        /// <param name="newHealth">The player hp after getting hurt</param>
        void OnPlayerHurt(int oldHealth, int newHealth);
    }
}
