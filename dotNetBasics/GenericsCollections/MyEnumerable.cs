using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsCollections
{
    class MyEnumerator : IEnumerator
    {
        private int _max;
        private int _curr;

        public MyEnumerator(int max)
        {
            _max = max;
            _curr = 0;
        }
        public object Current => _curr;

        public bool MoveNext()
        {
            if (_curr < _max)
            {
                _curr++;
                return true;
            }
            return false;
        }

        public void Reset()
        {
            _curr = 0;
        }
    }
    class MyEnumerable : IEnumerable
    {
        private int _max;
        public MyEnumerable(int max)
        {
            _max = max;
        }        
        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(_max);
        }
    }

    class MyEnumerableYield : IEnumerable
    {
        private int _max;
        public MyEnumerableYield(int max)
        {
            _max = max;
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i > _max)
                {
                    yield break;
                }
                yield return i;
            }
        }
    }
}
