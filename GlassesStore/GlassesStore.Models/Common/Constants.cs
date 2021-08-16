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
            public const string validationString = "^[0-9]{16}$";
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
            public const int GlassesPerPage = 9;
            public const int BrandsPerPage = 12;
            public const int CardsPerPage = 20;
            public const int PurchasesPage = 20;
            public const int CommentsPage = 20;
            public const int UsersPerPage = 12;
            public const int MessagesPerPage = 20;
        }

        public class Sorting
        {
            public const string PriceAsc = "priceAsc";
            public const string PriceDesc = "priceDesc";
            public const string Buy = "buy";
            public const string Like = "like";
        }
        public class Contacts
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
            public const int SubjectMinLength = 3;
            public const int SubjectMaxLength = 30;
            public const int EmailMinLength = 3;
            public const int EmailMaxLength = 50;
            public const int MessageMinLength = 5;
            public const int MessageMaxLength = 300;
        }
    }
}
