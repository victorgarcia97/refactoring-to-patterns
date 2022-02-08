using System.Runtime.Remoting.Channels;
using RefactoringToPatterns.CreationMethods.Tests;
using Xunit;

namespace RefactoringToPatterns.CreationMethods
{
    public class ProductPackageShould
    {
        [Fact]
        public void CreateAProductPackageWithOnlyInternet()
        {
            var productPackage = CreateWithInternet();

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.False(productPackage.HasTv());
        }

        private static ProductPackage CreateWithInternet()
        {
            var productPackage = new ProductPackage("100MB");
            return productPackage;
        }

        [Fact]
        public void CreateWithInternetAndVOIP()
        {
            var productPackage = new ProductPackage("100MB", 91233788);

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasVOIP());
            Assert.False(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetAndTv()
        {
            var productPackage = new ProductPackage("100MB", new string[] {"LaLiga", "Estrenos"});

            Assert.True(productPackage.HasInternet());
            Assert.False(productPackage.HasVOIP());
            Assert.True(productPackage.HasTv());
        }

        [Fact]
        public void CreateWithInternetVOIPAndTv()
        {
            var productPackage = new ProductPackage("100MB", 91233788, new string[] {"LaLiga", "Estrenos"});

            Assert.True(productPackage.HasInternet());
            Assert.True(productPackage.HasVOIP());
            Assert.True(productPackage.HasTv());
        }
    }
}