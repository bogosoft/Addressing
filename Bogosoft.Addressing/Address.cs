using Bogosoft.Cloning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Bogosoft.Addressing
{
    /// <summary>
    /// Represents a postal address.
    /// </summary>
    public class Address : ICloneable<Address>, IEquatable<Address>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static bool IsNotNullOrEmpty(string s) => s != null && s.Length > 0;

        /// <summary>
        /// Compare two <see cref="Address"/> objects for equality.
        /// </summary>
        /// <param name="lhs">The left-hand side of the operation.</param>
        /// <param name="rhs">The right-hand side of the operation.</param>
        /// <returns>
        /// A value indicating whether or not the two <see cref="Address"/> objects are equivalent.
        /// </returns>
        public static bool operator ==(Address lhs, Address rhs)
        {
            return NullSafeStringComparer.Equals(lhs?.City, rhs?.City)
                && NullSafeStringComparer.Equals(lhs?.CountryCode, rhs?.CountryCode)
                && NullSafeStringComparer.Equals(lhs?.PostalCode, rhs?.PostalCode)
                && NullSafeStringComparer.Equals(lhs?.RegionCode, rhs?.RegionCode)
                && NullSafeStringComparer.Equals(lhs?.Street, rhs?.Street);
        }

        /// <summary>
        /// Compare two <see cref="Address"/> objects for inequality.
        /// </summary>
        /// <param name="lhs">The left-hand side of the operation.</param>
        /// <param name="rhs">The right-hand side of the operation.</param>
        /// <returns>
        /// A value indicating whether or not the two <see cref="Address"/> objects are not equivalent.
        /// </returns>
        public static bool operator !=(Address lhs, Address rhs)
        {
            return !NullSafeStringComparer.Equals(lhs?.City, rhs?.City)
                || !NullSafeStringComparer.Equals(lhs?.CountryCode, rhs?.CountryCode)
                || !NullSafeStringComparer.Equals(lhs?.PostalCode, rhs?.PostalCode)
                || !NullSafeStringComparer.Equals(lhs?.RegionCode, rhs?.RegionCode)
                || !NullSafeStringComparer.Equals(lhs?.Street, rhs?.Street);
        }

        /// <summary>
        /// Get an address that is "empty", i.e. not defined.
        /// </summary>
        public static readonly Address Undefined = new Address();

        /// <summary>Get or set the city for the current address.</summary>
        public string City { get; set; }

        IEnumerable<string> Components
        {
            get
            {
                yield return Street;
                yield return City;
                yield return RegionCode;
                yield return PostalCode;
                yield return CountryCode;
            }
        }

        /// <summary>
        /// Get or set the country code for the current address.
        /// </summary>
        /// <remarks>
        /// This code is intended to adhere to the two-letter ISO-3166-1 alpha-2 scheme.
        /// </remarks>
        public string CountryCode { get; set; }

        /// <summary>
        /// Get or set the postal code for the current address.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Get or set the region code of the current address.
        /// </summary>
        /// <remarks>
        /// This code is intended to be the two- or three- letter component of an ISO-3166-2 principal subdivision
        /// code, i.e. the BC in CA-BC (British Columbia, Canada) or the COL in MX-COL (Colima, Mexico).
        /// </remarks>
        public string RegionCode { get; set; }

        /// <summary>
        /// Get or set the street for the current address.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Create an exact copy of the current address.
        /// </summary>
        /// <returns>A new reference to an exact copy of the current address.</returns>
        public virtual Address Clone()
        {
            return new Address
            {
                City = City,
                CountryCode = CountryCode,
                PostalCode = PostalCode,
                RegionCode = RegionCode,
                Street = Street
            };
        }

        object ICloneable.Clone() => Clone();

        /// <summary>
        /// Compare the current address with another for equality.
        /// </summary>
        /// <param name="other">An address to compare to the current address.</param>
        /// <returns>
        /// A value indicating whether or not the current address is equal to the given address.
        /// </returns>
        public virtual bool Equals(Address other)
        {
            return NullSafeStringComparer.Equals(City, other?.City)
                && NullSafeStringComparer.Equals(CountryCode, other?.CountryCode)
                && NullSafeStringComparer.Equals(PostalCode, other?.PostalCode)
                && NullSafeStringComparer.Equals(RegionCode, other?.RegionCode)
                && NullSafeStringComparer.Equals(Street, other?.Street);
        }

        /// <summary>
        /// Compare the current address to another for equality.
        /// </summary>
        /// <param name="obj">An object to compare to the current instance.</param>
        /// <returns>
        /// A value indicating hether or not the current address equals the given object.
        /// </returns>
        public override bool Equals(object obj) => obj is Address && Equals(obj as Address);

        /// <summary>
        /// Get a value corresponding to the hash code for the current address.
        /// </summary>
        /// <returns>A hash code for the current address.</returns>
        public override int GetHashCode() => NullSafeStringComparer.GetHashCode(Components);

        /// <summary>
        /// Get a string representation of the current address.
        /// </summary>
        /// <returns>A string representation of the current address.</returns>
        public override string ToString() => string.Join(" ", Components.Where(IsNotNullOrEmpty));
    }
}