﻿namespace RealEstate.Api
{
    public static class ApiEndPoints
    {
        private const string ApiBase = "api";

        public static class Building
        {
            private const string Base = $"{ApiBase}/buildings";
            public const string Create = Base;
            public const string Get = $"{Base}/{{id:guid}}";
            public const string GetAll = Base;
            public const string Update = $"{Base}/{{id:guid}}";
            public const string Delete = $"{Base}/{{id:guid}}";
        }
    }
}
