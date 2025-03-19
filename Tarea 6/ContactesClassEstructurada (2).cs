using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Mi Agenda Perrón");
        Console.WriteLine("Bienvenido a tu lista de contactos");

        ContactManager contactManager = new ContactManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nOpciones:");
            Console.WriteLine("1. Agregar Contacto");
            Console.WriteLine("2. Ver Contactos");
            Console.WriteLine("3. Buscar Contacto");
            Console.WriteLine("4. Modificar Contacto");
            Console.WriteLine("5. Eliminar Contacto");
            Console.WriteLine("6. Salir");
            Console.Write("Elige una opción: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        contactManager.AddContact();
                        break;
                    case 2:
                        contactManager.ViewContacts();
                        break;
                    case 3:
                        contactManager.SearchContact();
                        break;
                    case 4:
                        contactManager.EditContact();
                        break;
                    case 5:
                        contactManager.DeleteContact();
                        break;
                    case 6:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
            }
        }
    }
}

public class Contact
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public Contact(int id, string name, string phone, string email, string address)
    {
        Id = id;
        Name = name;
        Phone = phone;
        Email = email;
        Address = address;
    }

    public override string ToString()
    {
        return $"{Id}    {Name}      {Phone}      {Email}     {Address}";
    }
}

public class ContactManager
{
    private List<Contact> contacts = new List<Contact>();
    private int nextId = 1;

    public void AddContact()
    {
        Console.WriteLine("Vamos a agregar ese contacto que te trae loco.");
        Console.Write("Digite el Nombre: ");
        var name = Console.ReadLine();
        Console.Write("Digite el Teléfono: ");
        var phone = Console.ReadLine();
        Console.Write("Digite el Email: ");
        var email = Console.ReadLine();
        Console.Write("Digite la dirección: ");
        var address = Console.ReadLine();

        Contact newContact = new Contact(nextId++, name, phone, email, address);
        contacts.Add(newContact);
        Console.WriteLine("Contacto agregado exitosamente.");
    }

    public void ViewContacts()
    {
        Console.WriteLine("Id           Nombre          Telefono            Email           Dirección");
        Console.WriteLine("___________________________________________________________________________");

        foreach (var contact in contacts)
        {
            Console.WriteLine(contact);
        }
    }

    public void EditContact()
    {
        ViewContacts();
        Console.WriteLine("Digite un Id de Contacto Para Editar");
        if (int.TryParse(Console.ReadLine(), out int idSeleccionado))
        {
            var contact = contacts.Find(c => c.Id == idSeleccionado);

            if (contact != null)
            {
                Console.Write($"El nombre es: {contact.Name}, Digite el Nuevo Nombre: ");
                contact.Name = Console.ReadLine();
                Console.Write($"El Teléfono es: {contact.Phone}, Digite el Nuevo Teléfono: ");
                contact.Phone = Console.ReadLine();
                Console.Write($"El Email es: {contact.Email}, Digite el Nuevo Email: ");
                contact.Email = Console.ReadLine();
                Console.Write($"La dirección es: {contact.Address}, Digite la nueva dirección: ");
                contact.Address = Console.ReadLine();
                Console.WriteLine("Contacto actualizado exitosamente.");
            }
            else
            {
                Console.WriteLine("Contacto no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Entrada no válida.");
        }
    }

    public void DeleteContact()
    {
        ViewContacts();
        Console.WriteLine("Digite un Id de Contacto Para Eliminar");
        if (int.TryParse(Console.ReadLine(), out int idSeleccionado))
        {
            var contact = contacts.Find(c => c.Id == idSeleccionado);

            if (contact != null)
            {
                Console.WriteLine("Seguro que desea eliminar? 1. Si, 2. No");
                if (int.TryParse(Console.ReadLine(), out int opcion) && opcion == 1)
                {
                    contacts.Remove(contact);
                    Console.WriteLine("Contacto eliminado exitosamente.");
                }
            }
            else
            {
                Console.WriteLine("Contacto no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Entrada no válida.");
        }
    }

    public void SearchContact()
    {
        ViewContacts();
        Console.WriteLine("Digite un Id de Contacto Para Mostrar");
        if (int.TryParse(Console.ReadLine(), out int idSeleccionado))
        {
            var contact = contacts.Find(c => c.Id == idSeleccionado);

            if (contact != null)
            {
                Console.WriteLine($"El nombre es: {contact.Name}");
                Console.WriteLine($"El Teléfono es: {contact.Phone}");
                Console.WriteLine($"El Email es: {contact.Email}");
                Console.WriteLine($"La dirección es: {contact.Address}");
            }
            else
            {
                Console.WriteLine("Contacto no encontrado.");
            }
        }
        else
        {
            Console.WriteLine("Entrada no válida.");
        }
    }
}