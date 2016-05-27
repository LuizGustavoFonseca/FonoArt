using AL.NucleoPoliticasComerciais.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AL.NucleoPoliticasComerciais.Repositorios.Util
{
    class DicionarioEntidade<TDicEntidade> : IDictionary<IChaveEntidade, TDicEntidade> where TDicEntidade : IEntidade
    {
        private Dictionary<IChaveEntidade, TDicEntidade> _DicionarioInterno = new Dictionary<IChaveEntidade, TDicEntidade>(new Comparador());
        private IList<TDicEntidade> _ListaControlada;

        public DicionarioEntidade()
            : this(false)
        {
        }

        public DicionarioEntidade(bool controlarLista)
        {
            if (controlarLista)
            {
                _ListaControlada = new List<TDicEntidade>();
            }
        }


        private void AdicionarNaLista(TDicEntidade value)
        {
            if (_ListaControlada != null)
            {
                _ListaControlada.Add(value);
            }
        }

        private void RemoverDaLista(IChaveEntidade key)
        {
            TDicEntidade entidade = _ListaControlada.FirstOrDefault(_i => _i.ObterChave().Equals(key));
            if (entidade != null)
            {
                _ListaControlada.Remove(entidade);
            }
        }

        public void Add(IChaveEntidade key, TDicEntidade value)
        {
            _DicionarioInterno.Add(key, value);
            AdicionarNaLista(value);
        }

        public bool ContainsKey(IChaveEntidade key)
        {
            return _DicionarioInterno.ContainsKey(key);
        }

        public ICollection<IChaveEntidade> Keys
        {
            get
            {
                return _DicionarioInterno.Keys;
            }
        }

        public bool Remove(IChaveEntidade key)
        {
            RemoverDaLista(key);
            return _DicionarioInterno.Remove(key);
        }

        public bool TryGetValue(IChaveEntidade key, out TDicEntidade value)
        {
            return _DicionarioInterno.TryGetValue(key, out value);
        }

        public ICollection<TDicEntidade> Values
        {
            get
            {
                if (_ListaControlada != null)
                {
                    return _ListaControlada;
                }

                return _DicionarioInterno.Values;
            }
        }

        public TDicEntidade this[IChaveEntidade key]
        {
            get
            {
                return _DicionarioInterno[key];
            }

            set
            {
                AdicionarNaLista(value);
                _DicionarioInterno[key] = value;
            }
        }

        public void Add(KeyValuePair<IChaveEntidade, TDicEntidade> item)
        {
            AdicionarNaLista(item.Value);
            _DicionarioInterno[item.Key] = item.Value;
        }

        public void Clear()
        {
            if (_ListaControlada != null)
            {
                _ListaControlada.Clear();
            }
            _DicionarioInterno.Clear();
        }

        public bool Contains(KeyValuePair<IChaveEntidade, TDicEntidade> item)
        {
            return _DicionarioInterno.ContainsKey(item.Key);
        }

        public void CopyTo(KeyValuePair<IChaveEntidade, TDicEntidade>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return _DicionarioInterno.Count; }
        }

        public bool IsReadOnly
        {
            get { return ((IDictionary<IChaveEntidade, TDicEntidade>)_DicionarioInterno).IsReadOnly; }
        }

        public bool Remove(KeyValuePair<IChaveEntidade, TDicEntidade> item)
        {
            return _DicionarioInterno.Remove(item.Key);
        }

        public IEnumerator<KeyValuePair<IChaveEntidade, TDicEntidade>> GetEnumerator()
        {
            return ((IDictionary<IChaveEntidade, TDicEntidade>)_DicionarioInterno).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _DicionarioInterno.GetEnumerator();
        }

        private class Comparador : IEqualityComparer<IChaveEntidade>
        {
            public bool Equals(IChaveEntidade x, IChaveEntidade y)
            {
                return (x == null && y == null) || (x != null && x.Equals(y));
            }

            public int GetHashCode(IChaveEntidade obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
