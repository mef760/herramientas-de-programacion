public static class DataService
{
    static List<ContactData> Datos { get; }
    static int nextId = 3;
    static DataService()
    {
        Datos = new List<ContactData>
                {
                    new ContactData {  Name = "Classic Italian" },
                    new ContactData {  Name = "Veggie" }
                };
    }

    public static List<ContactData> GetAll() => Datos;

    public static ContactData? Get(string name) => Datos.FirstOrDefault(p => p.Name == name);

    public static void Add(ContactData data)
    {
        Datos.Add(data);
    }

   
}