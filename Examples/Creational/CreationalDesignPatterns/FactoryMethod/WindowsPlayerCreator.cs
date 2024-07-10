namespace CreationalDesignPatterns.FactoryMethod
{
    internal class WindowsPlayerCreator:PlayerCreator
    {
        public override Player CreatePlayer()
        {
            return new WindowsPlayer();
        }
    }
}