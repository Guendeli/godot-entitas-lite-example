using System.Linq;

namespace GEntitas {

    public class ContextStillHasRetainedEntitiesException : EntitasException {

        public ContextStillHasRetainedEntitiesException(IContext context, IEntity[] entities)
            : base("'" + context + "' detected retained entities " +
                "although all entities got destroyed!",
                "Did you release all entities? Try calling systems.ClearReactiveSystems()" +
                "before calling context.DestroyAllEntities() to avoid memory leaks.\n" +
                string.Join("\n", entities
                    .Select(e => {
                        var safeAerc = e.aerc as SafeAERC;
                        if (safeAerc != null) {
                            return e + " - " + string.Join(", ", safeAerc.owners
                                       .Select(o => o.ToString())
                                       .ToArray());
                        }

                        return e.ToString();
                    })
                    .ToArray()
                )
            ) {
        }
    }
}
