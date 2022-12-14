namespace GEntitas {

    public interface ICompoundMatcher : IMatcher {

        int[] allOfIndices { get; }
        int[] anyOfIndices { get; }
        int[] noneOfIndices { get; }
    }
}
