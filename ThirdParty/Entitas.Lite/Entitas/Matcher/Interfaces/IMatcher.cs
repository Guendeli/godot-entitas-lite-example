namespace GEntitas {

    public interface IMatcher {

        int[] indices { get; }
        bool Matches(Entity entity);
    }
}
