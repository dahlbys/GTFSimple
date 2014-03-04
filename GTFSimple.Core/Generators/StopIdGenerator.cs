using GTFSimple.Core.Input;

namespace GTFSimple.Core.Generators
{
    public interface IStopIdGenerator
    {
        string Generate(RouteStop rs);
    }

    public class SequentialStopIdGenerator : IStopIdGenerator
    {
        private readonly string format;
        private int nextId;

        public SequentialStopIdGenerator(int digits)
        {
            format = new string('0', digits);
        }

        public string Generate(RouteStop rs)
        {
            return (nextId++).ToString(format);
        }
    }
}