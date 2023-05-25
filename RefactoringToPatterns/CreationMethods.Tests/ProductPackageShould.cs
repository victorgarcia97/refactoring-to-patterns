using Xunit;

namespace RefactoringToPatterns.CreationMethods.Tests
{
    public class ProductPackageShould
    {
        [Fact]
        public void CreateAProductPackageWithOnlyInternet()
        {
            var productPackage = ProductPackage.CreatePackageWith("100MB", null, null, null);

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.False(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetAndVoip()
        {
            var productPackage = ProductPackage.CreatePackageWith("100MB", null, 91233788, null);

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasVOIP());
            Assert.False(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetAndTv()
        {
            var productPackage = ProductPackage.CreatePackageWith("100MB",null, null, new[] { "LaLiga", "Estrenos" });

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.True(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetVoipAndTv()
        {
            var productPackage = ProductPackage.CreatePackageWith("100MB", null, 91233788, new[] { "LaLiga", "Estrenos" });

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasVOIP());
            Assert.True(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetAndMobile()
        {
            var productPackage = ProductPackage.CreatePackageWith("100MB", 689039234, null, null);

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.True(productPackage.HasMobile());
            Assert.False(productPackage.HasTv());
        }
    }
}