Console.ForegroundColor = ConsoleColor.Green;
Console.BackgroundColor = ConsoleColor.Black;
Console.Title = "Sesion 01";
Console.WriteLine("Bienvenidos al curso de .net 9 en Galaxy Traning");

Console.Write("Ingrese su nombre:");
//valor podria ser nulo
string? nombre = Console.ReadLine();

Console.WriteLine("Ud. escirbió: {0}", nombre);

//nombre = null;
Console.WriteLine("La cantidad de caracteres que tiene la variable nombre es : {0}", nombre?.Length);
Console.WriteLine(new String('*', 100));
Console.Write("Ingrese su edad:");

int edad = int.Parse(Console.ReadLine()!);
Console.WriteLine("La edad ingrresasda es : {0}", edad);
DateTime resta = DateTime.Today.AddYears(-1 * edad);

Console.WriteLine("Ud. nació en el año {0:yyyy} y cayó el dia {1:dddd}", resta, resta);

Console.WriteLine("Fin del programa");
Console.ReadLine();
