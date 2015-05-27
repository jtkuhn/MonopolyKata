using MonopolyKata.PropertySquares;
using MonopolyKata.PropertySquares.Properties;
using MonopolyKata.PropertySquares.Rent;
using Ninject.Modules;

namespace MonopolyKata.IOC
{
    public class PropertyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<Board>().ToSelf().InSingletonScope();
            Bind<IRentStrategy>().To<RentStrategyRailroad>().WhenInjectedInto<RailroadSquare>();
            Bind<IRentStrategy>().To<RentStrategyUtility>().WhenInjectedInto<UtilitySquare>();
            Bind<IRentStrategy>().To<RentStrategyMonopolizable>().WhenInjectedInto<MonopolizableProperty>();
        }
    }
}
