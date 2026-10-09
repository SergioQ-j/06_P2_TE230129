// Top-level statements: El programa arranca directamente aquí, sin configuraciones previas.

Console.WriteLine("--- SISTEMA DE INSPECCIÓN DE LOTE ---");

// OBJETO: 'loteActual' es el objeto físico creado en memoria a partir de la plantilla CeldaInspeccion.
CeldaInspeccion loteActual = new CeldaInspeccion();

int piezaActual = 1;

// El ciclo se repite usando un Atributo del objeto (loteActual.TotalPiezas)
while (piezaActual <= loteActual.TotalPiezas)
{
    Console.Write($"Estado de la pieza {piezaActual} (1=Correcta, 0=Defectuosa): ");
    string input = Console.ReadLine();

    if (int.TryParse(input, out int valor))
    {
        // Se llama al Método 'RegistrarPieza' del objeto
        bool registrado = loteActual.RegistrarPieza(valor);

        if (registrado)
        {
            piezaActual++;
        }
        else
        {
            Console.WriteLine("Error: Valor rechazado. Introduzca únicamente 1 o 0.\n");
        }
    }
    else
    {
        Console.WriteLine("Error: Entrada no numérica. Introduzca 1 o 0.\n");
    }
}

// Se llama a los Métodos del objeto para obtener los resultados finales
double porcentaje = loteActual.CalcularPorcentaje();
string estadoLote = loteActual.EvaluarLote(porcentaje);

Console.WriteLine("\n--- RESULTADOS DEL LOTE ---");
// Se accede a los Atributos del objeto para imprimirlos
Console.WriteLine($"Piezas correctas: {loteActual.Correctas}");
Console.WriteLine($"Piezas defectuosas: {loteActual.Defectuosas}");
Console.WriteLine($"Porcentaje de efectividad: {porcentaje} %");
Console.WriteLine($"Estado del lote: {estadoLote}");

Console.ReadKey();


// CLASE: Es la plantilla o molde que define cómo funciona y qué datos guarda la celda de inspección.
class CeldaInspeccion
{
    // ATRIBUTOS (Propiedades): Guardan la información actual de la celda de inspección.
    public int Correctas { get; private set; } = 0;
    public int Defectuosas { get; private set; } = 0;
    public int TotalPiezas { get; private set; } = 10;

    // MÉTODOS: Son las acciones que la celda de inspección sabe realizar.

    // Método 1: Actualiza los contadores internos (Atributos) basándose en lo que recibe.
    public bool RegistrarPieza(int valor)
    {
        if (valor == 1)
        {
            Correctas++;
            return true;
        }
        else if (valor == 0)
        {
            Defectuosas++;
            return true;
        }
        return false;
    }

    // Método 2: Calcula y devuelve el porcentaje usando sus propios Atributos.
    public double CalcularPorcentaje()
    {
        if (TotalPiezas == 0) return 0;
        return ((double)Correctas / TotalPiezas) * 100;
    }

    // Método 3: Recibe el porcentaje y toma una decisión lógica.
    public string EvaluarLote(double porcentaje)
    {
        if (porcentaje >= 90)
            return "ACEPTADO";
        else
            return "RECHAZADO";
    }
}