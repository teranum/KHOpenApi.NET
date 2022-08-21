# KHOpenApi.NET 테스트

NET6.0 WinForms
---------------

#### Form1.cs

```c#
using KHOpenApi.NET;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // ocx인터페이스 추가
        AxKHOpenAPI axKHOpenAPI;

        public Form1()
        {
            InitializeComponent();
            // 새로 추가
            axKHOpenAPI = new AxKHOpenAPI();
            axKHOpenAPI.OnEventConnect += new _DKHOpenAPIEvents_OnEventConnectEventHandler(axKHOpenAPI_OnEventConnect);
            Controls.Add(axKHOpenAPI);
        }

        // 로그인 이벤트 핸들러
        private void axKHOpenAPI_OnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                textBox1.Text = "로그인 성공";
            }
            else
            {
                textBox1.Text = "로그인 실패";
            }
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            // 로그인 요청
            axKHOpenAPI.CommConnect();
        }

    }
}

```

NET6.0 WPF
---------------
프로젝트 설정 추가 : UseWindowsForms=True

#### MainWindow.xaml

```xaml
<Window x:Class="WpfApp1.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp1"
        mc:Ignorable="d"
        Title="MainWindow" Height="223" Width="371">
    <Grid>
        <WindowsFormsHost Name="axContainer" Height="0" Width="0"/>
        <Button x:Name="button_login" Content="로그인" HorizontalAlignment="Left" Margin="66,46,0,0" VerticalAlignment="Top" Width="87" Click="button_login_Click"/>
        <TextBox x:Name="textBox1" HorizontalAlignment="Left" Margin="66,92,0,0" TextWrapping="Wrap" Text="TextBox" VerticalAlignment="Top" Width="132" Height="20"/>
    </Grid>
</Window>
```
#### MainWindow.xaml.cs

```c#
using KHOpenApi.NET;
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // ocx인터페이스 추가
        private AxKHOpenAPI axKHOpenAPI;

        public MainWindow()
        {
            InitializeComponent();
            // ActiveX 세팅
            axKHOpenAPI = new AxKHOpenAPI();
            axKHOpenAPI.OnEventConnect += new _DKHOpenAPIEvents_OnEventConnectEventHandler(this.axKHOpenAPI_OnEventConnect);
            axContainer.Child = axKHOpenAPI;
        }

        // 로그인 이벤트 핸들러
        private void axKHOpenAPI_OnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                textBox1.Text = "로그인 성공";
            }
            else
            {
                textBox1.Text = "로그인 실패";
            }
        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            // 로그인 요청
            axKHOpenAPI.CommConnect();
        }
    }
}

```

