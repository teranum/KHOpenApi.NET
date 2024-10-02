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
            button_login_KH.Enabled = axKHOpenAPI.Created;

            axKFOpenAPI = new AxKFOpenAPI(Handle);
            button_login_KF.Enabled = axKFOpenAPI.Created;
        }

        private async void button_login_KH_Click(object sender, EventArgs e)
        {
            // ���� �α��� ��û
            if (axKHOpenAPI.GetConnectState() == 0)
            {
                log_list.Items.Add("���� �α��� ��û��...");
                var (ret, msg) = await axKHOpenAPI.CommConnectAsync();
                if (ret == 0)
                {
                    log_list.Items.Add("���� �α��� ����");
                }
                else
                {
                    log_list.Items.Add("���� �α��� ����: " + msg);
                }
            }
        }

        private async void button_login_KF_Click(object sender, EventArgs e)
        {
            // �ؿ� �α��� ��û
            if (axKFOpenAPI.GetConnectState() == 0)
            {
                log_list.Items.Add("�ؿ� �α��� ��û��...");
                var (ret, msg) = await axKFOpenAPI.CommConnectAsync(1);
                if (ret == 0)
                {
                    log_list.Items.Add("�ؿ� �α��� ����");
                }
                else
                {
                    log_list.Items.Add("�ؿ� �α��� ����: " + msg);
                }
            }
        }

        private async void button_KH_info_Click(object sender, EventArgs e)
        {
            if (axKHOpenAPI.GetConnectState() == 0)
            {
                log_list.Items.Add("�α����� ���� ���ּ���.");
                return;
            }

            // ���� �������� ��û
            var response = await axKHOpenAPI.RequestTrAsync("OPT10001"
                , [("�����ڵ�", textBox_KH_code.Text)]
                , ["�����ڵ�", "�����", "�ð�", "��", "����", "���簡"]
                , []);
            if (response.nErrCode != 0)
            {
                log_list.Items.Add($"����������û ����: {response.rsp_msg}");
            }

            for (int i = 0; i < response.OutputSingleDatas.Length; i++)
            {
                log_list.Items.Add($"{response.InSingleFields[i]}: {response.OutputSingleDatas[i]}");
            }
        }

        private async void button_KH_chart_Click(object sender, EventArgs e)
        {
            if (axKHOpenAPI.GetConnectState() == 0)
            {
                log_list.Items.Add("�α����� ���� ���ּ���.");
                return;
            }
            log_list.Items.Clear();

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

            Dictionary<string, string> indatas = new()
            {
                { "�����ڵ�", textBox_KH_code.Text },
                { "��������", string.Empty },
                { "�����ְ�����", "1" },
            };

            var resposeTrData = await axKHOpenAPI.RequestTrAsync("OPT10081", indatas, [], reqName);
            if (resposeTrData.nErrCode != 0)
            {
                log_list.Items.Add($"������Ʈ��û ����: {resposeTrData.rsp_msg}");
                return;
            }

            log_list.Items.Add($"[{resposeTrData.tr_cd}] : {resposeTrData.OutputMultiDatas.Count}��");
            resposeTrData.OutputMultiDatas.Select(x => string.Join(" ", x)).ToList().ForEach(x => log_list.Items.Add(x));


            /* ���� ��û�� CommRqDataAsync �̿��� ���
            string result = string.Empty;
            List<string> listChart = [];
            axKHOpenAPI.SetInputValue("�����ڵ�", textBox_KH_code.Text);
            var (nRet, sMsg) = await axKHOpenAPI.CommRqDataAsync("������Ʈ��û", "OPT10081", 0, "0101", (e)=>
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
            });

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
                listBox_result.Items.Add($"������Ʈ��û ����: {sMsg}");
            }

             */
        }
    }
}
