namespace Maze.Core.Maps.Decorators
{
    public interface IMapDecorator : IMapDecorator<IMap>
    {
        
    }

    public interface IMapDecorator<TMap> : IMap
        where TMap : IMap
    {
        TMap InnerMap { get; }
    }
}