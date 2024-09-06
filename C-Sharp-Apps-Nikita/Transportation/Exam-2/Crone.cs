using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Apps_Nikita.Transportation.Exam_2
{
    public class Crone
    {
        private int rows, columns;

        public int Rows { get => rows; set => rows = value; }
        public int Columns { get => columns; set => columns = value; }

        public Crone(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }

        public Crone(Crone crone)
        {
            this.rows = crone.rows;
            this.columns = crone.columns;
        }

        public int GetSeats()
        {
            return rows * columns;
        }

        public int GetExtras()
        {
            return rows * 2;
        }
    }
}
