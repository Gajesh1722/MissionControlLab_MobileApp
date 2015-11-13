using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using these following things
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;

namespace MissionControlLab
{
    public partial class Form1 : Form
    {

        GMapOverlay m_markersOverlay= new GMapOverlay();
        public Form1()
        {
            InitializeComponent();
        }

        private void gMapControl1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Full Screen MAp
            gMapControl1.SetBounds(0, 0, ClientRectangle.Width, ClientRectangle.Height);
            //Full Screen Foreground
            pictureBox1.SetBounds(0, 0, ClientRectangle.Width, ClientRectangle.Height);

            gMapControl1.MapProvider = GMap.NET.MapProviders.ArcGIS_Imagery_World_2D_MapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;


            //drag and zoom facility
            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 11;

            pictureBox1.Parent = gMapControl1;

            //for gray scale mode
            gMapControl1.GrayScaleMode =true;

            gMapControl1.Position = new GMap.NET.PointLatLng(43.389758, -80.405068);
            gMapControl1.Zoom = 11;

            //Drop a waypoint to my location

            /*GMarkerGoogle marker=new GMarkerGoogle(new GMap.NET.PointLatLng
                                                        (43.389758,-80.405068),
                                                        GMarkerGoogleType.green_dot);
            m_markersOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Add(m_markersOverlay);*/


            pictureBox2.Parent = gMapControl1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            //Drop a waypoint to my location give or take

            var r= new Random();

            double randomLat=43.389758+0.0001*r.Next(-100,100);
            double randomLon=-80.405068+0.0001*r.Next(-100,100);



            GMarkerGoogle marker = new GMarkerGoogle(new GMap.NET.PointLatLng
                                                        (randomLat, randomLon),
                                                        GMarkerGoogleType.green_dot);
            m_markersOverlay.Markers.Add(marker);
            gMapControl1.Overlays.Add(m_markersOverlay);
        }
    }
}
