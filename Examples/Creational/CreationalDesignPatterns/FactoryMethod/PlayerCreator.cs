namespace CreationalDesignPatterns.FactoryMethod
{
    /// <summary>
    /// Abstract Factory object.
    /// Represents an abstract base class for player creators.
    /// </summary>
    internal abstract class PlayerCreator
    {
        public abstract Player CreatePlayer();
    }
}