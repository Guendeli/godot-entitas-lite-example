namespace GEntitas {

    public interface IAERC {

        int retainCount { get; }
        void Retain(object owner);
        void Release(object owner);
    }
}
