using System;
using System.Collections.Generic;
using System.Linq;


namespace TestovoeZadanieOnellect
{
    class Numbers
    {
        public List<int> elements = new List<int>();

        private const int minValue = -100;
        private const int maxValue = 100;
        private const int minCount = 20;
        private const int maxCount = 100;

        public Numbers(Random rand)
        {
            int count = rand.Next(minCount, maxCount + 1);
            Fill(rand, count);

        }

        public override string ToString()
        {
            return String.Join(" ", elements);
        }

        private void Fill(Random rand, int count)
        {
            for (int i = 0; i < count; i++)
            {
                elements.Add(rand.Next(minValue, maxValue + 1));
            }
        }

        public int Count{
            get{
                return elements.Count(); 
            }

        }
        /// <summary>
        /// Сортировка списка чисел рандомно выбранным алгоритмом
        /// </summary>
        /// <param name="rand"> рандомайзер для выбора алгоритма</param>
        public void Sort(Random rand)
        {
            int selectAlgo = rand.Next(SortAlgorithms.CountAlgorithms);
            switch (selectAlgo)
            {
                case 0:
                    {
                        SortAlgorithms.Bubble(this.elements);
                        break;
                    }
                case 1:
                    {
                        SortAlgorithms.Shaiker(this.elements);
                        break;
                    }
                case 2:
                    {
                        SortAlgorithms.Choice(this.elements);
                        break;
                    }
                case 3: {
                        SortAlgorithms.Quick(this.elements, 0 , this.elements.Count-1);
                        break;
                    }
            }
        }

    }
}
