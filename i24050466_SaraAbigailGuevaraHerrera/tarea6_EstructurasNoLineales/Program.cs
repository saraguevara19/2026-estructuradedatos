using System;
using System.Collections.Generic;

// Clase para guardar los nodos del arbol
class Nodo
{
    public int Valor;
    public Nodo Izquierdo;
    public Nodo Derecho;

    public Nodo(int valor)
    {
        Valor = valor;
        Izquierdo = null;
        Derecho = null;
    }
}

class Program
{
    // Guarda los nodos y sus conexiones del grafo
    static Dictionary<string, List<string>> grafo =
        new Dictionary<string, List<string>>();

    // Guarda la raiz del arbol
    static Nodo raiz = null;

    static void Main()
    {
        int opcion;

        do
        {
            Console.WriteLine("\n===== MENU PRINCIPAL =====");
            Console.WriteLine("1. Grafos");
            Console.WriteLine("2. Arboles");
            Console.WriteLine("3. Salir");
            Console.Write("Selecciona una opcion: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    MenuGrafo();
                    break;

                case 2:
                    MenuArbol();
                    break;

                case 3:
                    Console.WriteLine("Programa terminado.");
                    break;

                default:
                    Console.WriteLine("Opcion incorrecta,favor de intentarlo de nuevo con la corecta.");
                    break;
            }

        } while (opcion != 3);
    }
#region  1.grafos
    // =================================
    // MENU DE GRAFOS
    // =================================

    static void MenuGrafo()
    {// aplicaciones aplicadas:gogle maps, redes sociales, recomendacion de peliculaso musica
        int opcion;

        do
        {
            Console.WriteLine("\n===== MENU DE GRAFOS =====");
            Console.WriteLine("1. eliminar grafo entero");
            Console.WriteLine("2. Agregar nodo");
            Console.WriteLine("3. Conectar nodos");
            Console.WriteLine("4. Eliminar nodo");
            Console.WriteLine("5. Mostrar grafo");
            Console.WriteLine("6. Regresar");
            Console.Write("Selecciona: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    // Limpia el grafo para crear uno nuevo
                    grafo.Clear();
                    Console.WriteLine("Grafo eliminado.");
                    break;

                case 2:
                    AgregarNodo();
                    break;

                case 3:
                    ConectarNodos();
                    break;

                case 4:
                    EliminarNodo();
                    break;

                case 5:
                    MostrarGrafo();
                    break;
            }

        } while (opcion != 6);
    }

    // Agrega un nuevo nodo al grafo
    static void AgregarNodo()
    {
        Console.Write("Nombre del nodo: ");
        string nombre = Console.ReadLine();

        if (!grafo.ContainsKey(nombre))
        {
            grafo[nombre] = new List<string>();
            Console.WriteLine("Nodo agregado es: " + nombre);
            Console.WriteLine("El nodo se agrego correctamente, ahora puede conectarlo con otro nodo.");
       }
        else
        {
            Console.WriteLine("Ese nodo ya existe favor de poner otro distinto");
        }
    }

    // Conecta dos nodos existentes
    static void ConectarNodos()
    {
        Console.Write("Primer nodo: ");
        string a = Console.ReadLine();

        Console.Write("Segundo nodo: ");
        string b = Console.ReadLine();

        if (grafo.ContainsKey(a) && grafo.ContainsKey(b) && a != b)
        {
            if (!grafo[a].Contains(b))
            {
                grafo[a].Add(b);
                grafo[b].Add(a);
                Console.WriteLine("Nodos conectados.");
            }
            else
            {
                Console.WriteLine("Ya existe esa conexion.");
            }
        }
        else
        {
            Console.WriteLine("Los nodos no existen o son iguales,favor de checar.");
        }
    }

    // Elimina un nodo y todas sus conexiones
    static void EliminarNodo()
    {
        Console.Write("Nodo que deseas eliminar: ");
        string nombre = Console.ReadLine();

        if (grafo.ContainsKey(nombre))
        {
            grafo.Remove(nombre);

            // Quita las conexiones hacia el nodo eliminado
            foreach (var nodo in grafo.Values)
            {
                nodo.Remove(nombre);
            }

            Console.WriteLine("Nodo eliminado.");
        }
        else
        {
            Console.WriteLine("Nodo no encontrado.");
        }
    }
  
    // Muestra todos los nodos y sus conexiones
    static void MostrarGrafo()
    {
        if (grafo.Count == 0)
        {
            Console.WriteLine("El grafo esta vacio.");
            return;
        }

        foreach (var nodo in grafo)
        {
            Console.Write(nodo.Key + " conecta con: ");

            foreach (var conexion in nodo.Value)
            {
                Console.Write(conexion + " ");
            }

            Console.WriteLine();
        }
        #endregion
    }

#region 2.arboles
//aplicacion artpetas de computadoras,menu de aplicaciones y organigrama de trabajo
    // =================================
    // MENU DE ARBOLES
    // =================================

    static void MenuArbol()
    {
        int opcion;

        do
        {
            Console.WriteLine("\n===== MENU DE ARBOLES =====");
            Console.WriteLine("1. Crear arbol");
            Console.WriteLine("2. Agregar elemento");
            Console.WriteLine("3. Eliminar elemento");
     
            Console.WriteLine("4. Mostrar arbol");
            Console.WriteLine("5. Regresar");
            Console.Write("Selecciona: ");

            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    // Reinicia el arbol y deja la raiz vacia
                    raiz = null;
                    Console.WriteLine("Arbol creado.");
                    break;

                case 2:
                    Console.Write("Numero a agregar: ");
                    int numero = int.Parse(Console.ReadLine());

                    // Inserta el numero en el arbol
                    raiz = Agregar(raiz, numero);
                    Console.WriteLine("Elemento agregado.");
                    break;

                case 3:
                    Console.Write("Numero a eliminar: ");
                    int eliminar = int.Parse(Console.ReadLine());

                    // Busca y elimina el numero del arbol
                    raiz = Eliminar(raiz, eliminar);
                    Console.WriteLine("Operacion realizada.");
                    break;

                case 4:
                    Console.WriteLine("Elementos del arbol:");

                    if (raiz == null)
                        Console.WriteLine("El arbol esta vacio.");
                    else
                        Mostrar(raiz);

                    Console.WriteLine();
                    break;
            }

        } while (opcion != 5);
    }

    // Agrega numeros ordenados al arbol
    static Nodo Agregar(Nodo actual, int valor)
    {
        if (actual == null)
            return new Nodo(valor);

        // Los numeros menores van a la izquierda
        if (valor < actual.Valor)
            actual.Izquierdo = Agregar(actual.Izquierdo, valor);

        // Los numeros mayores van a la derecha
        else if (valor > actual.Valor)
            actual.Derecho = Agregar(actual.Derecho, valor);

        return actual;
    }

    // Elimina un elemento del arbol
    static Nodo Eliminar(Nodo actual, int valor)
    {
        if (actual == null)
            return null;

        if (valor < actual.Valor)
            actual.Izquierdo = Eliminar(actual.Izquierdo, valor);

        else if (valor > actual.Valor)
            actual.Derecho = Eliminar(actual.Derecho, valor);

        else
        {
            // Si no tiene hijo izquierdo, regresa el derecho
            if (actual.Izquierdo == null)
                return actual.Derecho;

            // Si no tiene hijo derecho, regresa el izquierdo
            if (actual.Derecho == null)
                return actual.Izquierdo;

            // Busca el menor valor del lado derecho
            Nodo menor = actual.Derecho;

            while (menor.Izquierdo != null)
                menor = menor.Izquierdo;

            // Reemplaza el valor que se va a eliminar
            actual.Valor = menor.Valor;

            actual.Derecho = Eliminar(actual.Derecho, menor.Valor);
        }

        return actual;
    }

    // Muestra los valores del arbol de menor a mayor
    static void Mostrar(Nodo actual)
    {
        if (actual != null)
        {
            Mostrar(actual.Izquierdo);
            Console.Write(actual.Valor + " ");
            Mostrar(actual.Derecho);
        }
 
    }
    #endregion
}
