using System;
using System.Linq;
using System.Web;

namespace RefactoringToPatterns.ComposeMethod
{
    public class List
    {

        private readonly bool _readOnly;
        private int _size;
        private object[] _elements;

        public List(bool readOnly)
        {
            _readOnly = readOnly;
            _size = 0;
            _elements = new object[_size];
        }

        public void Add(object element)
        {
            if (_readOnly) return;
            if(IsNewSizeBiggerThanActualSize()) ExpandList();
            AddElement(element);
        }

        private bool IsNewSizeBiggerThanActualSize()
        {
            return _size + 1 > _elements.Length;
        }

        private void ExpandList()
        {
            var newElements = new object[_elements.Length + 10];

            CopyOldList(newElements);

            _elements = newElements;
        }

        private void CopyOldList(object[] newElements)
        {
            for (var i = 0; i < _size; i++)
                newElements[i] = _elements[i];
        }

        private void AddElement(object element)
        {
            _elements[_size++] = element;
        }

        public object[] Elements()
        {
            return _elements;
        }

    }

}