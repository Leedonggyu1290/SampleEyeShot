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
    class OmokRule
    {
        public bool CheckWin(Mesh board, Design design)
        {
            List<Entity> eggList = design.Entities.Where(x => x.EntityData == "Black" || x.EntityData == "White").ToList();

            int count = 0;

            // 가로 검사
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.X - ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                        && design.Entities.Last().BoxMax.Y == eggList[j].BoxMax.Y)
                    {
                        if (design.Entities.Last().EntityData == eggList[j].EntityData)
                            count++;
                        else
                            break;
                    }
                }
                for(int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.X + ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                        && design.Entities.Last().BoxMax.Y == eggList[j].BoxMax.Y)
                    {
                        if (design.Entities.Last().EntityData == eggList[j].EntityData)
                            count++;
                        else
                            break;
                    }
                }
            }
            if (count == 4)
            {
                return true;
            }
            count = 0;

            // 세로 검사
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.Y - ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                        && design.Entities.Last().BoxMax.X == eggList[j].BoxMax.X)
                    {
                        if (design.Entities.Last().EntityData == eggList[j].EntityData)
                            count++;
                        else
                            break;
                    }
                }
                for(int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.Y + ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                        && design.Entities.Last().BoxMax.X == eggList[j].BoxMax.X)
                    {
                        if (design.Entities.Last().EntityData == eggList[j].EntityData)
                            count++;
                        else
                            break;
                    }
                }
            }
            if (count == 4)
            {
                return true;
            }
            count = 0;

            // 우상향 대각 검사
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.X + ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                        && Math.Round(design.Entities.Last().BoxMax.Y + ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y))
                    {
                        if (design.Entities.Last().EntityData == eggList[j].EntityData)
                            count++;
                        else
                            break;
                    }
                }
                for(int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.X - ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                        && Math.Round(design.Entities.Last().BoxMax.Y - ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y))
                    {
                        if (design.Entities.Last().EntityData == eggList[j].EntityData)
                            count++;
                        else
                            break;
                    }
                }
            }
            if (count == 4)
            {
                return true;
            }
            count = 0;

            // 우하향 대각 검사
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.Y - ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                        && Math.Round(design.Entities.Last().BoxMax.X + ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X))
                    {
                        if (design.Entities.Last().EntityData == eggList[j].EntityData)
                            count++;
                        else
                            break;
                    }
                }
                for(int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.Y + ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                        && Math.Round(design.Entities.Last().BoxMax.X - ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X))
                    {
                        if (design.Entities.Last().EntityData == eggList[j].EntityData)
                            count++;
                        else
                            break;
                    }
                }
            }
            if (count == 4)
            {
                return true;
            }
            count = 0;

            return false;
        }

        public bool checkBlackConnect6(Mesh board, Design design)
        {
            List<Entity> eggList = design.Entities.Where(x => x.EntityData == "Black").ToList();

            int count = 0;

            // 가로 검사
            for(int i = 1; i <= 4; i++)
            {
                for(int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.X - ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                        && design.Entities.Last().BoxMax.Y == eggList[j].BoxMax.Y)
                    {
                        count++;
                    }
                    if (Math.Round(design.Entities.Last().BoxMax.X + ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                        && design.Entities.Last().BoxMax.Y == eggList[j].BoxMax.Y)
                    {
                        count++;
                    }
                }
            }
            if (count >= 5)
            {
                return true;
            }
            count = 0;

            // 세로 검사
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.Y - ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                        && design.Entities.Last().BoxMax.X == eggList[j].BoxMax.X)
                    {
                        count++;
                    }
                    if (Math.Round(design.Entities.Last().BoxMax.Y + ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                        && design.Entities.Last().BoxMax.X == eggList[j].BoxMax.X)
                    {
                        count++;
                    }
                }
            }
            if (count >= 5)
            {
                return true;
            }
            count = 0;

            // 우상향 대각 검사
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.X + ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                        && Math.Round(design.Entities.Last().BoxMax.Y + ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y))
                    {
                        count++;
                    }
                    if (Math.Round(design.Entities.Last().BoxMax.X - ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                        && Math.Round(design.Entities.Last().BoxMax.Y - ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y))
                    {
                        count++;
                    }
                }
            }
            if (count >= 5)
            {
                return true;
            }
            count = 0;

            // 우하향 대각 검사
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.Y - ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                        && Math.Round(design.Entities.Last().BoxMax.X + ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X))
                    {
                        count++;
                    }
                    if (Math.Round(design.Entities.Last().BoxMax.Y + ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                        && Math.Round(design.Entities.Last().BoxMax.X - ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X))
                    {
                        count++;
                    }
                }
            }
            if (count >= 5)
            {
                return true;
            }
            count = 0;

            return false;
        }

        public bool checkWhiteConnect6(Mesh board, Design design)
        {
            List<Entity> eggList = design.Entities.Where(x => x.EntityData == "White").ToList();

            int count = 0;

            // 가로 검사
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.X - ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                        && design.Entities.Last().BoxMax.Y == eggList[j].BoxMax.Y)
                    {
                        count++;
                    }
                    if (Math.Round(design.Entities.Last().BoxMax.X + ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                        && design.Entities.Last().BoxMax.Y == eggList[j].BoxMax.Y)
                    {
                        count++;
                    }
                }
            }
            if (count >= 5)
            {
                return true;
            }
            count = 0;

            // 세로 검사
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.Y - ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                        && design.Entities.Last().BoxMax.X == eggList[j].BoxMax.X)
                    {
                        count++;
                    }
                    if (Math.Round(design.Entities.Last().BoxMax.Y + ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                        && design.Entities.Last().BoxMax.X == eggList[j].BoxMax.X)
                    {
                        count++;
                    }
                }
            }
            if (count >= 5)
            {
                return true;
            }
            count = 0;

            // 우상향 대각 검사
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.X + ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                        && Math.Round(design.Entities.Last().BoxMax.Y + ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y))
                    {
                        count++;
                    }
                    if (Math.Round(design.Entities.Last().BoxMax.X - ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                        && Math.Round(design.Entities.Last().BoxMax.Y - ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y))
                    {
                        count++;
                    }
                }
            }
            if (count >= 5)
            {
                return true;
            }
            count = 0;

            // 우하향 대각 검사
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.Y - ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                        && Math.Round(design.Entities.Last().BoxMax.X + ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X))
                    {
                        count++;
                    }
                    if (Math.Round(design.Entities.Last().BoxMax.Y + ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                        && Math.Round(design.Entities.Last().BoxMax.X - ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X))
                    {
                        count++;
                    }
                }
            }
            if (count >= 5)
            {
                return true;
            }
            count = 0;

            return false;
        }
    }
}
