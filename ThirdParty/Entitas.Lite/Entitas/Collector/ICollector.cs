using System.Collections.Generic;

namespace GEntitas {

    public interface ICollector {

        int count { get; }

		void Activate();
		void Deactivate();
		void ClearCollectedEntities();

        IEnumerable<Entity> GetCollectedEntities();

		HashSet<Entity> collectedEntities { get; }
	}
}
