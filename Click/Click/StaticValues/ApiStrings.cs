﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Click.StaticValues
{
    public static class ApiStrings
    {
        public const string HOST = "https://shopapidebug.azurewebsites.net/";

        //Auth

        /// <summary>
        /// POST: api/Auth/UserToken/?phone=79991745473&code=3667
        /// </summary>
        public const string ACCOUNT_USERS_TOKEN = "api/Auth/UserToken/";
        /// <summary>
        /// POST: api/Auth/SmsCheck/?phone=79991745473
        /// </summary>
        public const string ACCOUNT_SMS_CHECK = "api/Auth/SmsCheck/"; 
        /// <summary>
        /// POST: api/Auth/CodeCheck/?code=3344&phone=79991745473
        /// </summary>
        public const string ACCOUNT_CODE_CHECK = "api/Auth/CodeCheck/"; 
        /// <summary>
        /// GET: api/Auth/ValidateToken/?phone=79991745473
        /// </summary>
        public const string ACCOUNT_VALIDATE = "api/Auth/ValidateToken/";
        /// <summary>
        /// GET: api/Auth/GetMyPoints/
        /// </summary>
        public const string ACCOUNT_POINTS = "api/Auth/GetMyPoints/";
        /// <summary>
        /// PUT: api/Auth/ChangeNumber/?newPhoneNumber=88005553535&code=3344
        /// </summary>
        public const string ACCOUNT_PHONE_CHANGE = "api/Auth/ChangeNumber/";

        //Categories

        /// <summary>
        /// GET: api/Categories/
        /// </summary>
        public const string CATEGORIES_CONTROLLER = "api/Categories/";

        //ErrorReport

        /// <summary>
        /// POST: api/ErrorReports
        /// </summary>
        public const string ERRORREPORTS_CONTROLLER = "api/ErrorReports/";

        //Images

        public const string IMAGES_FOLDER = "Images/";
        /// <summary>
        /// POST: api/Images/
        /// </summary>
        public const string IMAGES_CONTROLLER = "api/Images/";

        //Orders

        /// <summary>
        /// POST: api/Orders/
        /// </summary>
        public const string ORDERS_CONTROLLER = "api/Orders/";
        /// <summary>
        /// GET: api/Orders/GetMyOrders/{_page}
        /// </summary>
        public const string ORDERS_GET_ORDERS = "api/Orders/GetMyOrders/";
        /// <summary>
        /// PUT: api/Orders/ClaimPoints/{id}
        /// </summary>
        public const string ORDERS_CLAIM_POINTS = "api/Orders/ClaimPoints/";

        //PointRegisters

        /// <summary>
        /// GET: api/PointRegisters/
        /// </summary>
        public const string POINT_REGISTERS_CONTROLLER = "api/PointRegisters/";

        //Products
        /// <summary>
        /// GET: api/Products/ByCategory/{id}/{_page}
        /// </summary>
        public const string PRODUCTS_GET_BY_MENU = "api/Products/ByCategory/";
    }
}
