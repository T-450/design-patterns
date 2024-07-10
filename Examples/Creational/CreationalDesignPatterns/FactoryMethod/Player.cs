namespace CreationalDesignPatterns.FactoryMethod
{
    /// <summary>
    /// Target Object.
    /// Represents an abstract base class for audio players.
    /// </summary>
    internal abstract class Player
    {
        public abstract Task Play(string fileName);
    }
}