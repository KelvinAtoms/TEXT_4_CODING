using Dijkstra_Vietnam;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dijkstra_Vietnam
{
    public class District
    {
        private string nameDistrict { get; set; }
        private string pointName { get; set; }
        private Point districtLocation { get; set; }

        public District(string name, string symbol, int x, int y)
        {
            nameDistrict = name;
            pointName = symbol;
            Point p = new Point(x, y);
            districtLocation = p;
        }
        public string getName()
        {
            return nameDistrict;
        }
        public string getPointName()
        {
            return pointName;
        }
        public Point getPoint()
        {
            return districtLocation;
        }
    }
}
