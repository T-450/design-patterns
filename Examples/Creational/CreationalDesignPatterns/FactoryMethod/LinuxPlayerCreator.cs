namespace CreationalDesignPatterns.FactoryMethod
{
    /// <summary>
    /// Concrete Factory object.
    /// Represents a creator for Linux audio players.
    /// </summary>
    internal class LinuxPlayerCreator : PlayerCreator
    {
        public override Player CreatePlayer()
        {
            return new LinuxPlayer();
        }
    }
}