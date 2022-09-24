namespace Business.Constants
{
    //static classlar new'lenemez
    public static class Messages
    {
        //class icerisindeki private fieldlar camelCase ile yazılır
        //public fieldlar PascalCase ile yazılır.
        public static string CarAdded = "Araba eklendi.";
        public static string CarNameInvalid = "Araba ismi geçersiz."; //Bu kısım daha sonra Fluent Validation ile kodlanacak.
        public static string MaintenanceTime = "Sistem bakımda.";
        public static string CarsListed = "Arabalar listelendi.";
    }
}
