namespace CreationalDesignPatterns.FactoryMethod
{
    /// <summary>
    /// Concrete Factory object.
    /// Represents a creator for Windows audio players.
    /// </summary>
    internal class WindowsPlayerCreator:PlayerCreator
    {
        public override Player CreatePlayer()
        {
            return new WindowsPlayer();
        }
    }
}