namespace VeryDeli.Libraries.Abstraction.Domains.Types
{
    public abstract class AggregateRoot<T>
    {
        public T Id { get; protected set; }
        public int Version { get; protected set; }

        private bool _versionIncremented;

        protected void IncrementVersion()
        {
            if (_versionIncremented)
            {
                return;
            }

            Version++;
            _versionIncremented = true;
        }
    }

    public abstract class AggregateRoot : AggregateRoot<AggregateId>
    {
    }
}
