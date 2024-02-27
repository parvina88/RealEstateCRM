namespace RealEstate.Api;

public static class ApiEndpoints
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

    public static class Entrance
    {
        private const string Base = $"{ApiBase}/entrances";
        public const string Create = Base;
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
        public const string GetAllByBuilding = $"{Base}/building/{{id:guid}}";
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
    }

    public static class Apartment
    {
        private const string Base = $"{ApiBase}/apartments";
        public const string Create = Base;
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
        public const string GetAllByEntrance = $"{Base}/entrance/{{id:guid}}";
        public const string GetAllByStatus = $"{Base}/status/{{status}}";
        public const string Update = $"{Base}/{{id:guid}}";
        public const string Delete = $"{Base}/{{id:guid}}";
    }
}
