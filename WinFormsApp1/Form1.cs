using KFOpenApi.NET;
using KHOpenApi.NET;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        // ocx�������̽� �߰�
        private AxKHOpenAPI axKHOpenAPI; // ���� (������)
        private AxKFOpenAPI axKFOpenAPI; // �ؿ� (������ �۷ι�)

        public Form1()
        {
            InitializeComponent();

            Text = "WinForm " + (Environment.Is64BitProcess ? "(64��Ʈ)" : "(32��Ʈ)");

            // ActiveX ����
            axKHOpenAPI = new AxKHOpenAPI(Handle);
            axKHOpenAPI.OnEventConnect += axKHOpenAPI_OnEventConnect;
            button_login_KH.Enabled = axKHOpenAPI.Created;

            axKFOpenAPI = new AxKFOpenAPI(Handle);
            axKFOpenAPI.OnEventConnect += axKFOpenAPI_OnEventConnect;
            button_login_KF.Enabled = axKFOpenAPI.Created;
        }

        // �����α��� �̺�Ʈ �ڵ鷯
        private void axKHOpenAPI_OnEventConnect(object sender, _DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                listBox_result.Items.Add("���� �α��� ����");
            }
            else
            {
                listBox_result.Items.Add("���� �α��� ����");
            }
        }

        // �ؿܷα��� �̺�Ʈ �ڵ鷯
        private void axKFOpenAPI_OnEventConnect(object sender, _DKFOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                listBox_result.Items.Add("�ؿ� �α��� ����");
            }
            else
            {
                listBox_result.Items.Add("�ؿ� �α��� ����");
            }
        }

        private void button_login_KH_Click(object sender, EventArgs e)
        {
            // ���� �α��� ��û
            if (axKHOpenAPI.GetConnectState() == 0)
            {
                listBox_result.Items.Add("���� �α��� ��û");
                axKHOpenAPI.CommConnect();
            }
        }

        private void button_login_KF_Click(object sender, EventArgs e)
        {
            // �ؿ� �α��� ��û
            if (axKFOpenAPI.GetConnectState() == 0)
            {
                listBox_result.Items.Add("�ؿ� �α��� ��û");
                axKFOpenAPI.CommConnect(1);
            }
        }

        private void button_KH_info_Click(object sender, EventArgs e)
        {
            _ = ����_��������_��ûAsync();
        }

        private void button_KH_chart_Click(object sender, EventArgs e)
        {
            _ = ����_�Ϻ���Ʈ_��ûAsync();
        }

        async Task ����_��������_��ûAsync()
        {
            if (axKHOpenAPI.GetConnectState() == 0)
            {
                listBox_result.Items.Add("�α����� ���� ���ּ���.");
                return;
            }

            // ���� �������� ��û
            string[] reqName =
                [
                "�����ڵ�",
                "�����",
                "�ð�",
                "��",
                "����",
                "���簡",
                // ...
                ];

            string result = string.Empty;
            axKHOpenAPI.SetInputValue("�����ڵ�", textBox_KH_code.Text);
            int nRet = await axKHOpenAPI.CommRqDataAsync("����������û", "OPT10001", 0, "0101", (e) => 
            {
                result = $"[{e.sTrCode}], {e.sRQName} : ";
                for (int i = 0; i < reqName.Length; i++)
                {
                    result += axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, reqName[i]).Trim() + " ";
                }
            }).ConfigureAwait(true);

            if (nRet == 0)
            {
                listBox_result.Items.Add(result);
            } else
            {
                listBox_result.Items.Add("����������û ����");
            }
        }

        async Task ����_�Ϻ���Ʈ_��ûAsync()
        {
            if (axKHOpenAPI.GetConnectState() == 0)
            {
                listBox_result.Items.Add("�α����� ���� ���ּ���.");
                return;
            }

            // ���� ��Ʈ ��û
            string[] reqName =
                [
                "����",
                "�ð�",
                "��",
                "����",
                "���簡",
                "�ŷ���",
                // ...
                ];

            string result = string.Empty;
            List<string> listChart = [];
            axKHOpenAPI.SetInputValue("�����ڵ�", textBox_KH_code.Text);
            int nRet = await axKHOpenAPI.CommRqDataAsync("������Ʈ��û", "OPT10081", 0, "0101", (e)=>
            {
                // �����ڵ�
                string �����ڵ� = axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, 0, "�����ڵ�").Trim();
                // ������ ����
                int nRepeatCnt = axKHOpenAPI.GetRepeatCnt(e.sTrCode, e.sRQName);
                result = $"[{e.sTrCode}], {e.sRQName} : {�����ڵ�} - {nRepeatCnt}";

                for (int i = 0; i < nRepeatCnt; i++)
                {
                    string line = $"{i:d3} : ";
                    for (int j = 0; j < reqName.Length; j++)
                    {
                        line += axKHOpenAPI.GetCommData(e.sTrCode, e.sRQName, i, reqName[j]).Trim() + " ";
                    }
                    listChart.Add(line);
                }
            }).ConfigureAwait(true);

            if (nRet == 0)
            {
                listBox_result.Items.Add(result);

                foreach (var line in listChart)
                {
                    listBox_result.Items.Add(line);
                }
            }
            else
            {
                listBox_result.Items.Add("������Ʈ��û ����");
            }
        }
    }
}
