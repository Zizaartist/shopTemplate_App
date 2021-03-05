using System;
using System.Collections.Generic;
using System.Text;

namespace Click.StaticValues
{
    public static class ApiStrings
    {
        public const string API_HOST = "https://clickapidebug.azurewebsites.net/";

        public const string API_USERS_CONTROLLER = "Users/";
        public const string API_USERS_AUTH = "PhoneCheck/";
        public const string API_ADMINS_AUTH = "AdminCheck/";
        public const string API_POINTS = "GetMyPoints/";
        public const string API_USERS_MY_DATA = "GetMyData/";
        public const string API_USERS_PHONE_CHANGE = "ChangeNumber/";
        public const string API_VERIFY_NUMBER = "PhoneIsRegistered/";

        public const string API_BRANDS_CONTROLLER = "Brands/";
        public const string API_BRANDS_GET_BY_CATEGORY = "GetBrandsByCategory/";
        public const string API_BRANDS_GET_MY_BRANDS = "GetMyBrands/";
        public const string API_BRANDS_GET_BY_FILTER = "GetBrandsByFilter/";
        public const string API_BRANDS_GET_BY_NAME = "GetBrandsByName/"; //{category}?name=blah

        public const string API_MENU_CONTROLLER = "BrandsMenu/";
        public const string API_MENU_GET_BY_BRAND = "GetMenusByBrand/";
        public const string API_MENU_GET_MY_MENUS = "GetMyMenus/"; 

        public const string API_PRODUCTS_CONTROLLER = "Products/";
        public const string API_PRODUCTS_GET_BY_MENU = "GetProductsByMenu/";
        public const string API_PRODUCTS_GET_MY_PRODUCTS = "GetMyProducts/";
        public const string API_PRODUCTS_VODA_BY_CATEGORY = "GetVodaProductsByCategory/";

        public const string API_USERTOKEN_CONTROLLER = "UserToken/";
        public const string API_ADMINTOKEN_CONTROLLER = "AdminToken/";

        public const string API_MESSAGES_CONTROLLER = "Messages/";
        public const string API_MESSAGES_GET_BY_BRAND = "BrandReviews/"; //{id}/{_page}
        public const string API_MESSAGES_GET_COUNT = "BrandReviewCount/"; //{id}

        public const string API_ORDERS_CONTROLLER = "Orders/";
        public const string API_ORDERS_GET_ORDERS = "GetMyOrders/";
        public const string API_ORDERS_GET_TASKS = "GetMyTasks/";
        public const string API_ORDERS_GET_HISTORY = "GetMyHistory/";
        public const string API_ORDERS_POST_VODA = "PostVodaOrders/";
        public const string API_ORDERS_PUT_VODA = "PutVodaOrders/";
        public const string API_ORDERS_GET_BY_CATEGORY = "GetOrdersByCategory/";
        public const string API_REQUESTS_GET_BY_ORDER = "GetRequestsByOrder/";
        public const string API_REQUESTS_SELECT_BRAND = "SelectVodaBrand/";
        public const string API_ORDERS_GET_OPEN = "GetOpenVodaOrders/";
        public const string API_REQUESTS_POST = "PostVodaRequest/";

        public const string API_IMAGES_FOLDER = "Images/";
        public const string API_IMAGES_CONTROLLER = "PostImage/";

        public const string API_ADBANNER_CONTROLLER = "AdBanner/";

        public const string API_POINT_REGISTERS_CONTROLLER = "PointRegisters/";

        public const string API_HASHTAGS_GET = "GetHashtagsByCategory/";
        public const string API_CATEGORY_CONTROLLER = "Category/";
        public const string API_PAYMENTMETHODS_CONTROLLER = "PaymentMethods/";
        public const string API_BANKNOTE_CONTROLLER = "Banknote/";
    }
}
