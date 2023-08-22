using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using static System.Net.WebRequestMethods;
using TreeView = System.Windows.Forms.TreeView;

namespace Task05_TrueView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(treeView1.SelectedNode.FullPath.ToString());
            /*TreeNode tNode;
            tNode = treeView1.Nodes.Add(@"Co so du lieu");
            treeView1.Nodes[0].Nodes.Add("He co so du lieu");
            treeView1.Nodes[0].Nodes.Add("He co so du lieu");
            treeView1.Nodes[0].Nodes[0].Nodes.Add("CLR");*/
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Tree();
            //treeFolder_BeforeExpand();
            
        }

        private void Tree()
        {
            
            string[] drives=Directory.GetLogicalDrives();
            TreeNode node = null;
            string file_Text = @"D:\1.txt";
            //using (StreamWriter writer = new StreamWriter(file_Text))
            //{
                foreach (string drv in drives)
                {
                    node = new TreeNode(drv);  
                    treeFolder.Nodes.Add(node);
                    node.Nodes.Add("Temp");
                    //writer.WriteLine(drv);
                }
            //}
        }

        private void treeFolder_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode node= e.Node;
            node.Nodes.Clear();
            node.ImageIndex = 0;
            string file_Text = @"D:\1.txt";
            try
            {
                //using (StreamWriter writer = new StreamWriter(file_Text))
               // {
                    foreach (string dir in Directory.GetDirectories(node.FullPath))
                    {
                        TreeNode n = node.Nodes.Add(Path.GetFileName(dir));
                        //writer.WriteLine(n);
                        n.Nodes.Add("Temp");
                    }
                   
                //}
            }
            catch { }
        }
        /*private void SaveTreeViewToTextFile(TreeView treeView, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (TreeNode node in treeView.Nodes)
                {
                    SaveTreeNodeToTextFile(node, writer, 0);
                }
            }
        }*/

       /*private void SaveTreeNodeToTextFile(TreeNode node, StreamWriter writer, int level)
        {
            string line = new string('-', level) + node.Text;
            writer.WriteLine(line);
            foreach (TreeNode childNode in node.Nodes)
            {
                SaveTreeNodeToTextFile(childNode, writer, level + 1);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string filePath = @"D:\1.txt";
            SaveTreeViewToTextFile(treeFolder, filePath);
        }
*/

    }
}
