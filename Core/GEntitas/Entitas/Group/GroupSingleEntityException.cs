using System.Linq;

namespace GEntitas {

    public class GroupSingleEntityException : EntitasException {

        public GroupSingleEntityException(IGroup group)
            : base("Cannot get the single entity from " + group +
                "!\nGroup contains " + group.count + " entities:",
                string.Join("\n", group.GetEntities().Select(e => e.ToString()).ToArray())) {
        }
    }
}
