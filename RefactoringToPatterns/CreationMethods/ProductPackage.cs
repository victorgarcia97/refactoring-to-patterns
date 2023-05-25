using System;

namespace RefactoringToPatterns.CreationMethods
{
    public class ProductPackage
    {
        private readonly string _internetLabel;
        private readonly int? _mobileNumber;
        private readonly int? _telephoneNumber;
        private readonly string[] _tvChannels;

        public ProductPackage(string internetLabel, int? mobileNumber, int? telephoneNumber, string[] tvChannels)
        {
            _internetLabel = internetLabel;
            _mobileNumber = mobileNumber;
            _telephoneNumber = telephoneNumber;
            _tvChannels = tvChannels;
        }

        public bool HasInternet()
        {
            return _internetLabel != null;
        }


        public bool HasVOIP()
        {
            return _telephoneNumber != null;
        }

        public bool HasTv()
        {
            return _tvChannels != null;
        }


        public bool HasMobile()
        {
            return _mobileNumber != null;
        }

        public static ProductPackage CreatePackageWith(string internetLabel, int? mobileNumber, int? telephoneNumber,
            string[] tvChannels)
        {
            return new ProductPackage(internetLabel, mobileNumber, telephoneNumber, tvChannels);
        }
    }
}