using Autofac;

namespace MonopolyKata
{
    public class Program
    {
        private static IContainer Container { get; set; }

        private static void main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Board>();
            builder.Register(c => new Realtor()).As<Realtor>();

        }
    }
}
