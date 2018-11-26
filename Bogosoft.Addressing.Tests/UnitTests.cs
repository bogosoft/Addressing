using Bogosoft.Cloning;
using NUnit.Framework;
using Shouldly;

namespace Bogosoft.Addressing.Tests
{
    [TestFixture, Category("Unit")]
    public class UnitTests
    {
        static readonly Address Apple = new Address
        {
            City = "Cupertino",
            CountryCode = "US",
            PostalCode = "95014",
            RegionCode = "CA",
            Street = "1 Apple Park Way"
        };

        static readonly Address Microsoft = new Address
        {
            City = "Redmond",
            CountryCode = "US",
            PostalCode = "98052",
            RegionCode = "WA",
            Street = "One Microsoft Way"
        };

        [TestCase]
        public void ClonedAddressIsDifferentReferenceWithSameDataAsOriginal()
        {
            Address a = Apple, b = a.Clone();

            ReferenceEquals(a, b).ShouldBeFalse();

            b.City.ShouldBe(a.City);
            b.CountryCode.ShouldBe(a.CountryCode);
            b.PostalCode.ShouldBe(a.PostalCode);
            b.RegionCode.ShouldBe(a.RegionCode);
            b.Street.ShouldBe(a.Street);
        }

        [TestCase]
        public void TwoAddressesThatDifferOnlyByCityAreNotEqual()
        {
            Address a = Apple, b = a.CloneAnd(x => x.City = "Mountain View");

            b.City.ShouldNotBe(a.City);
            b.CountryCode.ShouldBe(a.CountryCode);
            b.PostalCode.ShouldBe(a.PostalCode);
            b.RegionCode.ShouldBe(a.RegionCode);
            b.Street.ShouldBe(a.Street);

            (a == b).ShouldBeFalse();
            (a != b).ShouldBeTrue();

            b.Equals(a).ShouldBeFalse();

            b.GetHashCode().ShouldNotBe(a.GetHashCode());
        }

        [TestCase]
        public void TwoAddressesThatDifferOnlyByCountryCodeAreNotEqual()
        {
            Address a = Microsoft, b = a.CloneAnd(x => x.CountryCode = "CA");

            b.City.ShouldBe(a.City);
            b.CountryCode.ShouldNotBe(a.CountryCode);
            b.PostalCode.ShouldBe(a.PostalCode);
            b.RegionCode.ShouldBe(a.RegionCode);
            b.Street.ShouldBe(a.Street);

            (a == b).ShouldBeFalse();
            (a != b).ShouldBeTrue();

            b.Equals(a).ShouldBeFalse();

            b.GetHashCode().ShouldNotBe(a.GetHashCode());
        }

        [TestCase]
        public void TwoAddressesThatDifferOnlyByPostalCodeAreNotEqual()
        {
            Address a = Apple, b = a.CloneAnd(x => x.PostalCode = Microsoft.PostalCode);

            b.City.ShouldBe(a.City);
            b.CountryCode.ShouldBe(a.CountryCode);
            b.PostalCode.ShouldNotBe(a.PostalCode);
            b.RegionCode.ShouldBe(a.RegionCode);
            b.Street.ShouldBe(a.Street);

            (a == b).ShouldBeFalse();
            (a != b).ShouldBeTrue();

            b.Equals(a).ShouldBeFalse();

            b.GetHashCode().ShouldNotBe(a.GetHashCode());
        }

        [TestCase]
        public void TwoAddressesThatDifferOnlyByRegionCodeAreNotEqual()
        {
            Address a = Microsoft, b = a.CloneAnd(x => x.RegionCode = Apple.RegionCode);

            b.City.ShouldBe(a.City);
            b.CountryCode.ShouldBe(a.CountryCode);
            b.PostalCode.ShouldBe(a.PostalCode);
            b.RegionCode.ShouldNotBe(a.RegionCode);
            b.Street.ShouldBe(a.Street);

            (a == b).ShouldBeFalse();
            (a != b).ShouldBeTrue();

            b.Equals(a).ShouldBeFalse();

            b.GetHashCode().ShouldNotBe(a.GetHashCode());
        }

        [TestCase]
        public void TwoAddressesThatDifferOnlyByStreetAreNotEqual()
        {
            Address a = Apple, b = a.CloneAnd(x => x.Street = Microsoft.Street);

            b.City.ShouldBe(a.City);
            b.CountryCode.ShouldBe(a.CountryCode);
            b.PostalCode.ShouldBe(a.PostalCode);
            b.RegionCode.ShouldBe(a.RegionCode);
            b.Street.ShouldNotBe(a.Street);

            (a == b).ShouldBeFalse();
            (a != b).ShouldBeTrue();

            b.Equals(a).ShouldBeFalse();

            b.GetHashCode().ShouldNotBe(a.GetHashCode());
        }

        [TestCase]
        public void TwoAddressesWithTheExactSameDataAreEqual()
        {
            Address a = Microsoft, b = a.Clone();

            ReferenceEquals(a, b).ShouldBeFalse();

            b.City.ShouldBe(a.City);
            b.CountryCode.ShouldBe(a.CountryCode);
            b.PostalCode.ShouldBe(a.PostalCode);
            b.RegionCode.ShouldBe(a.RegionCode);
            b.Street.ShouldBe(a.Street);

            (a == b).ShouldBeTrue();
            (a != b).ShouldBeFalse();

            b.Equals(a).ShouldBeTrue();

            b.GetHashCode().ShouldBe(a.GetHashCode());
        }
    }
}