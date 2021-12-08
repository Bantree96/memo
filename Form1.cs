using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memo
{
    public partial class Memo : Form
    {
        string savePath;
        string data;

        public Memo()
        {
            // 저장 경로
            savePath = "";

            // 데이터
            data = "";
            InitializeComponent();

        }

        private void 파일ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 저장SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 처음 저장
            if(savePath == "")
            {
                saveFile(data);
            } else
            {
                File.WriteAllText(savePath, data);
            }
            
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if(TextBox.Text != "")
            {
                this.Text = "*메모장";
            } else
            {
                this.Text = "메모장";
            }
            data = TextBox.Text;
        }

        private void 새로만들ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(data != "")
            {
                DialogResult result = MessageBox.Show("변경 내용을 제목 없음에 저장하시겠습니까?", "메모장", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    saveFile(data);
                }
                else if (result == DialogResult.No)
                {
                    TextBox.Text = "";
                }
                else if (result == DialogResult.Cancel)
                {

                }
            }
        }

        private void 열기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt file (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    savePath = openFileDialog.FileName;
                    TextBox.Text = File.ReadAllText(savePath);
                }
            }
        }

        public void saveFile(string data)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "c:\\";
                saveFileDialog.Filter = "txt file (*.txt)|*.txt";
                saveFileDialog.FilterIndex = 2;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    savePath = saveFileDialog.FileName;
                    File.WriteAllText(savePath, data);
                }
            }
        }

        private void 새창WToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 새 프로세스 실행
        }

        private void 다른이름으로저장ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile(data);
        }

        private void 끝내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (data != "")
            {
                DialogResult result = MessageBox.Show("변경 내용을 제목 없음에 저장하시겠습니까?", "메모장", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    saveFile(data);
                }
                else if (result == DialogResult.No)
                {
                    // 프로그램 종료
                }
                else if (result == DialogResult.Cancel)
                {

                }
            }
        }
    }
}
