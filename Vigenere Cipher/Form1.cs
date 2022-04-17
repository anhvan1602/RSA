using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text;
namespace Vigenere_Cipher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            rd_nn.Checked = true;
            btn_Reset.Enabled = false;
        }

        //encryption function

        public class Vigernere
        {
            #region property
            public string key { get; set; }
            public string plainText { get; set; }
            public string cipherText {get; set; }
            #endregion


            string chuoi = @" !”#$%&’()*+,-/0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]Ỳ_ỶabcdefghijklmnopqrstuvwxyzÝỸĐÁÀẢÃẠÉÈẺẼẸÍÌỈĨỊÓÒỎÕỌÚÙỦŨỤĂẮẰẲẴẶÂẤẦẨẪẬÊẾỀỂỄỆÔỐỒỔỖỘƠỚỜỞỠỢỨỪỬỮỰđáàảãạéèẻẽẹíìỉĩịóòỏõọúùủũụăắằẳẵặâấầẩẫậêếềểễệôốồổỗộơớờởỡợưứừửữựýỳỷỹỵ";

            public int[] chuoi_mangchiso(StringBuilder s)
            {
                int[] mang = new int[s.Length];
                for (int i = 0; i < s.Length; i++)
                    mang[i] = chuoi.IndexOf(s[i]);
                return mang;
            }

            public string chiso_chuoi(int[] a)
            {
                string s = "";
                for (int i = 0; i < a.Length; i++)
                    s += chuoi[a[i]];
                return s;
            }
            public string MaHoa (ref StringBuilder plainText, StringBuilder key)
            {
                int []p = chuoi_mangchiso(plainText);
                int []k = chuoi_mangchiso(key);

                int []kq = new int[plainText.Length];
                for (int i = 0, j = 0; i < plainText.Length; i++)
                {
                    kq[i] = (p[i] + k[j]) % chuoi.Length;
                    j = ++j % k.Length;
                }
                cipherText = chiso_chuoi(kq);
                return cipherText;
             
            }

            public string GiaiMa (ref StringBuilder cipherText, StringBuilder key)
            {
                int[] c = chuoi_mangchiso(cipherText);
                int[] k = chuoi_mangchiso(key);

                int[] kq = new int[cipherText.Length];
                for (int i = 0, j = 0; i < cipherText.Length; i++)
                {
                    kq[i] = (c[i] - k[j]) % chuoi.Length;
                    if (kq[i] < 0)
                        kq[i] = (c[i] + (chuoi.Length - k[j])) % chuoi.Length;
                    j = ++j % k.Length;
                }
                plainText = chiso_chuoi(kq);
                return plainText;
            }
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            var ob1 = new Vigernere();
            StringBuilder s = new StringBuilder(textBox6.Text);
            StringBuilder key = new StringBuilder(textBox5.Text);
            ob1.GiaiMa(ref s, key);
            textBox4.Text = Convert.ToString(ob1.plainText);
        
        }


        private void button3_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void Form1_Load(object sender, EventArgs e)
            {

            }

            private void panel1_Paint(object sender, PaintEventArgs e)
            {

            }

            private void label1_Click(object sender, EventArgs e)
            {

            }

            private void label3_Click(object sender, EventArgs e)
            {

            }

            private void label5_Click(object sender, EventArgs e)
            {

            }

            private void label4_Click(object sender, EventArgs e)
            {

            }

            private void label7_Click(object sender, EventArgs e)
            {

            }

            private void textBox5_TextChanged(object sender, EventArgs e)
            {

            }

            private void label6_Click(object sender, EventArgs e)
            {

            }

            private void label8_Click(object sender, EventArgs e)
            {

            }

            private void textBox4_TextChanged(object sender, EventArgs e)
            {
                
            }

            private void textBox6_TextChanged(object sender, EventArgs e)
            {

            }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ob1 = new Vigernere();
            StringBuilder s = new StringBuilder(textBox1.Text);
            StringBuilder key = new StringBuilder(textBox2.Text);
            ob1.MaHoa(ref s, key);
            textBox3.Text = Convert.ToString(ob1.cipherText);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        //RSA
        private void reset_rsa()
        {
            tbx_p.Text = tbx_q.Text = tbx_phiN.Text = tbx_n.Text = tbx_e.Text = tbx_d.Text = string.Empty;

        }
        int RSA_soP, RSA_soQ, RSA_soN, RSA_soE, RSA_soD, RSA_soPhi_n;
        public int RSA_d_dau = 0;
        private int RSA_ChonSoNgauNhien()
        {
            Random rd = new Random();
            return rd.Next(11, 101);// tốc độ chậm nên chọn số bé
        }
        //"Hàm kiểm tra nguyên tố"
        private bool RSA_kiemTraNguyenTo(int xi)
        {
            bool kiemtra = true;
            if (xi == 2 || xi == 3)
            {
                // kiemtra = true;
                return kiemtra;
            }
            else
            {
                if (xi == 1 || xi % 2 == 0 || xi % 3 == 0)
                {
                    kiemtra = false;
                }
                else
                {
                    for (int i = 5; i <= Math.Sqrt(xi); i = i + 6)
                        if (xi % i == 0 || xi % (i + 2) == 0)
                        {
                            kiemtra = false;
                            break;
                        }
                }
            }
            return kiemtra;
        }

        private void btn_createKey_Click(object sender, EventArgs e)
        {

            if (rd_nn.Checked == true && rd_tc.Checked == false)
            {
                reset_rsa();
                RSA_soP = RSA_soQ = 0;
                do
                {
                    RSA_soP = RSA_ChonSoNgauNhien();
                    RSA_soQ = RSA_ChonSoNgauNhien();
                }
                while (RSA_soP == RSA_soQ || !RSA_kiemTraNguyenTo(RSA_soP) || !RSA_kiemTraNguyenTo(RSA_soQ));
                tbx_p.Text = RSA_soP.ToString();
                tbx_q.Text = RSA_soQ.ToString();
                RSA_taoKhoa();
                RSA_d_dau = 1;
                btn_createKey.Enabled = false;
                rd_tc.Enabled = false;
                rd_nn.Enabled = false;
                btn_MaHoa.Enabled = true;

            }
            else
            {
                if (rd_nn.Checked == false && rd_tc.Checked == true)
                {
                    if (tbx_q.Text == "" || tbx_q.Text == "")
                        MessageBox.Show("Phải nhập đủ 2 số ", "Thông Báo ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        RSA_soP = int.Parse(tbx_p.Text);
                        RSA_soQ = int.Parse(tbx_q.Text);
                        if (RSA_soP == RSA_soQ)
                        {
                            MessageBox.Show("Nhập 2 số nguyên tố khác nhau ", " Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            tbx_q.Focus();
                        }
                        else
                        {
                            if (!RSA_kiemTraNguyenTo(RSA_soP) || RSA_soP <= 1)
                            {
                                MessageBox.Show("Phải nhập số nguyên  tố [p] lớn hơn 1 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                tbx_p.Focus();
                            }
                            else
                            {
                                if (!RSA_kiemTraNguyenTo(RSA_soQ) || RSA_soQ <= 1)
                                {
                                    MessageBox.Show("Phải nhập số nguyên  tố [q] lớn hơn 1 ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    tbx_q.Focus();
                                }
                                else
                                {
                                    RSA_taoKhoa();
                                    tbx_p.Text = RSA_soP.ToString();
                                    tbx_q.Text = RSA_soQ.ToString();
                                    RSA_d_dau = 1;
                                    rd_tc.Enabled = false;
                                    rd_nn.Enabled = false;
                                    //bt_taokhoaTuychonMoi.Visible = true;
                                    btn_createKey.Enabled = false;
                                    btn_MaHoa.Enabled = true;

                                    tbx_p.Enabled = tbx_q.Enabled = tbx_phiN.Enabled = tbx_n.Enabled = tbx_e.Enabled = tbx_d.Enabled = false;
                                }
                            }
                        }
                    }

                }
            }
        }

        private void btn_MaHoa_Click(object sender, EventArgs e)
        {
            if (RSA_d_dau != 1)
            { MessageBox.Show("Bạn chưa tạo khóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            else
            {
                if (tbx_BangRo.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập bản rõ để mã hóa!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    // thực hiện mã hóa
                    try
                    {
                        RSA_MaHoa(tbx_BangRo.Text);
                        btn_MaHoa.Enabled = false;
                        btn_GiaiMa.Enabled = true;
                        RSA_d_dau = 2;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void rd_nn_Checked(object sender, EventArgs e)
        {
            btn_createKey.Enabled = true;
            tbx_p.Text = tbx_q.Text = tbx_phiN.Text = tbx_n.Text = tbx_e.Text = tbx_d.Text = string.Empty;
            tbx_p.Enabled= tbx_q.Enabled = tbx_phiN.Enabled = tbx_n.Enabled = tbx_e.Enabled = tbx_d.Enabled = false;
        }

        private void rd_tc_CheckedChanged(object sender, EventArgs e)
        {
            btn_createKey.Enabled = true;
            tbx_p.Text = tbx_q.Text = tbx_phiN.Text = tbx_n.Text = tbx_e.Text = tbx_d.Text = string.Empty;
            tbx_p.Enabled = tbx_q.Enabled = tbx_phiN.Enabled = tbx_n.Enabled = tbx_e.Enabled = tbx_d.Enabled = true;
        }

        private void btn_GiaiMa_Click(object sender, EventArgs e)
        {
            if (RSA_d_dau != 2)
                MessageBox.Show("Bạn phải tạo khóa trước ", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                try
                {
                    RSA_GiaiMa(tbx_BangMaHoa1.Text);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            btn_GiaiMa.Enabled = false;
            RSA_d_dau = 1;
            btn_Reset.Enabled = true;
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            btn_MaHoa.Enabled = true;
            tbx_BangRo.Text = tbx_BangMaHoa1.Text = tbx_BangMaHoa2.Text = tbx_BangGiaiMa.Text = string.Empty;
            RSA_d_dau = 1;
            btn_Reset.Enabled = false;
        }

        private void btn_New_Click(object sender, EventArgs e)
        {
            RSA_d_dau = 0;
            btn_Reset.Enabled = true;
            btn_createKey.Enabled = true;
            rd_nn.Enabled = true;
            rd_tc.Enabled = true;
            rd_nn.Checked = true;
            rd_tc.Checked = false;
            tbx_p.Text = tbx_q.Text = tbx_phiN.Text = tbx_n.Text = tbx_e.Text = tbx_d.Text = string.Empty;
            tbx_BangRo.Text = tbx_BangMaHoa1.Text = tbx_BangMaHoa2.Text = tbx_BangGiaiMa.Text = string.Empty;
        }

        private void btn_SaveKey_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "TXT file|*.txt";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
            }
        }
        // "Hàm kiểm tra hai số nguyên tố cùng nhau"
        private bool nguyenToCungNhau(int ai, int bi)
        {
            bool ktx_;
            // giải thuật Euclid;
            int temp;
            while (bi != 0)
            {
                temp = ai % bi;
                ai = bi;
                bi = temp;
            }
            if (ai == 1) { ktx_ = true; }
            else ktx_ = false;
            return ktx_;
        }
        // "Hàm lấy mod"
        public int RSA_mod(int mx, int ex, int nx)
        {

            //Sử dụng thuật toán "bình phương nhân"
            //Chuyển e sang hệ nhị phân
            int[] a = new int[100];
            int k = 0;
            do
            {
                a[k] = ex % 2;
                k++;
                ex = ex / 2;
            }
            while (ex != 0);
            //Quá trình lấy dư
            int kq = 1;
            for (int i = k - 1; i >= 0; i--)
            {
                kq = (kq * kq) % nx;
                if (a[i] == 1)
                    kq = (kq * mx) % nx;
            }
            return kq;
        }

        private void RSA_taoKhoa()
        {
            //Tinh n=p*q
            RSA_soN = RSA_soP * RSA_soQ;

            tbx_n.Text = RSA_soN.ToString();
            //Tính Phi(n)=(p-1)*(q-1)
            RSA_soPhi_n = (RSA_soP - 1) * (RSA_soQ - 1);
            tbx_phiN.Text = RSA_soPhi_n.ToString();
            //Tính e là một số ngẫu nhiên có giá trị 0< e <phi(n) và là số nguyên tố cùng nhau với Phi(n)
            do
            {
                Random RSA_rd = new Random();
                RSA_soE = RSA_rd.Next(2, RSA_soPhi_n);
            }
            while (!nguyenToCungNhau(RSA_soE, RSA_soPhi_n));
            tbx_e.Text = RSA_soE.ToString();

            //Tính d là nghịch đảo modular của e
            RSA_soD = 0;
            int i = 2;
            while (((1 + i * RSA_soPhi_n) % RSA_soE) != 0 || RSA_soD <= 0)
            {
                i++;
                RSA_soD = (1 + i * RSA_soPhi_n) / RSA_soE;
            }
            tbx_d.Text = RSA_soD.ToString();
        }


        public void RSA_MaHoa(string ChuoiVao)
        {
            // taoKhoa();
            // Chuyen xau thanh ma Unicode
            byte[] mh_temp1 = Encoding.Unicode.GetBytes(ChuoiVao);
            string base64 = Convert.ToBase64String(mh_temp1);

            // Chuyen xau thanh ma Unicode
            int[] mh_temp2 = new int[base64.Length];
            for (int i = 0; i < base64.Length; i++)
            {
                mh_temp2[i] = (int)base64[i];
            }

            //Mảng a chứa các kí tự đã mã hóa
            int[] mh_temp3 = new int[mh_temp2.Length];
            for (int i = 0; i < mh_temp2.Length; i++)
            {
                mh_temp3[i] = RSA_mod(mh_temp2[i], RSA_soE, RSA_soN); // mã hóa
            }

            //Chuyển sang kiểu kí tự trong bảng mã Unicode
            string str = "";
            for (int i = 0; i < mh_temp3.Length; i++)
            {
                str = str + (char)mh_temp3[i];
            }
            byte[] data = Encoding.Unicode.GetBytes(str);
            tbx_BangMaHoa1.Text = Convert.ToBase64String(data);
            tbx_BangMaHoa2.Text = Convert.ToBase64String(data);

        }
        // hàm giải mã
        public void RSA_GiaiMa(string ChuoiVao)
        {
            byte[] temp2 = Convert.FromBase64String(ChuoiVao);
            string giaima = Encoding.Unicode.GetString(temp2);

            int[] b = new int[giaima.Length];
            for (int i = 0; i < giaima.Length; i++)
            {
                b[i] = (int)giaima[i];
            }
            //Giải mã
            int[] c = new int[b.Length];
            for (int i = 0; i < c.Length; i++)
            {
                c[i] = RSA_mod(b[i], RSA_soD, RSA_soN);// giải mã
            }

            string str = "";
            for (int i = 0; i < c.Length; i++)
            {
                str = str + (char)c[i];
            }
            byte[] data2 = Convert.FromBase64String(str);
            tbx_BangGiaiMa.Text = Encoding.Unicode.GetString(data2);
        }

    } 
}
