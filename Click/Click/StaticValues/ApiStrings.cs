using System;
using System.Collections.Generic;
using System.Text;

namespace Click.StaticValues
{
    public static class ApiStrings
    {
        #if LOCALTESTING
            public const string HOST = "https://10.0.2.2:44358/";
        #else
            public const string HOST = "https://clickapidebug.azurewebsites.net/";
#endif

        //Account

        /// <summary>
        /// POST: api/Account/UserToken/?phone=79991745473
        /// </summary>
        public const string ACCOUNT_USERS_TOKEN = "api/Account/UserToken/";
        /// <summary>
        /// POST: api/Account/AdminToken/?login=Zizi&password=zaza
        /// </summary>
        public const string ACCOUNT_ADMINS_TOKEN = "api/Account/AdminToken/"; 
        /// <summary>
        /// POST: api/Account/SmsCheck/?phone=79991745473
        /// </summary>
        public const string ACCOUNT_SMS_CHECK = "api/Account/SmsCheck/"; 
        /// <summary>
        /// POST: api/Account/CodeCheck/?code=3344&phone=79991745473
        /// </summary>
        public const string ACCOUNT_CODE_CHECK = "api/Account/CodeCheck/"; 
        /// <summary>
        /// POST: api/Account/PhoneCheck/?phone=79991745473
        /// </summary>
        public const string ACCOUNT_PHONE_CHECK = "api/Account/PhoneCheck/"; 
        /// <summary>
        /// POST: api/Account/GetValidPhone/?phone=79991745473
        /// </summary>
        public const string ACCOUNT_VALID_PHONE = "api/Account/GetValidPhone/";

        //AdBanner

        /// <summary>
        /// POST, PUT: api/AdBanner/ DELETE: api/AdBanner/{id} 
        /// </summary>
        public const string ADBANNER_CONTROLLER = "api/AdBanner/";
        /// <summary>
        /// GET: api/AdBanner/{_kind}
        /// </summary>
        public const string ADBANNER_GET = "api/AdBanner/";

        //Brands

        /// <summary>
        /// GET: api/Brands/{id} PUT: api/Brands
        /// </summary>
        public const string BRANDS_CONTROLLER = "api/Brands/";
        /// <summary>
        /// POST: api/Brands/GetByFilter/{_kind}/{_page}?openNow=true
        /// </summary>
        public const string BRANDS_GET_BY_FILTER = "api/Brands/GetByFilter/";
        /// <summary>
        /// GET: api/Brands/GetByName/{_kind}?name=blahbla
        /// </summary>
        public const string BRANDS_GET_BY_NAME = "api/Brands/GetByName/";
        /// <summary>
        /// GET: api/Brands/GetWaterBrands/{_kind}
        /// </summary>
        public const string BRANDS_GET_WATER = "api/Brands/GetWaterBrands/";
        /// <summary>
        /// GET: api/Brands/GetMyBrand
        /// </summary>
        public const string BRANDS_GET_MY_BRAND = "api/Brands/GetMyBrand/";
        /// <summary>
        /// GET, PUT: api/Brands/BrandDoc
        /// </summary>
        public const string BRANDS_BRAND_DOC = "api/Brands/BrandDoc/";

        //Categories

        /// <summary>
        /// PUT, POST: api/Categories/ DELETE: api/Categories/{id}
        /// </summary>
        public const string CATEGORIES_CONTROLLER = "api/Categories/";
        /// <summary>
        /// GET: api/Categories/ByBrand/{id}
        /// </summary>
        public const string CATEGORIES_GET_BY_BRAND = "api/Categories/ByBrand/";

        //Hashtags

        /// <summary>
        ///  GET: api/Hashtags/{kind}
        /// </summary>
        public const string HASHTAGS_CONTROLLER = "api/Hashtags/"; 

        //Images

        public const string IMAGES_FOLDER = "Images/";
        /// <summary>
        /// POST: api/Images/
        /// </summary>
        public const string IMAGES_CONTROLLER = "api/Images/";

        //Orders

        /// <summary>
        /// POST: api/Orders/ DELETE: api/Orders/{id}
        /// </summary>
        public const string ORDERS_CONTROLLER = "api/Orders/";
        /// <summary>
        /// GET: api/Orders/GetMyOrders/{_page}
        /// </summary>
        public const string ORDERS_GET_ORDERS = "api/Orders/GetMyOrders/";
        /// <summary>
        /// GET: api/Orders/GetMyRegularTasks
        /// </summary>
        public const string ORDERS_GET_REGULAR_TASKS = "api/Orders/GetMyRegularTasks/";
        /// <summary>
        /// GET: api/Orders/GetMyWaterTasks
        /// </summary>
        public const string ORDERS_GET_WATER_TASKS = "api/Orders/GetMyWaterTasks/";
        /// <summary>
        /// GET: api/Orders/GetMyHistory
        /// </summary>
        public const string ORDERS_GET_HISTORY = "api/Orders/GetMyHistory/";
        /// <summary>
        /// PUT: api/Orders/ChangeStatus/{id}/{_status}
        /// </summary>
        public const string ORDERS_CHANGE_STATUS = "api/Orders/ChangeStatus/";
        /// <summary>
        /// PUT: api/Orders/ClaimPoints/{id}
        /// </summary>
        public const string ORDERS_CLAIM_POINTS = "api/Orders/ClaimPoints/";
        /// <summary>
        /// POST: api/Orders/PostWaterOrder/
        /// </summary>
        public const string ORDERS_POST_WATER = "api/Orders/PostWaterOrder/";
        /// <summary>
        /// GET: api/Orders/{id}
        /// </summary>
        public const string ORDERS_GET_REQUESTS_BY_ORDER = "api/Orders/GetRequestsByOrder/";
        /// <summary>
        /// POST: api/Orders/SelectWaterBrand/{id}
        /// </summary>
        public const string ORDERS_SELECT_WATER_BRAND = "api/Orders/SelectWaterBrand/";
        /// <summary>
        /// POST: api/Orders/PostWaterRequest
        /// </summary>
        public const string ORDERS_POST_WATER_REQUEST = "api/Orders/PostWaterRequest/";

        //PointRegisters

        /// <summary>
        /// GET: api/PointRegisters/
        /// </summary>
        public const string POINT_REGISTERS_CONTROLLER = "api/PointRegisters/";

        //Products

        /// <summary>
        /// PUT, POST: api/Products/ DELETE: api/Products/{id}
        /// </summary>
        public const string PRODUCTS_CONTROLLER = "api/Products/";
        /// <summary>
        /// GET: api/Products/ByCategory/{id}/{_page}
        /// </summary>
        public const string PRODUCTS_GET_BY_MENU = "api/Products/ByCategory/";

        //Reports

        /// <summary>
        /// GET: api/Reports/{datePeriod}/{_page}
        /// </summary>
        public const string REPORTS_CONTROLLER = "api/Reports/";
        /// <summary>
        /// GET: api/Reports/AllTimeStats
        /// </summary>
        public const string REPORTS_STATS = "api/Reports/AllTimeStats/";

        //Reviews

        /// <summary>
        /// POST: api/Reviews/
        /// </summary>
        public const string REVIEWS_CONTROLLER = "api/Reviews/";
        /// <summary>
        /// GET: api/Reviews/ByBrand/{id}/{_page}
        /// </summary>
        public const string REVIEWS_GET_BY_BRAND = "api/Reviews/ByBrand/";
        /// <summary>
        /// GET: api/Reviews/BrandReviewCount/{id}
        /// </summary>
        public const string REVIEWS_GET_COUNT = "api/Reviews/BrandReviewCount/";

        //Users

        /// <summary>
        /// PUT: api/Users/ POST: api/Users/?code=3366
        /// </summary>
        public const string USERS_CONTROLLER = "api/Users/";
        /// <summary>
        /// GET: api/Users/GetMyPoints/
        /// </summary>
        public const string USERS_POINTS = "api/Users/GetMyPoints/";
        /// <summary>
        /// GET: api/Users/GetMyData/
        /// </summary>
        public const string USERS_MY_DATA = "api/Users/GetMyData/";
        /// <summary>
        /// PUT: api/Users/ChangeNumber/?newPhoneNumber=88005553535&code=3344
        /// </summary>
        public const string USERS_PHONE_CHANGE = "api/Users/ChangeNumber/";
    }
}
