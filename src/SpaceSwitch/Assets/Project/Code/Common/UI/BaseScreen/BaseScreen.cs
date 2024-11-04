namespace Project.Code.Common.UI.BaseScreen
{
    public abstract class BaseScreen : CommonScreen
    {
        public abstract void SetupOnInstantiate();
    }

    public abstract class BaseScreen<TArg> : CommonScreen
    {
        public abstract void SetupOnInstantiate(TArg arg);
    }
}