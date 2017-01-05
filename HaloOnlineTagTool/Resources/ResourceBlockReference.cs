using System.Collections;
using System.Collections.Generic;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.Resources
{
    /// <summary>
    /// A block reference to raw resource data. Only used in resource definitions.
    /// </summary>
    /// <remarks>
    /// Not to be confused with <see cref="ResourceReference"/>, which references a resource as a whole and is found in normal tag data.
    /// </remarks>
    [TagStructure(Size = 0xC)]
    public class ResourceBlockReference<T> : IList<T>
    {
        public ResourceBlockReference()
        {
        }

        public ResourceBlockReference(int count, ResourceAddress address)
        {
            Count = count;
            Address = address;
        }

        /// <summary>
        /// Gets or sets the count of the referenced block.
        /// </summary>
        public int Count;

        /// <summary>
        /// Gets or sets the address of the referenced block.
        /// </summary>
        public ResourceAddress Address;

        public int Unused;

        [MaxVersion(EngineVersion.Unknown)]
        private List<T> Elements = new List<T>();

        int ICollection<T>.Count => Elements.Count;
        public bool IsReadOnly => ((IList<T>)Elements).IsReadOnly;

        public T this[int index]
        {
            get { return Elements[index]; }
            set { Elements[index] = value; }
        }

        public int IndexOf(T item) => Elements.IndexOf(item);

        public void Insert(int index, T item) => Elements.Insert(index, item);

        public void RemoveAt(int index) => Elements.RemoveAt(index);

        public void Add(T item) => Elements.Add(item);

        public void Clear() => Elements.Clear();

        public bool Contains(T item) => Elements.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => Elements.CopyTo(array, arrayIndex);

        public bool Remove(T item) => Elements.Remove(item);

        public IEnumerator<T> GetEnumerator() => Elements.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Elements.GetEnumerator();
    }
}
