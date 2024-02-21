using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace SampleEyeShot
{
    public partial class Form1 : Form
    {
        Mesh board = Mesh.CreateBox(200, 200, 10);
        Mesh black = Mesh.CreateSphere(5, 40, 20);
        Mesh white = Mesh.CreateSphere(5, 40, 20);

        public Form1()
        {
            InitializeComponent();

            black.EntityData = "Black";
            white.EntityData = "White";
            board.EntityData = "Board";

            // Hides the grid
            design1.ActiveViewport.Grid.Visible = false;

            // Hides the origin symbol
            design1.ActiveViewport.OriginSymbol.Visible = false;

            design1.MouseClick += Design1_MouseClick;
            btnBack.Click += BtnBack_Click;
            btnReset.Click += BtnReset_Click;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            while(design1.Entities.Last().EntityData.ToString() != "Board")
            {
                design1.Entities.Remove(design1.Entities.Last());
            }
            design1.Invalidate();

            /*// 원하는것 list형태로 가져옴
            List<Entity> a = design1.Entities.Where(x => x.EntityData == "Black" || x.EntityData == "White").ToList();

            // 첫번째 가져옴 단 원하는게 없으면 null
            design1.Entities.FirstOrDefault();*/
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if(design1.Entities.Last().EntityData.ToString() == "Board")
            {
                MessageBox.Show("무르기를 할 수 있는 바둑알이 없습니다.");
            }
            else
            {
                design1.Entities.Remove(design1.Entities.Last());
                design1.Invalidate();
            }
        }

        private void Design1_MouseClick(object sender, MouseEventArgs e)
        {
            OmokRule omokRule = new OmokRule();

            var bCenterPoint = (black.BoxMin + black.BoxMax) / 2;
            var wCenterPoint = (white.BoxMin + white.BoxMax) / 2;

            List<Entity> ballList = design1.Entities.Where(x => x.EntityData == "Black" || x.EntityData == "White").ToList();

            Point3D mousePoint3D = design1.ScreenToWorld(new System.Drawing.Point(e.X, e.Y));
            if(design1.ActionMode == actionType.None)
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (mousePoint3D == null)
                    {
                        MessageBox.Show("범위 밖입니다.");
                    }
                    else if(checkLocation(mousePoint3D, ballList))
                    {
                        MessageBox.Show("해당 위치에 다른 바둑돌이 있습니다.");
                    }
                    else if (design1.Entities.Last().EntityData.ToString() == "White"
                        || design1.Entities.Last().EntityData.ToString() == "Board")
                    {
                        black.Translate(eggLocationX(mousePoint3D, bCenterPoint), eggLocationY(mousePoint3D, bCenterPoint));

                        design1.Entities.Add((Entity)black.Clone(), System.Drawing.Color.Black);
                        design1.Invalidate();

                        if (omokRule.CheckBlackConnect6(board, design1))
                        {
                            MessageBox.Show("장목은 금지되어있습니다.");
                            design1.Entities.Remove(design1.Entities.Last());
                            design1.Invalidate();

                        }
                        else if(omokRule.CheckDouble4(board, design1))
                        {
                            MessageBox.Show("4-4는 금지되어있습니다.");
                            design1.Entities.Remove(design1.Entities.Last());
                            design1.Invalidate();
                        }
                        else if (omokRule.CheckDouble3(board, design1))
                        {
                            MessageBox.Show("3-3은 금지되어있습니다.");
                            design1.Entities.Remove(design1.Entities.Last());
                            design1.Invalidate();
                        }
                    }
                    else if (design1.Entities.Last().EntityData.ToString() == "Black")
                    {
                        white.Translate(eggLocationX(mousePoint3D, wCenterPoint), eggLocationY(mousePoint3D, wCenterPoint));

                        design1.Entities.Add((Entity)white.Clone(), System.Drawing.Color.White);
                        design1.Invalidate();

                        if (omokRule.checkWhiteConnect6(board, design1))
                        {
                            MessageBox.Show(design1.Entities.Last().EntityData.ToString() + " 승리");
                            while (design1.Entities.Last().EntityData.ToString() != "Board")
                            {
                                design1.Entities.Remove(design1.Entities.Last());
                            }
                            design1.Invalidate();
                        }
                    }
                }
            }

            
            if (omokRule.CheckWin(board, design1))
            {
                MessageBox.Show(design1.Entities.Last().EntityData.ToString() + " 승리");
                while (design1.Entities.Last().EntityData.ToString() != "Board")
                {
                    design1.Entities.Remove(design1.Entities.Last());
                }
                design1.Invalidate();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            Line lX = new Line(0, 0, 0, board.BoxMax.Y);
            Line lY = new Line(0, 0, board.BoxMax.X, 0);

            lX.Translate(0, 0, 10);
            lY.Translate(0, 0, 10);

            black.Translate(0, 0, 15);
            white.Translate(0, 0, 15);

            for(int i = 0; i < 18; i++)
            {
                design1.Entities.Add((Entity)lX.Clone());
                lX.Translate(board.BoxMax.X / 18, 0);
                design1.Entities.Add((Entity)lY.Clone());
                lY.Translate(0, board.BoxMax.Y / 18);
            }

            design1.Entities.Add(board, System.Drawing.Color.BurlyWood);

            design1.SetView(viewType.Top);
            design1.ZoomFit();

            base.OnLoad(e);
        }

        private bool checkLocation(Point3D p, List<Entity> l)
        {
            var bCenterPoint = (black.BoxMin + black.BoxMax) / 2;
            var wCenterPoint = (white.BoxMin + white.BoxMax) / 2;

            for (int i = 0; i < l.Count; i++)
            {
                if(design1.Entities.Last().EntityData.ToString() == "White"
                        || design1.Entities.Last().EntityData.ToString() == "Board")
                {
                    if (Math.Round(eggLocationX(p, bCenterPoint) + bCenterPoint.X) == Math.Round((l[i].BoxMin.X + l[i].BoxMax.X) / 2)
                        && Math.Round(eggLocationY(p, bCenterPoint) + bCenterPoint.Y) == Math.Round((l[i].BoxMin.Y + l[i].BoxMax.Y) / 2))
                    {
                        return true;
                    }
                }
                else if (design1.Entities.Last().EntityData.ToString() == "Black")
                {
                    if (Math.Round(eggLocationX(p, wCenterPoint) + wCenterPoint.X) == Math.Round((l[i].BoxMin.X + l[i].BoxMax.X) / 2)
                        && Math.Round(eggLocationY(p, wCenterPoint) + wCenterPoint.Y) == Math.Round((l[i].BoxMin.Y + l[i].BoxMax.Y) / 2))
                    {
                        return true;
                    }

                }

            }

            return false;
        }

        private double eggLocationX(Point3D p, Point3D center)
        {
            return Math.Round(p.X / (board.BoxMax.X / 18)) * (board.BoxMax.X / 18) - center.X;
        }

        private double eggLocationY(Point3D p, Point3D center)
        {
            return Math.Round(p.Y / (board.BoxMax.Y / 18)) * (board.BoxMax.Y / 18) - center.Y;
        }

    }
}
