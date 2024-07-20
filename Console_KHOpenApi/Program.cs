using CSharp;
using System.Drawing;
using System.Windows.Forms;

namespace ConsoleApp;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        Application.EnableVisualStyles();
        Form form = new()
        {
            FormBorderStyle = FormBorderStyle.FixedToolWindow,
            ShowInTaskbar = false,
            StartPosition = FormStartPosition.Manual,
            Location = new Point(-2000, -2000),
            Size = new Size(1, 1),
        };
        form.Shown += (s, e) => { MainStart(form.Handle); };
        Application.Run(form);
    }

    static async void MainStart(nint Hanlde)
    {
        await new SampleBase(Hanlde).Main();

        while (true)
        {
            // 샘플 넘버 입력
            ConsoleColor dftForeColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine();
            Console.Write("샘플넘버 입력(01~): ");
            var input = Console.ReadLine();
            Console.ForegroundColor = dftForeColor;

            if (string.IsNullOrEmpty(input)) continue;
            int.TryParse(input, out var number);
            if (number == 0) continue;

            // 샘플 클래스 찾기
            var type = Type.GetType($"CSharp._{number:00}");
            if (type == null)
            {
                Console.WriteLine("잘못된 샘플넘버 입니다.");
                continue;
            }

            // 샘플 클래스 실행
            await ((SampleBase)Activator.CreateInstance(type)!).ActionImplement();
        }
    }
}
