using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Bienvenido a mi lista de Contactos");

        bool runing = true;
        List<int> ids = new List<int>();
        Dictionary<int, string> names = new Dictionary<int, string>();
        Dictionary<int, string> lastnames = new Dictionary<int, string>();
        Dictionary<int, string> addresses = new Dictionary<int, string>();
        Dictionary<int, string> telephones = new Dictionary<int, string>();
        Dictionary<int, string> emails = new Dictionary<int, string>();
        Dictionary<int, int> ages = new Dictionary<int, int>();
        Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

        while (runing)
        {
            Console.WriteLine(@"1. Agregar Contacto     2. Ver Contactos    3. Buscar Contactos     4. Modificar Contacto   5. Eliminar Contacto    6. Salir");
            Console.WriteLine("Digite el número de la opción deseada");

            int typeOption = Convert.ToInt32(Console.ReadLine());

            switch (typeOption)
            {
                case 1:
                    {
                        AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    }
                    break;
                case 2: // View Contacts
                    {
                        Console.WriteLine($"Nombre          Apellido            Dirección           Telefono            Email           Edad            Es Mejor Amigo?");
                        Console.WriteLine($"____________________________________________________________________________________________________________________________");
                        foreach (var id in ids)
                        {
                            var isBestFriend = bestFriends[id];
                            string isBestFriendStr = (isBestFriend == true) ? "Si" : "No";
                            Console.WriteLine($"{names[id]}         {lastnames[id]}         {addresses[id]}         {telephones[id]}            {emails[id]}            {ages[id]}          {isBestFriendStr}");
                        }
                    }
                    break;
                case 3: // search
                    {
                        Console.WriteLine("Digite el ID del contacto que desea buscar:");
                        int searchId = Convert.ToInt32(Console.ReadLine());

                        if (ids.Contains(searchId))
                        {
                            Console.WriteLine($"Nombre: {names[searchId]}");
                            Console.WriteLine($"Apellido: {lastnames[searchId]}");
                            Console.WriteLine($"Dirección: {addresses[searchId]}");
                            Console.WriteLine($"Teléfono: {telephones[searchId]}");
                            Console.WriteLine($"Email: {emails[searchId]}");
                            Console.WriteLine($"Edad: {ages[searchId]}");
                            Console.WriteLine($"Mejor amigo: {(bestFriends[searchId] ? "Sí" : "No")}");
                        }
                        else
                        {
                            Console.WriteLine("Contacto no encontrado.");
                        }
                    }
                    break;
                case 4: // Modify
                    {
                        Console.WriteLine("Digite el ID del contacto que desea modificar:");
                        int modifyId = Convert.ToInt32(Console.ReadLine());

                        if (ids.Contains(modifyId))
                        {
                            Console.WriteLine("Digite el nuevo nombre de la persona (deje vacío para no modificar):");
                            string newName = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newName)) names[modifyId] = newName;

                            Console.WriteLine("Digite el nuevo apellido de la persona (deje vacío para no modificar):");
                            string newLastname = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newLastname)) lastnames[modifyId] = newLastname;

                            Console.WriteLine("Digite la nueva dirección (deje vacío para no modificar):");
                            string newAddress = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newAddress)) addresses[modifyId] = newAddress;

                            Console.WriteLine("Digite el nuevo teléfono (deje vacío para no modificar):");
                            string newPhone = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newPhone)) telephones[modifyId] = newPhone;

                            Console.WriteLine("Digite el nuevo email (deje vacío para no modificar):");
                            string newEmail = Console.ReadLine();
                            if (!string.IsNullOrEmpty(newEmail)) emails[modifyId] = newEmail;

                            Console.WriteLine("Digite la nueva edad (deje vacío para no modificar):");
                            string newAgeInput = Console.ReadLine();
                            if (int.TryParse(newAgeInput, out int newAge)) ages[modifyId] = newAge;

                            Console.WriteLine("Especifique si es mejor amigo: 1. Sí, 2. No (deje vacío para no modificar):");
                            string bestFriendInput = Console.ReadLine();
                            if (!string.IsNullOrEmpty(bestFriendInput))
                            {
                                bestFriends[modifyId] = Convert.ToInt32(bestFriendInput) == 1;
                            }

                            Console.WriteLine("Contacto modificado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("Contacto no encontrado.");
                        }
                    }
                    break;
                case 5: // Delete
                    {
                        Console.WriteLine("Digite el ID del contacto que desea eliminar:");
                        int deleteId = Convert.ToInt32(Console.ReadLine());

                        if (ids.Contains(deleteId))
                        {
                            ids.Remove(deleteId);
                            names.Remove(deleteId);
                            lastnames.Remove(deleteId);
                            addresses.Remove(deleteId);
                            telephones.Remove(deleteId);
                            emails.Remove(deleteId);
                            ages.Remove(deleteId);
                            bestFriends.Remove(deleteId);

                            Console.WriteLine("Contacto eliminado exitosamente.");
                        }
                        else
                        {
                            Console.WriteLine("Contacto no encontrado.");
                        }
                    }
                    break;
                case 6:
                    runing = false;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    // Método para agregar un contacto
    public static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
                                Dictionary<int, string> addresses, Dictionary<int, string> telephones,
                                Dictionary<int, string> emails, Dictionary<int, int> ages,
                                Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("Digite el nombre de la persona:");
        string name = Console.ReadLine();
        Console.WriteLine("Digite el apellido de la persona:");
        string lastname = Console.ReadLine();
        Console.WriteLine("Digite la dirección:");
        string address = Console.ReadLine();
        Console.WriteLine("Digite el telefono de la persona:");
        string phone = Console.ReadLine();
        Console.WriteLine("Digite el email de la persona:");
        string email = Console.ReadLine();
        Console.WriteLine("Digite la edad de la persona en números:");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No:");
        bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

        int id = ids.Count + 1;
        ids.Add(id);
        names.Add(id, name);
        lastnames.Add(id, lastname);
        addresses.Add(id, address);
        telephones.Add(id, phone);
        emails.Add(id, email);
        ages.Add(id, age);
        bestFriends.Add(id, isBestFriend);

        Console.WriteLine("Contacto agregado exitosamente.");
    }
}
