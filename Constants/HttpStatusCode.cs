namespace calculadora.Constants
{
    public static class HttpStatusCode //Cuando una clase estatica, no es necesario usar NEW, sino que se puede usar directamente
    {
        public const int Ok = 200;
        public const int CREATED = 201;
        public const int No_CONTENT = 204;
        public const int BAD_REQUEST = 400;
        public const int UNAUTHORIZED = 401;
        public const int FORBIDDED = 403;
        public const int NOT_FOUND = 404;
        public const int CONFLICT = 409;
        public const int INTERNAL_SERVER_ERROR = 500;
        public const int NOT_IMPLEMENTED = 501;
        public const int SERVICE_UNAVAILABLE = 503;

    }
}
