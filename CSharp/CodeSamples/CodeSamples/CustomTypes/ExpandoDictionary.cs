using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace CodeSamples.CustomTypes
{
    // https://stackoverflow.com/a/9570300/8075004
    public class ExpandoDictionary : IEnumerable
    {
        private readonly IDictionary<string, object> _keyValuePairs;

        public ExpandoDictionary()
        {
            _keyValuePairs = new ExpandoObject();
        }

        public ExpandoDictionary(ExpandoObject keyValuePairs)
        {
            _keyValuePairs = keyValuePairs;
        }

        public object this[string key]
        {
            // https://stackoverflow.com/a/19008670/8075004
            get => _keyValuePairs[key];
            set => _keyValuePairs[key] = value;
        }

        public void Add(string key, object value)
        {
            _keyValuePairs.Add(key, value);
        }

        public bool TryGetValue(string key, out object value)
        {
            if (_keyValuePairs.ContainsKey(key))
            {
                value = _keyValuePairs[key];
                return true;
            }
            value = null;
            return false;
        }

        public bool TryGetValue<TValue>(string key, out TValue value)
        {
            if (_keyValuePairs.ContainsKey(key))
            {
                value = (TValue)_keyValuePairs[key];
                return true;
            }
            value = default;
            return false;
        }

        public ExpandoObject AsExpandoObject()
        {
            return (ExpandoObject)_keyValuePairs;
        }

        public IEnumerator GetEnumerator()
        {
            return _keyValuePairs.GetEnumerator();
        }
    }
}
