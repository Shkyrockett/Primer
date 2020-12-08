using MathematicsNotationLibrary;

namespace PrimerLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MathematicsNotationLibrary.ILocatable" />
    /// <seealso cref="MathematicsNotationLibrary.ISizable" />
    /// <seealso cref="MathematicsNotationLibrary.IBoundable" />
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
