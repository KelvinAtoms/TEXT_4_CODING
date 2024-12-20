using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dijkstra_Vietnam
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public List<District> districts = new List<District>();
        UndirectedWeightedGraph g = new UndirectedWeightedGraph();
        private Graphics graph; 
        private void Form1_Load(object sender, EventArgs e)
        {
            District quan1 = new District("Quận 1", "A", 550, 235);
            District quan3 = new District("Quận 3", "B", 510, 232);
            District quan4 = new District("Quận 4", "C", 536, 295);
            District quan5 = new District("Quận 5", "D", 493, 296);
            District quan6 = new District("Quận 6", "E", 350, 350);
            District quan8 = new District("Quận 8", "F", 420, 350);
            District quan10 = new District("Quận 10", "G", 450, 265);
            District quan11 = new District("Quận 11", "H", 390, 270);
            District quantanbinh = new District("Quận Tân Bình", "I", 400, 180);
            District quanbinhthanh = new District("Quận Bình Thạnh", "K", 560, 160);
            District quanphunhuan = new District    ("Quận Phú Nhuận", "L", 500, 180);
            District quangovap = new District("Quận Gò Vấp", "M", 490, 60);
            District quantanphu = new District("Quận Tân Phú", "N", 350, 230);
            districts.Add(quan1);
            districts.Add(quan3);
            districts.Add(quan4);
            districts.Add(quan5);
            districts.Add(quan6);
            districts.Add(quan8);
            districts.Add(quan10);
            districts.Add(quan11);
            districts.Add(quantanbinh);
            districts.Add(quanbinhthanh);
            districts.Add(quanphunhuan);
            districts.Add(quangovap);
            districts.Add(quantanphu);
            Graphics graph = pnMap.CreateGraphics();
            for (int i = 0; i < districts.Count; i++)
            {
                lvListDistricts.Items.Add(districts[i].getPointName());
                lvListDistricts.Items[i].SubItems.Add(districts[i].getName());
                g.listPoint.Add(districts[i].getPoint());
                g.InsertVertex(districts[i].getName());
            }
            g.InsertEdge("Quận 1", "Quận 3", 3);//3 2
            g.InsertEdge("Quận 3", "Quận 10", 3);//3 4
            g.InsertEdge("Quận 10", "Quận 5", 3);//3 5
            g.InsertEdge("Quận 5", "Quận 6", 6);//6 3
            g.InsertEdge("Quận Tân Phú", "Quận Tân Bình", 4);// 4 6
            g.InsertEdge("Quận Tân Bình", "Quận Gò Vấp", 9);// 9 8
            g.InsertEdge("Quận Phú Nhuận", "Quận Bình Thạnh", 5);// 5 4
            g.InsertEdge("Quận Gò Vấp", "Quận Phú Nhuận", 6);// 6 7
            g.InsertEdge("Quận 8", "Quận 6", 9);// 9 6 Lay duong xe, khong lay duong di bo
            g.InsertEdge("Quận 6", "Quận Tân Phú", 9);// 9 7
            g.InsertEdge("Quận 11", "Quận 6", 4);// 4 4
            g.InsertEdge("Quận Bình Thạnh", "Quận 1", 8);// 8 8
            g.InsertEdge("Quận 10", "Quận 11", 3);// 3 3
            g.InsertEdge("Quận 4", "Quận 1", 4);// 4 3
            g.InsertEdge("Quận 5", "Quận 4", 6);// 6 4
            g.InsertEdge("Quận 8", "Quận 4", 6);// 6 7
            g.InsertEdge("Quận Gò Vấp", "Quận Bình Thạnh",6);// 6 6
            g.InsertEdge("Quận Tân Bình", "Quận Phú Nhuận",4);// 4 4
            g.InsertEdge("Quận 3", "Quận Phú Nhuận", 3);// 3 3
            g.InsertEdge("Quận Tân Bình", "Quận 10", 6);// 6 4
            g.InsertEdge("Quận 11", "Quận Tân Phú", 7);// 7 6
            g.InsertEdge("Quận 11", "Quận 5", 3);// 3 4
            g.InsertEdge("Quận 1", "Quận 5", 6);// 6 6
            cbSource.Items.Add("Quận 1");//(13 +-10m) on 90 Nguyen Hue Strt
            cbSource.Items.Add("Quận 3");// on 60 Truong Dinh Strt
            cbSource.Items.Add("Quận 4");// 266/120 Ton Dang Strt
            cbSource.Items.Add("Quận 5");// 6 Mac Thien Tich Strt
            cbSource.Items.Add("Quận 6");// 214 Nguyen Van Luong Strt
            cbSource.Items.Add("Quận 8");// 203 Luu Huu Phuoc Strt
            cbSource.Items.Add("Quận 10");// 436 3/2 Strt
            cbSource.Items.Add("Quận 11");// 3 Duong Dinh Nghe Strt 
            cbSource.Items.Add("Quận Tân Bình");// 247 Hoang Hoa Tham Strt
            cbSource.Items.Add("Quận Bình Thạnh");// 207 Nguyen Xi Strt
            cbSource.Items.Add("Quận Phú Nhuận");// 29 Tran Khac Chan Strt
            cbSource.Items.Add("Quận Gò Vấp");// 300 Nguyen Van Luong Strt
            cbSource.Items.Add("Quận Tân Phú");// 10 Phung Chi Kien Strt
            cbDestination.Items.Add("Quận 1");
            cbDestination.Items.Add("Quận 3");
            cbDestination.Items.Add("Quận 4");
            cbDestination.Items.Add("Quận 5");
            cbDestination.Items.Add("Quận 6");
            cbDestination.Items.Add("Quận 8");
            cbDestination.Items.Add("Quận 10");
            cbDestination.Items.Add("Quận 11");
            cbDestination.Items.Add("Quận Tân Bình");
            cbDestination.Items.Add("Quận Bình Thạnh");
            cbDestination.Items.Add("Quận Phú Nhuận");
            cbDestination.Items.Add("Quận Gò Vấp");
            cbDestination.Items.Add("Quận Tân Phú");
        }
        //Vẽ bản đồ ra Panel
        private void pnMap_Paint(object sender, PaintEventArgs e)
        {
            Graphics graph = pnMap.CreateGraphics();
            for (int i = 0; i < districts.Count; i++)
            {
                SolidBrush brush = new SolidBrush(Color.Purple);
                Brush pointName = new SolidBrush(Color.White);
                graph.FillEllipse(brush, districts[i].getPoint().X - 5, districts[i].getPoint().Y - 5, 20, 20);
                graph.DrawString(districts[i].getPointName(), new Font("Arial", 10), pointName, districts[i].getPoint().X , districts[i].getPoint().Y );
            }
            DrawLine();
        }

        private void DrawLine()
        {
            DrawLine("Quận 1", "Quận 3");
            DrawLine("Quận 3", "Quận 10");
            DrawLine("Quận 10", "Quận 5");
            DrawLine("Quận 5", "Quận 6");
            DrawLine("Quận Tân Phú", "Quận Tân Bình");
            DrawLine("Quận Tân Bình", "Quận Gò Vấp");
            DrawLine("Quận Phú Nhuận", "Quận Bình Thạnh");
            DrawLine("Quận Phú Nhuận", "Quận Gò Vấp");
            DrawLine("Quận 8", "Quận 6");
            DrawLine("Quận 6", "Quận Tân Phú");          
            DrawLine("Quận 11", "Quận 6");
            DrawLine("Quận Bình Thạnh", "Quận 1");
            DrawLine("Quận 10", "Quận 11");
            DrawLine("Quận 4", "Quận 1");
            DrawLine("Quận 5", "Quận 4");
            DrawLine("Quận 8", "Quận 4");
            DrawLine("Quận Gò Vấp", "Quận Bình Thạnh");
            DrawLine("Quận Tân Bình", "Quận Phú Nhuận");
            DrawLine("Quận 3", "Quận Phú Nhuận");
            DrawLine("Quận Tân Bình", "Quận 10");
            DrawLine("Quận 11", "Quận Tân Phú");
            DrawLine("Quận 11", "Quận 5");
            DrawLine("Quận 1", "Quận 5");
        }
        private void DrawLine(string a, string b)
        {
            Graphics graph = pnMap.CreateGraphics();
            int x = g.GetIndex(a);
            int y = g.GetIndex(b);
            Pen p = new Pen(Color.Black, 2);
            Point point1 = new Point(g.listPoint[x].X , g.listPoint[x].Y );
            Point point2 = new Point(g.listPoint[y].X , g.listPoint[y].Y );
            graph.DrawLine(p, point1, point2);
            graph.DrawString($"{g.adj[x, y]}", new Font("Fira Code", 10), Brushes.Black, new Point((point1.X + point2.X) / 2 - 8, (point1.Y + point2.Y) / 2 + 8));
        }

        private void cbSource_SelectedIndexChanged(object sender, EventArgs e)//cac canh duyet
        {
            if (cbSource.SelectedIndex != -1 && cbDestination.SelectedIndex != -1)
            {
                pnMap.Controls.Clear();
                pnMap.Refresh();
                DrawLine();
                g.pathIndex.Clear();
                tbCost.Clear();
                tbPath.Clear();
                g.FindPaths(cbSource.SelectedItem.ToString(), cbDestination.SelectedIndex.ToString(), tbCost, tbPath);
                for (int i = 0; i < g.pathIndex.Count - 1; i++)
                {
                    DrawPathLine(i);
                }
            }
        }

        private void cbDestination_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSource.SelectedIndex != -1 && cbDestination.SelectedIndex != -1)
            {
                pnMap.Controls.Clear();
                pnMap.Refresh();
                DrawLine();
                g.pathIndex.Clear();
                tbCost.Clear();
                tbPath.Clear();
                g.FindPaths(cbSource.SelectedItem.ToString(), cbDestination.SelectedIndex.ToString(), tbCost, tbPath);
                for (int i = 0; i < g.pathIndex.Count - 1; i++)
                {
                    DrawPathLine(i);
                }
            }
        }
        //Vẽ lại đường đi ngắn nhất
        private void DrawPathLine(int i)
        {
            Graphics graph = pnMap.CreateGraphics();
            Pen p = new Pen(Color.Aqua, 2);
            Point point1 = new Point(g.pathIndex[i].X , g.pathIndex[i].Y );
            Point point2 = new Point(g.pathIndex[i + 1].X , g.pathIndex[i + 1].Y );
            graph.DrawLine(p, point1, point2);
        }

        private void lvListDistricts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flpListDistrict_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tbCost_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
