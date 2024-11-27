// See https://aka.ms/new-console-template for more information
using AgendaDeContactos;
using System.Collections;
// Tenemos que instalar la libreria MySql Data en nuget para poder utilizarlo
using MySql.Data.MySqlClient; // Utilizamos esto para la conexion SQL
// Agenda de Contactos

//Permite al usuario agregar, buscar, editar y eliminar contactos. Si no se encuentra el usuario tirar una excepcion
//Guarda los datos en un archivo de texto o en una base de datos simple.
Usuario admin = new Usuario("Thiago","Viccichi",1158582332);
// Contactos ya cargados para el funcionamiento del sistema:
Contacto a1 = new Contacto("Juan", "Pérez", 123456789);
Contacto a2 = new Contacto("María", "López", 987654321);
Contacto a3 = new Contacto("Carlos", "Gómez", 456123789);
Contacto a4 = new Contacto("Ana", "Martínez", 741852963);
Contacto a5 = new Contacto("Luis", "Hernández", 159753486);
Contacto a6 = new Contacto("Lucía", "Rodríguez", 258963147);
Contacto a7 = new Contacto("Miguel", "Sánchez", 369258147);
Contacto a8 = new Contacto("Elena", "Ramírez", 654321987);
Contacto a9 = new Contacto("José", "Torres", 753159846);
// Agregando contactos a la lista de contactos del objecto admin
admin.AgregarContacto(a1);
admin.AgregarContacto(a2);
admin.AgregarContacto(a3);
admin.AgregarContacto(a4);
admin.AgregarContacto(a5);
admin.AgregarContacto(a6);
admin.AgregarContacto(a7);
admin.AgregarContacto(a8);
admin.AgregarContacto(a9);
// Inciando el menu
Console.WriteLine($"Bienvenido a la Agende de Contactos de {admin.NOMBRE},\nelije cuales de las siguientes opciones quieres REALIZAR , INDICANDO SU NUMERO");
bool condicionWhile = false;
while (condicionWhile == false) {
    Console.Clear();
    Console.WriteLine("----------------------");
    Console.WriteLine("1 - Agregar un Contacto ");
    Console.WriteLine("2 - Buscar un Contacto");
    Console.WriteLine("3 - Editar un Contacto");
    Console.WriteLine("4 - Eliminar un Contacto");
    Console.WriteLine("0 - Salir del MENU");
    Console.WriteLine("----------------------");
    string opcionMenu = Console.ReadLine();
    try
    {
        switch (opcionMenu)
        {
            case "1":
                Console.WriteLine("Opcion Agregar Contacto.");
                Contacto nuevo = DatosContacto();
                admin.AgregarContacto(nuevo);
                Console.WriteLine("Contacto Agendado! ESTOS SON SUS DATOS:");
                Console.WriteLine($"NOMBRE:{nuevo.NOMBRE}, APELLIDO : {nuevo.APELLIDO}\nNUMERO: {nuevo.NUMERO}");
                Console.ReadKey();
                break;
            case "2":
                ArrayList listaContactos = admin.LISTACONTACTOS;
                ArrayList listaEncontrados = new ArrayList(); 
                Console.WriteLine("Opcion Buscar Contacto");
                Console.WriteLine("Indica el nombre del Contacto que estas buscando:");
                string consulta = Console.ReadLine();
                foreach (Contacto x in listaContactos)
                {
                    if (x.NOMBRE.Equals(consulta))
                    {
                        Console.WriteLine("CONTACTO ENCONTRADO!");
                        listaEncontrados.Add(x);
                    }
                    else {
                        Console.WriteLine("Error");
                    }
                }
                Console.WriteLine("Estos son los CONTACTOS ENCONTRADOS CON ESE NOMBRE:");
                foreach (Contacto b in listaEncontrados)
                {
                    Console.WriteLine($"NOMBRE: {b.NOMBRE}, APELLIDO: {b.APELLIDO}");
                }
                Console.ReadKey();
                break;
            case "3":
                Console.WriteLine("Opcion Editar Contacto");
                Console.WriteLine("Cual de los sigueintes contactos quieres EDITAR?");
                foreach (Contacto c in admin.LISTACONTACTOS) { 
                    Console.WriteLine($"NOMBRE:{c.NOMBRE},APELLIDO:{c.APELLIDO} y NUMERO:{c.NUMERO}");
                }
                Console.WriteLine("Indica el NUMERO del Contacto que quieres EDITAR");
                int opcionAEditar = int.Parse(Console.ReadLine());
                foreach (Contacto d in admin.LISTACONTACTOS) {
                    if (d.NUMERO == opcionAEditar) {
                        Console.WriteLine("Que quieres EDITAR de este CONTACTO: 1- NOMBRE 2- APELLIDO 3-NUMERO");
                        string opcionEditar = Console.ReadLine();
                        switch (opcionEditar) {
                            case "1":
                                Console.WriteLine("Cual es el nombre que quieres PONER:");
                                string nuevoNombre = Console.ReadLine();
                                d.NOMBRE = nuevoNombre;
                                break;
                            case "2":
                                Console.WriteLine("Cual es el APELLIDO que quieres ponerle: ");
                                string apellidoNuevo = Console.ReadLine();
                                d.APELLIDO = apellidoNuevo;
                                break;
                            case "3":
                                Console.WriteLine("Cual es el NUEVO NUMERO que quieres asignarle: ");
                                int nuevoNumero = int.Parse(Console.ReadLine());
                                d.NUMERO = nuevoNumero;
                                break;
                            default :
                                {
                                    Console.WriteLine("Te equivocaste al ASIGNARLE EL NUMERO intentalo nuevamente.");
                                    break;
                                }
                        }
                        Console.WriteLine("Cambios HECHOS!");
                        foreach (Contacto c in admin.LISTACONTACTOS)
                        {
                            Console.WriteLine($"NOMBRE:{c.NOMBRE},APELLIDO:{c.APELLIDO} y NUMERO:{c.NUMERO}");
                        }
                    }
                }
                Console.ReadKey();
                break;
            case "4":
                Console.WriteLine("Opcion Eliminar Contacto");
                foreach (Contacto x in admin.LISTACONTACTOS) {
                    Console.WriteLine($"NOMBRE:{x.NOMBRE},APELLIDO:{x.APELLIDO} y NUMERO:{x.NUMERO}");
                }
                Console.WriteLine("Indica el apellido del CONTACTO QUE QUIERES ELIMINAR!");
                string apellidoEliminar = Console.ReadLine();
                foreach (Contacto b in admin.LISTACONTACTOS.ToArray()) {
                    if (b.APELLIDO == apellidoEliminar) {
                        admin.LISTACONTACTOS.Remove(b);
                        Console.WriteLine("CONTACTO ELIMINADO");
                    } 
                }
                foreach (Contacto x in admin.LISTACONTACTOS)
                {
                    Console.WriteLine($"NOMBRE:{x.NOMBRE},APELLIDO:{x.APELLIDO} y NUMERO:{x.NUMERO}");
                }
                Console.ReadKey();
                break;
            case "0":
                Console.WriteLine("Opcion SALIR DEL MENU");
                condicionWhile = true;
                break;
            default:
                throw new OpcionIncorrecta("Elegiste una OPCION INCORRECTA, intentalo denuevo");
        }
    }
    catch (Exception e) {
        Console.WriteLine("Error: " + e.Message);
        Console.ReadKey();
        Console.Clear();
    }
}
// Conexion MYSQL
// Instalamos el paquete nuget sql
string connectionString = "Server=localhost;Database=MiBaseDeDatos;Uid=root;Pwd=1234;";
using (MySqlConnection connection = new MySqlConnection(connectionString))
{
    connection.Open();
    Console.WriteLine("Conexión exitosa a MySQL.");

    // Leer el archivo SQL
    string script = File.ReadAllText(@"C:\\Users\\Thiago\\source\\repos\\AgendaDeContactos\\MiBaseDeDatos.sql");
    // Consultas:
    //string query = "SELECT * FROM Usuario"; // Esta es la consulta

    //using (MySqlCommand cmd = new MySqlCommand(query, connection))
    //using (MySqlDataReader reader = cmd.ExecuteReader()) // Con esto leemos el archivo
    ////{
    ///while (reader.Read())
    //{
    //Console.WriteLine($"ID: {reader["ID"]}, Nombre: {reader["Nombre"]}, Teléfono: {reader["Telefono"]}");
    //}
    //}
    // Insertar datos: 
    //string insertQuery = "INSERT INTO Contactos (Nombre, Telefono) VALUES (@nombre, @telefono)"; // @nombre va a ser en la columna que vamos a agregar el dato 
    //using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection)) // De la clase MySqlCommand vamos a crear un objeto llamado cmd que va a tener la consulta(insertQuery) y la Conexion a la base de datos (connection)
    //{
    //cmd.Parameters.AddWithValue("@nombre", "Juan Pérez"); // Aca  vamos a agregar los datos a la base de datos aca la columna @nombre va a ser el dato que asignemos es decir @nombre = JUan Perez
    //cmd.Parameters.AddWithValue("@telefono", "123456789"); 
    //cmd.ExecuteNonQuery(); // Aca terminamos la consulta
    //}

    //Actualizar datos: 
    //string updateQuery = "UPDATE Contactos SET Telefono = @telefono WHERE ID = @id";
    //using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
    //{
    //cmd.Parameters.AddWithValue("@telefono", "987654321"); // La tabla que vamos a modificar y el valor
    //cmd.Parameters.AddWithValue("@id", 1); // Aca va el where con id = 1 o el que queremos modificar
    // cmd.ExecuteNonQuery();
    //}
    // Eliminar un dato:
    //string deleteQuery = "DELETE FROM Contactos WHERE ID = @id";

    //using (MySqlCommand cmd = new MySqlCommand(deleteQuery, connection))
    //{
    //cmd.Parameters.AddWithValue("@id", 1); // Aca va el Where
    //cmd.ExecuteNonQuery();
    //}
    // Crear un comando para ejecutar el script
    MySqlCommand command = new MySqlCommand(script, connection);
    command.ExecuteNonQuery();
    // Vamos a darle valores a nuestra base de datos!
    string insercionDatos = "INSERT INTO usuarios (Nombre,Edad) VALUES (@nombre,@edad)";
    using (MySqlCommand cmd = new MySqlCommand(insercionDatos, connection)) {
        cmd.Parameters.AddWithValue("@nombre","Thiago");
        cmd.Parameters.AddWithValue("@edad","2341224");
        cmd.ExecuteNonQuery (); // Terminamos la consulta
    }
    // Realizamos la consulta
    string consulta = "SELECT * FROM usuarios";
    using (MySqlCommand cmd = new MySqlCommand(consulta, connection))
    using (MySqlDataReader reader = cmd.ExecuteReader()) {
        while (reader.Read())
        {
            Console.WriteLine($"ID: {reader["ID"]}, Nombre: {reader["Nombre"]}, Teléfono: {reader["Edad"]}");
        }
    }
        Console.WriteLine("Base de datos creada desde el archivo SQL.");
}
static Contacto DatosContacto() {
    Console.WriteLine("Inserte el numero del Contacto a Guardar:");
    int numeroContacto = int.Parse(Console.ReadLine());
    Console.WriteLine("Inserte el NOMBRE del Contacto");
    string nombreContacto = Console.ReadLine();
    Console.WriteLine("Inserte el APELLIDO del contacto");
    string apellidoContacto = Console.ReadLine();
    Contacto nuevoContacto = new Contacto(nombreContacto,apellidoContacto,numeroContacto);
    return nuevoContacto;
}
