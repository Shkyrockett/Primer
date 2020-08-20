namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="PrimerLibrary.ILocatable" />
    /// <seealso cref="PrimerLibrary.ISizable" />
    /// <seealso cref="PrimerLibrary.IBoundable" />
    public interface IAnimatable
        : ILocatable, ISizable, IBoundable
    {
        /// <summary>
        /// Starts this instance.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops this instance.
        /// </summary>
        void Stop();
    }
}
