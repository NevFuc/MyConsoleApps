namespace Console_App1;

internal class MyMath
{
    public static void Init()
    {
        Console.WriteLine("Willkommen im Rechner!");
        bool weitermachen;

        do
        {
            Console.WriteLine("\nWas willst du tun?!");
            Console.WriteLine("ggt  = Grösster gemeinsamer Teiler berechnen");
            Console.WriteLine("kgv  = Kleinstes gemeinsames Vielfaches berechnen");
            Console.WriteLine("akg  = Kleinste Zahl, Grösste Zahl und Mittelwert");
            Console.WriteLine("swap = Vertauscht zwei Zahlen");
            Console.WriteLine("rev  = Drehe eine Zahlenfolge");
            Console.WriteLine("sort = Sortiere die Zahlenfolge");

            var option = Console.ReadLine()?.Trim().ToLower();
            show_result(option);

            Console.WriteLine("\nWeitermachen? (j/n)");
            var answer = Console.ReadLine()?.Trim().ToLower();
            weitermachen = answer == "j" || answer == "ja" || answer == "y" || answer == "yes" || answer == "true";
        } while (weitermachen);
    }

    public static int Calc_ggT(int a, int b)
    {
        if (b == 0) return a;

        return Calc_ggT(b, a % b);
    }

    public static int Calc_kgV(int a, int b)
    {
        return a * b / Calc_ggT(a, b);
    }

    public static int read_int()
    {
        int number;
        bool valid;

        do
        {
            Console.Write("Bitte eine ganze Zahl eingeben: ");
            var input = Console.ReadLine();
            valid = int.TryParse(input, out number);

            if (!valid)
            {
                Console.WriteLine("Ungültige Eingabe. Bitte eine Zahl eingeben.");
            }
            else if (number <= 0)
            {
                Console.WriteLine($"Nummer {number} muss größer als Null sein.");
                valid = false;
            }
        } while (!valid);

        return number;
    }

    public static int[] read_array()
    {
        Console.Write("Bitte die Anzahl an Zahlen eingeben: ");

        var iterations = read_int();

        var numbers = new int[iterations];

        for (var i = 0; i < iterations; i++) numbers[i] = read_int();

        return numbers;
    }

    public static int[] reverse_array(int[] array)
    {
        return array.Reverse().ToArray();
    }

    public static int[] sort_array(int[] array)
    {
        return array.OrderBy(x => x).ToArray();
    }

    public static int get_biggest_value(int[] numbers)
    {
        var biggest = numbers[0];
        foreach (var value in numbers)
            if (biggest < value)
                biggest = value;

        return biggest;
    }

    public static int get_smallest_value(int[] numbers)
    {
        var smallest = numbers[0];
        foreach (var value in numbers)
            if (smallest > value)
                smallest = value;

        return smallest;
    }

    public static double get_median_value(int[] numbers)
    {
        var total = 0.0;
        foreach (var value in numbers) total += value;
        return total / numbers.Length;
    }

    public static void Swap(ref int a, ref int b)
    {
        var temp = a;
        a = b;
        b = temp;
    }

    public static void show_result(string ausgeben)
    {
        int number1;
        int number2;

        switch (ausgeben)
        {
            case "ggt":
                number1 = read_int();
                number2 = read_int();
                var result_ggt = Calc_ggT(number1, number2);

                Console.WriteLine($"ggT von {number1} und {number2} ist {result_ggt}");
                break;
            case "kgv":
                number1 = read_int();
                number2 = read_int();
                var result_kgv = Calc_kgV(number1, number2);

                Console.WriteLine($"kgV von {number1} und {number2} ist {result_kgv}");
                break;
            case "akg":
                var numbers = read_array();
                var result_biggest = get_biggest_value(numbers);
                var result_smallest = get_smallest_value(numbers);
                var result_median = get_median_value(numbers);

                Console.WriteLine($"Biggest Number: {result_biggest}");
                Console.WriteLine($"Smallest Number: {result_smallest}");
                Console.WriteLine($"Median Number: {result_median}");
                break;

            case "swap":
                number1 = read_int();
                number2 = read_int();
                Swap(ref number1, ref number2);
                Console.WriteLine($"First Number: {number1}");
                Console.WriteLine($"Second Number: {number2}");
                break;

            case "rev":
                var reversed_array = reverse_array(read_array());
                Console.WriteLine("Reversed Numbers:");
                Console.WriteLine($"{string.Join(", ", reversed_array)}");
                break;

            case "sort":
                var sorted_array = sort_array(read_array());
                Console.WriteLine("Sorted Numbers:");
                Console.WriteLine($"{string.Join(", ", sorted_array)}");
                break;

            default:
                Console.WriteLine("Kein Gültiger Wert!");
                break;
        }
    }
}