using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeLine.Core.Utilities
{
    public class Constants
    {
        public static class DonorContants
        {
            public const string FIRST_NAME_DISPLAYNAME = "First Name";
            public const string LAST_NAME_DISPLAYNAME = "Last Name";
            public const string PHONE_DISPLAYNAME = "Phone";
            public const string DONATION_DATE_DISPLAYNAME = "Donation Date";
            public const string CAMP_DISPLAYNAME = "Camp Name";

            public const int FIRST_NAME_LENGTH = 20;
            public const int LAST_NAME_LENGTH = 10;

        }

        public static class CampContants
        {
            public const int CAMP_NAME_LENGTH = 50;
            public const int WHERE_LENGTH = 30;
        }
    }
}