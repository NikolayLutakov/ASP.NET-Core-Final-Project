namespace GlassesStore.Models.Common
{
    public class Constants
    {
        public const int NameMinLength = 1;
        public const int NameMaxLength = 25;
        public const int DescriptionMinLength = 10;
        public const int DescriptionMaxLength = 300;

        public class Card
        {
            public const int NumberMaxLength = 16;
        }

        public class CardType
        {
            public const int NameMinLengt = 1;
            public const int NameMaxLengt = 15;
        }

        public class Comment
        {
            public const int ContentMinLength = 5;
            public const int ContentMaxLength = 250;
        }

        public class AdministratorConstants
        {
            public const string AreaName = "Administrator";
            public const string AdministratorRoleName = "Administrator";

            public const string AdministratorUsername = "administrator@admin.com";
            public const string AdministratorPassword = "123456";
        }
        public class Paging
        {
            public const int GlassesPerPage = 6;
            public const int BrandsPerPage = 12;
        }
    }
}
