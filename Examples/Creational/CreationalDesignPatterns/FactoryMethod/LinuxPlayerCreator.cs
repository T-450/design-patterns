namespace CreationalDesignPatterns.FactoryMethod
{
    internal class LinuxPlayerCreator : PlayerCreator
    {
        public override Player CreatePlayer()
        {
            return new LinuxPlayer();
        }
    }
}