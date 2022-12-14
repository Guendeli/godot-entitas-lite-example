using System.Collections;
using System.Collections.Generic;

namespace GEntitas {

    /// Use context.GetGroup(matcher) to get a group of entities which match
    /// the specified matcher. Calling context.GetGroup(matcher) with the
    /// same matcher will always return the same instance of the group.
    /// The created group is managed by the context and will always be up to date.
    /// It will automatically add entities that match the matcher or
    /// remove entities as soon as they don't match the matcher anymore.
    public class Group : IGroup {

        /// Occurs when an entity gets added.
        public event GroupChanged OnEntityAdded;

        /// Occurs when an entity gets removed.
        public event GroupChanged OnEntityRemoved;

        /// Occurs when a component of an entity in the group gets replaced.
        public event GroupUpdated OnEntityUpdated;

        /// Returns the number of entities in the group.
        public int count { get { return _entities.Count; } }

        /// Returns the matcher which was used to create this group.
        public IMatcher matcher { get { return _matcher; } }

        readonly IMatcher _matcher;

        readonly HashSet<Entity> _entities = new HashSet<Entity>(
            EntityEqualityComparer.comparer
        );

        Entity[] _entitiesCache;
        Entity _singleEntityCache;
        string _toStringCache;

        /// Use context.GetGroup(matcher) to get a group of entities which match
        /// the specified matcher.
        public Group(IMatcher matcher) {
            _matcher = matcher;
        }

        /// This is used by the context to manage the group.
        public void HandleEntitySilently(Entity entity) {
            if (_matcher.Matches(entity)) {
                addEntitySilently(entity);
            } else {
                removeEntitySilently(entity);
            }
        }

        /// This is used by the context to manage the group.
        public void HandleEntity(Entity entity, int index, IComponent component) {
            if (_matcher.Matches(entity)) {
                addEntity(entity, index, component);
            } else {
                removeEntity(entity, index, component);
            }
        }

        /// This is used by the context to manage the group.
        public void UpdateEntity(Entity entity, int index, IComponent previousComponent, IComponent newComponent) {
            if (_entities.Contains(entity)) {
                if (OnEntityRemoved != null) {
                    OnEntityRemoved(this, entity, index, previousComponent);
                }
                if (OnEntityAdded != null) {
                    OnEntityAdded(this, entity, index, newComponent);
                }
                if (OnEntityUpdated != null) {
                    OnEntityUpdated(this, entity, index, previousComponent, newComponent);
                }
            }
        }

        /// This is called by context.Reset() to remove all event handlers.
        /// This is useful when you want to soft-restart your application.
        public void RemoveAllEventHandlers() {
            OnEntityAdded = null;
            OnEntityRemoved = null;
            OnEntityUpdated = null;
        }

        public GroupChanged HandleEntity(Entity entity) {
            return _matcher.Matches(entity)
                       ? (addEntitySilently(entity) ? OnEntityAdded : null)
                       : (removeEntitySilently(entity) ? OnEntityRemoved : null);
        }

        bool addEntitySilently(Entity entity) {
            if (entity.isEnabled) {
                var added = _entities.Add(entity);
                if (added) {
                    _entitiesCache = null;
                    _singleEntityCache = null;
                    entity.Retain(this);
                }

                return added;
            }

            return false;
        }

        void addEntity(Entity entity, int index, IComponent component) {
            if (addEntitySilently(entity) && OnEntityAdded != null) {
                OnEntityAdded(this, entity, index, component);
            }
        }

        bool removeEntitySilently(Entity entity) {
            var removed = _entities.Remove(entity);
            if (removed) {
                _entitiesCache = null;
                _singleEntityCache = null;
                entity.Release(this);
            }

            return removed;
        }

        void removeEntity(Entity entity, int index, IComponent component) {
            var removed = _entities.Remove(entity);
            if (removed) {
                _entitiesCache = null;
                _singleEntityCache = null;
                if (OnEntityRemoved != null) {
                    OnEntityRemoved(this, entity, index, component);
                }
                entity.Release(this);
            }
        }

        /// Determines whether this group has the specified entity.
        public bool ContainsEntity(Entity entity) {
            return _entities.Contains(entity);
        }

        /// Returns all entities which are currently in this group.
        public Entity[] GetEntities() {
            if (_entitiesCache == null) {
                _entitiesCache = new Entity[_entities.Count];
                _entities.CopyTo(_entitiesCache);
            }

            return _entitiesCache;
        }

        public IEnumerator<Entity> GetEnumerator() {
			var entities = (IEnumerable<Entity>)GetEntities();
			return entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        /// Returns the only entity in this group. It will return null
        /// if the group is empty. It will throw an exception if the group
        /// has more than one entity.
        public Entity GetSingleEntity() {
            if (_singleEntityCache == null) {
                var c = _entities.Count;
                if (c == 1) {
                    using (var enumerator = _entities.GetEnumerator()) {
                        enumerator.MoveNext();
                        _singleEntityCache = enumerator.Current;
                    }
                } else if (c == 0) {
                    return null;
                } else {
                    throw new GroupSingleEntityException(this);
                }
            }

            return _singleEntityCache;
        }

        public override string ToString() {
            if (_toStringCache == null) {
                _toStringCache = "Group(" + _matcher + ")";
            }
            return _toStringCache;
        }
    }
}
