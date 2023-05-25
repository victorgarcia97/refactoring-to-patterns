using Xunit;

namespace RefactoringToPatterns.CreationMethods.Tests
{
    public class ProductPackageShould
    {
        [Fact]
        public void CreateAProductPackageWithOnlyInternet()
        {
            var productPackage = new ProductPackage("100MB");

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.False(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetAndVoip()
        {
            var productPackage = CreateWithInternetAndTelephone("100MB", 91233788);

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasVOIP());
            Assert.False(productPackage.HasTv());
        }

        private static ProductPackage CreateWithInternetAndTelephone(string internetLabel, int telephoneNumber)
        {
            var productPackage = new ProductPackage(internetLabel, telephoneNumber, null);
            return productPackage;
        }

        [Fact]
        public void CreateWithInternetAndTv()
        {
            var productPackage = CreatePackageWithInternetAndTv("100MB", new[] { "LaLiga", "Estrenos" });

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.True(productPackage.HasTv());
        }

        private static ProductPackage CreatePackageWithInternetAndTv(string internetLabel, string[] tvChannels)
        {
            var productPackage = new ProductPackage(internetLabel, null, tvChannels);
            return productPackage;
        }

        [Fact]
        public void CreateWithInternetVoipAndTv()
        {
            var productPackage = CreateTrioPackageWith("100MB", 91233788, new[] { "LaLiga", "Estrenos" });

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasVOIP());
            Assert.True(productPackage.HasTv());
        }

        private static ProductPackage CreateTrioPackageWith(string internetLabel, int telephoneNumber, string[] tvChannels)
        {
            var productPackage = new ProductPackage(internetLabel, telephoneNumber, tvChannels);
            return productPackage;
        }
    }
}