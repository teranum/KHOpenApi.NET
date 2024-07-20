using ConsoleTables;
using System.Collections;
using System.Diagnostics;

namespace CSharp
{
    internal class SampleBase
    {
        // Api 객체선언
        public static KHOpenApi.NET.KHOpenApi api = null!;
        protected SampleBase()
        {
            Debug.Assert(api != null);
        }

        public SampleBase(nint Handle)
        {
            api = new(Handle);
        }

        // Main: 로그인 및 구현부 호출
        public async Task Main()
        {
            // 로그인
            int nRet = await api.ConnectAsync();
            if (nRet != 0)
            {
                print($"연결실패: {api.GetErrorMessge(nRet)}");
                return;
            }
            print($"연결성공");
            print($"접속서버: {(api.IsSimulation ? "모의투자" : "실투자")}");

            var apipath = api.AxApi.GetAPIModulePath();
            print($"API 경로: {apipath}");
        }

        // 구현부: 파생 클래스에서 구현
        public virtual Task ActionImplement() => Task.CompletedTask;


        // Helper Methods: print, GetInputAsync

        public static void print<T>(IEnumerable<T>? array)
        {
            if (array == null) return;
            if (array is string text)
            {
                Console.WriteLine(text);
                return;
            }

            var type = typeof(T);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (type is null || type.IsValueType || type == typeof(string))
            {
                Console.WriteLine($"array, Data Count = {array.Count()}");
                Console.ForegroundColor = ConsoleColor.Gray;
                int n = 0;
                var IdArray = array.Select(x => new KeyValuePair<int, T>(++n, x));
                ConsoleTable.From(IdArray).Configure(o => o.NumberAlignment = Alignment.Right).Write(Format.MarkDown);
            }
            else
            {
                Console.WriteLine($"{type.Name}[], Field Count = {type.GetProperties().Length}, Data Count = {array.Count()}");
                Console.ForegroundColor = ConsoleColor.Gray;
                ConsoleTable.From(array).Configure(o => o.NumberAlignment = Alignment.Right).Write(Format.MarkDown);
            }
        }

        public static void print(object? data)
        {
            if (data == null) return;
            var type = data.GetType();
            if (type.IsValueType || type == typeof(string))
            {
                Console.WriteLine(data);
                return;
            }
            List<KeyValuePair<string, object>> keyValuePairs = [];
            if (data is IEnumerable ienum)
            {
                int n = 0;
                foreach (var item in ienum)
                {
                    keyValuePairs.Add(new($"{++n}", item));
                }
                ConsoleTable.From(keyValuePairs).Write(Format.MarkDown);
                return;
            }

            foreach (var prop in type.GetProperties())
            {
                keyValuePairs.Add(new(prop.Name, prop.GetValue(data) ?? string.Empty));
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{type.Name}, Field Count = {keyValuePairs.Count}");
            Console.ForegroundColor = ConsoleColor.Gray;
            ConsoleTable.From(keyValuePairs).Write(Format.MarkDown);
        }

        public static void print(string RecName, string[] ColNames, string[][] data)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{RecName}, Field Count = {ColNames.Length}, Row Count = {data.Length}");
            Console.ForegroundColor = ConsoleColor.Gray;

            var table = new ConsoleTable();

            int nColumCount = ColNames.Length;
            if (nColumCount > 0)
            {
                table.AddColumn(ColNames);
            }
            else
            {
                var columNames = Enumerable.Range(1, data[0].Length).Select(x => x.ToString());
                table.AddColumn(columNames);
            }
            foreach (var row in data)
            {
                table.AddRow(row);
            }

            table.Write(Format.MarkDown);
        }

        public static async Task<string> GetInputAsync(string msg) => await Task.Run(() =>
        {
            Console.Write(msg);
            return Console.ReadLine() ?? string.Empty;
        });

        public static async Task<ConsoleKey> GetReadKeyAsync(string msg = "") => await Task.Run(() =>
        {
            if (msg.Length > 0) Console.Write(msg);
            return Console.ReadKey().Key;
        });

    }
}
